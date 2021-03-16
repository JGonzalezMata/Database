using ConnectionFramework;
using Database.Model;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Database.Controller
{
    public class DataManager
    {
        private ConnectionManager dataManager = new ConnectionManager("Tester", "Abcd1234", "Information");

        #region Insert Values

        public async Task<string> InsertNewValue(string jsonObject, string userName)
        {
            if (!string.IsNullOrEmpty(jsonObject))
            {
                return await dataManager.CreateAndUpdate(jsonObject, userName);
            }
            else
            {
                return "You cannot send empty info";
            }
        }

        #endregion Insert Values

        #region Delete Values

        public async Task<string> DeleteValue(string jsonObject, string userName)
        {
            if (!string.IsNullOrEmpty(jsonObject))
            {
                return await dataManager.DeleteValue(jsonObject, userName);
            }
            else
            {
                return "A field to delete must be selected";
            }
        }

        public bool LoginCheck(string jsonObject)
        {
            if (!string.IsNullOrEmpty(jsonObject))
            {
                return dataManager.LoginQuery(jsonObject);
            }
            else
            {
                return false;
            }
        }

        public async Task<string> UpdateIndividualRow(string jsonObject, string updatedBy)
        {
            return await dataManager.UpdatePerRow(jsonObject, updatedBy);
        }

        #endregion Delete Values

        #region Get Values

        public List<Batch> GetPersonnels()
        {
            var batch = new List<Batch>();

            DataSet ds = dataManager.GetAllData().Result;
            var dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                var _batchElement = new Batch
                {
                    PersonName = dr["personName"].ToString(),
                    BirthDate = dr["birthDate"].ToString(),
                    EmployeeNo = dr["employeeNo"].ToString(),
                    EducationLevel = dr["educationLevel"].ToString(),
                    CarreerName = dr["carreerName"].ToString(),
                    PersonalMail = dr["personalMail"].ToString(),
                    CURP = dr["curp"].ToString(),
                    INE = dr["ine"].ToString(),
                    Gender = dr["gender"].ToString(),
                    Bloodtype = dr["bloodType"].ToString(),
                    MaritalStatus = dr["maritalStatus"].ToString(),
                    RFC = dr["rfc"].ToString(),
                    PhoneNumber = dr["phoneNumber"].ToString(),
                    UserImageRoute = dr["userImageRoute"].ToString(),
                    HSBCAccount = dr["hsbcAccount"].ToString(),
                    PassportNo = dr["passportNo"].ToString(),
                    USVisaNo = dr["usVisaNo"].ToString(),
                    BirthState = dr["birthState"].ToString(),
                    InfonavitNo = dr["infonavitNo"].ToString(),
                    PassportExpiration = dr["passportExpiration"].ToString(),
                    USVisaExpiration = dr["usVisaExpiration"].ToString(),
                    CurrentAddress = dr["currentAddress"].ToString(),
                    EmerContactRelationship = dr["emerContactRelationship"].ToString(),
                    EmerContactName = dr["emerContactName"].ToString(),
                    EmerContactPhone = dr["emerContactPhone"].ToString(),
                    IMSSNo = dr["imssNo"].ToString(),
                    Department = dr["department"].ToString(),
                    Area = dr["area"].ToString(),
                    Position = dr["position"].ToString(),
                    PaymentType = dr["paymentType"].ToString(),
                    MailAccount = dr["mailAccount"].ToString(),
                    BPMAccount = dr["bpmAccount"].ToString(),
                    ERPAccount = dr["erpAccount"].ToString(),
                    Transportation = dr["transportation"].ToString(),
                    PickupColony = dr["pickupColony"].ToString(),
                    PickupRoute = dr["pickupRoute"].ToString()
                };

                batch.Add(_batchElement);
            }

            return batch;
        }

        #endregion Get Values
    }
}