using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class ConnectionManager
    {
        string connectionString;
        public ConnectionManager(string user, string password, string database)
        {
            connectionString = $"Server=DESKTOP-1BQ9MH1\\TestServer;Database={database};User Id={user};Password{password};";
        }

        //public async Task<string> InsertValues(Personnel personnel, SecondaryData secondaryData, DepartmentData departmentData)
        //{
        //    var dbConn = new SqlConnection(connectionString);
        //    var cmdText = $"";
        //    var command = new SqlCommand(cmdText, dbConn);

        //    try
        //    {
        //        dbConn.Open();
        //        await command.ExecuteNonQueryAsync();
        //        dbConn.Close();
        //        return true.ToString();
        //    }
        //    catch (SqlException exception)
        //    {
        //        System.Console.WriteLine("Agregarte aquí es disminuír la calidad de los demás");
        //        dbConn.Close();
        //        return exception.Message;
        //    }
        //}

        public async Task<string> InsertValues(string jsonObject, string createdBy)
        {
            var cmdText = $"execute DataManagement '@personName', '@birthDate', '@employeeNo', '@educationLevel', '@carreerName'," +
                $" '@personalMail', '@curp', '@ine', '@gender', '@bloodType', '@maritalStatus', '@rfc'," +
                $" '@phoneNumber', '@hsbcAccount', '@passportNo', '@usVisaNo', '@birthState', '@infonavitNo', '@passportExpiration'," +
                $" '@usVisaExpiration', '@currentAddress'," +
                $" '@emerContactRelationship', '@emerContactName', '@emerContactPhone', '@department', '@area', '@positon', '@paymentType'," +
                $" '@mailAccount', '@bpmAccount', '@erpAccount', '@transportation'," +
                $" '@pickupColony', '@pickupRoute', '@userImageRoute', '@createdBy', '@updatedBy', 'Create'";
            try
            {
                var deserializedObject = JsonConvert.DeserializeObject<List<BatchObject>>(jsonObject);
                foreach (var item in deserializedObject)
                {
                    using (var dbConn = new SqlConnection(connectionString))
                    using (var command = BatchAddWithValue(cmdText, dbConn, item, createdBy, DateTime.Now.ToString()))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return true.ToString();
            }
            catch (SqlException exception)
            {
                return exception.Message;
            }
        }

        public async Task<string> UpdateValues(string jsonObject, string updatedBy, string updateTime)
        {
            var cmdText = $"execute DataManagement '@personName', '@birthDate', '@employeeNo', '@educationLevel', '@carreerName'," +
                $" '@personalMail', '@curp', '@ine', '@gender', '@bloodType', '@maritalStatus', '@rfc'," +
                $" '@phoneNumber', '@hsbcAccount', '@passportNo', '@usVisaNo', '@birthState', '@infonavitNo', '@passportExpiration'," +
                $" '@usVisaExpiration', '@currentAddress'," +
                $" '@emerContactRelationship', '@emerContactName', '@emerContactPhone', '@department', '@area', '@positon', '@paymentType'," +
                $" '@mailAccount', '@bpmAccount', '@erpAccount', '@transportation'," +
                $" '@pickupColony', '@pickupRoute', '@userImageRoute', '@createdBy', '@updatedBy', 'Update'";
            try
            {
                var deserializedObject = JsonConvert.DeserializeObject<List<BatchObject>>(jsonObject);
                foreach (var item in deserializedObject)
                {
                    using (var dbConn = new SqlConnection(connectionString))
                    using (var command = BatchAddWithValue(cmdText, dbConn, item, updatedBy, DateTime.Now.ToString()))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return true.ToString();
            }
            catch (SqlException exception)
            {
                return exception.Message;
            }
        }

        public async Task<string> DeleteValue(int userId, string deletedBy)
        {
            var cmdText = $"exec uspDeleteRecord '@userId', '@deletedBy' ";
            try
            {
                using (var dbConn = new SqlConnection(connectionString))
                using (var command = new SqlCommand(cmdText, dbConn))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@deletedBy", deletedBy);
                    await command.ExecuteNonQueryAsync();
                    return true.ToString();
                }
            }
            catch (SqlException exception)
            {
                return exception.Message;
            }
        }

        public Task<DataSet> GetAllData()
        {
            var dataSet = new DataSet();
            var cmdText = $"exec uspGetEmployees;";
            try
            {
                return Task.Run(() =>
                {
                    using (var dbConn = new SqlConnection(connectionString))
                    using (var query = new SqlDataAdapter(cmdText, dbConn))
                    {
                        query.Fill(dataSet);
                        return dataSet;
                    }
                });
            }
            catch (SqlException exception)
            {
                return (Task<DataSet>)Task.Run(() => { System.Console.WriteLine(exception.Message); });
            }
        }

        public bool LoginQuery(string user, string password)
        {
            var cmdText = $"exec uspGetLoginCheck '@usrNm', '@pw'";

            try
            {
                using (var dbConn = new SqlConnection(connectionString))
                using (var command = new SqlCommand(cmdText, dbConn))
                {
                    command.Parameters.AddWithValue("@usrNm", user);
                    command.Parameters.AddWithValue("@pw", password);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public SqlCommand BatchAddWithValue(string cmdText, SqlConnection databaseConnection, BatchObject batch, string createdBy, string updateBy)
        {
            var command = new SqlCommand(cmdText, databaseConnection);
            try
            {
                #region MuchoTexto.exe
                command.Parameters.AddWithValue("@personName", batch.PersonName);
                command.Parameters.AddWithValue("@birthDate", batch.BirthDate);
                command.Parameters.AddWithValue("@employeeNo", batch.EmployeeNo);
                command.Parameters.AddWithValue("@educationLevel", batch.EducationLevel);
                command.Parameters.AddWithValue("@carreerName", batch.CarreerName.Replace("'", "''"));
                command.Parameters.AddWithValue("@personalMail", batch.PersonalMail);
                command.Parameters.AddWithValue("@curp", batch.CURP);
                command.Parameters.AddWithValue("@ine", batch.INE);
                command.Parameters.AddWithValue("@gender", batch.Gender);
                command.Parameters.AddWithValue("@bloodType", batch.Bloodtype);
                command.Parameters.AddWithValue("@maritalStatus", batch.MaritalStatus);
                command.Parameters.AddWithValue("@rfc", batch.RFC);
                command.Parameters.AddWithValue("@phoneNumber", batch.PhoneNumber);
                command.Parameters.AddWithValue("@hsbcAccount", batch.HSBCAccount);
                command.Parameters.AddWithValue("@passportNo", batch.PassportNo);
                command.Parameters.AddWithValue("@usVisaNo", batch.USVisaNo);
                command.Parameters.AddWithValue("@birthState", batch.BirthState);
                command.Parameters.AddWithValue("@infonavitNo", batch.InfonavitAccount);
                command.Parameters.AddWithValue("@passportExpiration", batch.PassportExpiration);
                command.Parameters.AddWithValue("@usVisaExpiration", batch.USVisaExpiration);
                command.Parameters.AddWithValue("@currentAddress", batch.CurrentAddress);
                command.Parameters.AddWithValue("@emerContactRelationship", batch.EmerContactRelationship);
                command.Parameters.AddWithValue("@emerContactName", batch.EmerContactName);
                command.Parameters.AddWithValue("@emerContactPhone", batch.EmerContactPhone);
                command.Parameters.AddWithValue("@department", batch.Department);
                command.Parameters.AddWithValue("@area", batch.Area);
                command.Parameters.AddWithValue("@position", batch.Position);
                command.Parameters.AddWithValue("@paymentType", batch.PaymentType);
                command.Parameters.AddWithValue("@mailAccount", batch.MailAccount);
                command.Parameters.AddWithValue("@bpmAccount", batch.BPMAccount);
                command.Parameters.AddWithValue("@erpAccount", batch.ERPAccount);
                command.Parameters.AddWithValue("@transportation", batch.Transportation);
                command.Parameters.AddWithValue("@pickupColony", batch.PickupColony);
                command.Parameters.AddWithValue("@pickupRoute", batch.PickupRoute);
                command.Parameters.AddWithValue("@userImageRoute", batch.UserImageRoute);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@updateBy", updateBy);
                #endregion

                return command;
            }
            catch (SqlException)
            {
                return command;
            }
        }
    }
}
