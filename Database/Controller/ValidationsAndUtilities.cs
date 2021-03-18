using Database.Model;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Database.Controller
{
    public class PrimDataVal //Validations for Form2
    {
        public string GenerateEmployeeNomber(string data)
        {
            string zero = "";
            for (int i = 0; i <= (7 - data.Length); i++)
            {
                zero += "0";
            }
            zero += data;
            return zero;
        }

        #region Validar PersonName
        //Usando regex, comprobar si los datos son correctos
        public bool ValidateName(string personName)
        {
            var regex = new Regex(@"^[A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ]+( [A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ]+)*$");
            var match = regex.Match(personName);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        public Tuple<bool, string> CheckPersonName(Personnel personnel)
        {
            string message = "";
            bool isValid = true;
            if (personnel.PersonName.Length == 0)
            {
                message = "Please type the person's name";
                isValid = false;
            }
            else if (!ValidateName(personnel.PersonName))
            {
                message = "This person's name is invalid (does it containg numbers?).";
                isValid = false;
            }
            else if (personnel.PersonName.Length > 255)
            {
                message = "This person's name is too long. \nI don't even know you managed to trigger this.";
                isValid = false;
            }
            return Tuple.Create(isValid, message);
        }
        #endregion

        #region Validar Telefono
        public bool ValidatePhoneNumber(string tel)
        {
            var regex = new Regex(@"^[0-9]{10}");
            var match = regex.Match(tel);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        public Tuple<bool, string> CheckPersonPhoneNumber(Personnel personnel)
        {
            string message = "";
            bool isValid = true;

            if (personnel.PhoneNumber.Length == 0)
            {
                message = "Phone number field cannot be empty";
                isValid = false;
            }
            else if (!ValidatePhoneNumber(personnel.PhoneNumber))
            {
                message = "This phone number is invalid (does it contain letters?)";
                isValid = false;
            }
            else if (personnel.PhoneNumber.Length > 10)
            {
                message = "Phone number length exceeds 10 numbers";
                isValid = false;
            }
            return Tuple.Create(isValid, message);
        }
        #endregion

        #region Validar No Personnel
        private bool ValidateEmployeeNumber(string noPersonnel)
        {
            var regex = new Regex(@"^[0-9]");
            var match = regex.Match(noPersonnel);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        public Tuple<bool, string> ComprobarNoPersonnel(Personnel personnel)
        {
            string employeeNumber = personnel.EmployeeNo;
            string message = "";
            bool isValid = true;

            if (employeeNumber.Length == 0)
            {
                message = "Employee number cannot be empty";
                isValid = false;
            }
            else if (!ValidateEmployeeNumber(employeeNumber))
            {
                message = "This employee number cointains text or other characters";
                isValid = false;
            }
            else if (employeeNumber.Length > 8)
            {
                message = "This employee number length exceeds 8 characters";
                isValid = false;
            }
            else if (employeeNumber == "00000000")
            {
                message = "Employee number cannot be only zeros";
                isValid = false;
            }
            return Tuple.Create(isValid, message);
        }
        #endregion
    }

    public class SecDataVal : PrimDataVal //Validations for Form3
    {
        public Tuple<bool, string> CheckEmerContactName(SecondaryData secondaryData)
        {
            string message = "";
            bool isValid = true;
            if (secondaryData.EmerContactName.Length == 0)
            {
                message = "Please type the person's name";
                isValid = false;
            }
            else if (!ValidateName(secondaryData.EmerContactName))
            {
                message = "This person's name is invalid (does it containg numbers?).";
                isValid = false;
            }
            else if (secondaryData.EmerContactName.Length > 255)
            {
                message = "This person's name is too long. \nI don't even know you managed to trigger this.";
                isValid = false;
            }
            return Tuple.Create(isValid, message);
        }

        public Tuple<bool, string> CheckEmergencyPhoneNumber(SecondaryData secondaryData)
        {
            string message = "";
            bool isValid = true;

            if (secondaryData.EmerContactPhone.Length == 0)
            {
                message = "Phone number field cannot be empty";
                isValid = false;
            }
            else if (!ValidatePhoneNumber(secondaryData.EmerContactPhone))
            {
                message = "This phone number is invalid (does it contain letters?)";
                isValid = false;
            }
            else if (secondaryData.EmerContactPhone.Length > 10)
            {
                message = "Phone number length exceeds 10 numbers";
                isValid = false;
            }
            return Tuple.Create(isValid, message);
        }
    }

    public class DepDataVal //Validations for Form4
    {
    }

    public class GeneralManager //Files management
    {
        private RouteManager routeManager;

        #region Store images method

        public string StoreImage(string fileName, string employeeNo)
        {
            routeManager = new RouteManager(ConfigurationManager.AppSettings["route"]);
            var fullFileName = string.Concat(fileName.Where(c => !char.IsWhiteSpace(c)));
            var result = "";
            if (!string.IsNullOrEmpty(fullFileName))
            {
                var imageData = new FileInfo(fullFileName);
                string route = Path.Combine(routeManager.GenerateImageRoute, employeeNo);
                try
                {
                    if (Directory.Exists(route))
                    {
                        var getFileList = Directory.GetFiles(route);
                        FileInfo fileExists;
                        if (getFileList.Length != 0)
                        {
                            fileExists = new FileInfo(getFileList[0]);
                            if (fileExists.Exists)
                            {
                                imageData.CopyTo(Path.Combine(route, imageData.Name));
                                //imageData.Replace(Path.Combine(route, imageData.Name), Path.Combine(route, "Old.jpg"), true);
                            }
                        }
                        else
                        {
                            imageData.CopyTo(Path.Combine(route, imageData.Name));
                        }
                    }
                    else
                    {
                        routeManager.CreateImageStoragePerEmployee(employeeNo);
                        imageData.CopyTo(Path.Combine(route, imageData.Name));
                    }
                    result = Path.Combine(route, imageData.Name);
                }
                catch (IOException)
                {
                    return result = Path.Combine(route, imageData.Name);
                }
                catch (Exception)
                {
                    return "Could not copy image into new directory";
                }
            }

            return result;
        }

        #endregion Store images method

        #region Create cards method

        public Tuple<string, bool> CreateCard(List<Batch> batchList)
        {
            var result = "";
            var boolResult = true;

            try
            {
                var htmlCard = new List<string>();
                var appPath = ConfigurationManager.AppSettings["route"];

                var cardFormat = Path.Combine(appPath, "CardFormat\\CardLayout.htm");
                var readHeader = new StreamReader(cardFormat);
                var headerFormat = readHeader.ReadToEnd();
                readHeader.Close();

                var tableFormat = Path.Combine(appPath, "CardFormat\\TableLayout.htm");
                var exitRoute = Path.Combine(appPath, "TempFiles\\Cards.pdf");

                if (!routeManager.CheckIfOpen(exitRoute))
                {
                    var htmlTableFormat = File.Open(tableFormat, FileMode.Open, FileAccess.Read);
                    var formatReader = new StreamReader(htmlTableFormat);
                    var shape = formatReader.ReadToEnd();
                    formatReader.Close();
                    var userFormat = string.Empty;

                    htmlCard.Add(headerFormat);
                    htmlCard.Add("<body>");

                    foreach (var item in batchList)
                    {
                        userFormat = shape;
                        userFormat = userFormat.Replace("{Name}", item.PersonName);
                        userFormat = userFormat.Replace("{Dep}", item.Department);
                        userFormat = userFormat.Replace("{Pos}", item.Position);
                        userFormat = userFormat.Replace("{No}", item.EmployeeNo);
                        userFormat = userFormat.Replace("{Sangre}", item.Bloodtype);
                        userFormat = userFormat.Replace("{IMSS}", item.IMSSNo);
                        userFormat = userFormat.Replace("{Contacto}", item.EmerContactName);
                        userFormat = userFormat.Replace("{TelC}", item.EmerContactPhone);
                        userFormat = userFormat.Replace("{Par}", item.EmerContactRelationship);
                        userFormat = userFormat.Replace("{EmpImg}", Regex.Replace(item.UserImageRoute, @"\s+", "%20"));
                        htmlCard.Add(userFormat);
                    }

                    htmlCard.Add("</body>");
                    htmlCard.Add("</html>");

                    var completedFile = Path.Combine(appPath, "CardFormat\\FinalFormat.htm");
                    if (!File.Exists(completedFile))
                    {
                        File.Create(completedFile).Dispose();
                    }

                    using (var streamWriter = new StreamWriter(completedFile))
                    {
                        streamWriter.WriteLine(string.Join(Environment.NewLine, htmlCard));
                        streamWriter.Flush();
                    }

                    var streamReader = new StreamReader(completedFile);
                    var finalFormat = streamReader.ReadToEnd();
                    streamReader.Close();

                    var fileStream = File.Open(exitRoute, FileMode.OpenOrCreate);
                    var converterProperties = new ConverterProperties();
                    var cssRoute = Path.Combine(appPath, "CardFormat\\");
                    converterProperties.SetBaseUri(cssRoute);
                    var pdfWriter = new PdfWriter(fileStream);
                    var pdfDocument = new PdfDocument(pdfWriter);
                    pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4);
                    var document = HtmlConverter.ConvertToDocument(finalFormat, pdfDocument, converterProperties);
                    document.Close();

                    System.Diagnostics.Process.Start(exitRoute);
                    result = "Document created successfully";
                    return Tuple.Create(result, boolResult);
                }
                else
                {
                    result = "Cannot create a new document while it is still open";
                    boolResult = false;
                    return Tuple.Create(result, boolResult);
                }
            }
            catch (Exception)
            {
                boolResult = false;
                result = "File failed to be created, please try again";
                return Tuple.Create(result, boolResult);
            }
        }

        #endregion Create cards method

        public Tuple<string, bool> OnClosing()
        {
            routeManager = new RouteManager(ConfigurationManager.AppSettings["route"]);
            var result = routeManager.RemoveTemporaryFile("Tarjetas.pdf");
            return Tuple.Create(result.Item1, result.Item2);
        }
    }
}