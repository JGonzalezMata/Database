using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConnectionFramework
{
    public class ConnectionManager
    {
        private string connectionString;

        public ConnectionManager(string user, string password, string database)
        {
            connectionString = $"Server=DESKTOP-1BQ9MH1\\TestServer;Database={database};User Id={user};Password={password};";
        }

        #region Sql Process

        public async Task<string> CreateAndUpdate(string jsonObject, string createdBy)
        {
            var cmdText = "execute DataManager @personName, @birthDate, @employeeNo, @educationLevel, @carreerName," +
                " @personalMail, @curp, @ine, @gender, @bloodType, @maritalStatus, @rfc, @phoneNumber," +
                " @hsbcAccount, @passportNo, @usVisaNo, @birthState, @infonavitNo, @passportExpiration," +
                " @usVisaExpiration, @currentAddress, @emerContactRelationship," +
                " @emerContactName, @emerContactPhone, @imssNo, @department, @area, @position, @paymentType," +
                " @mailAccount, @bpmAccount, @erpAccount, @transportation, @pickupColony, @pickupRoute," +
                " @userImageRoute, @createdBy, @updatedBy";
            try
            {
                var deserializedObject = JsonConvert.DeserializeObject<List<BatchObject>>(jsonObject);
                foreach (var item in deserializedObject)
                {
                    using (var dbConn = new SqlConnection(connectionString))
                    using (var command = BatchAddWithValue(cmdText, dbConn, item, createdBy, createdBy))
                    {
                        dbConn.Open();
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

        public async Task<string> UpdatePerRow(string jsonObject, string updatedBy)
        {
            var cmdText = "exec uspUpdateCell @Column , @Value , @EmployeeNo , @UpdatedBy";
            try
            {
                dynamic deserializedObject = JsonConvert.DeserializeObject(jsonObject);
                using (var dbConn = new SqlConnection(connectionString))
                using (var command = new SqlCommand(cmdText, dbConn))
                {
                    command.Parameters.Add("@Column", SqlDbType.VarChar).Value = deserializedObject["Column"];
                    command.Parameters.Add("@Value", SqlDbType.VarChar).Value = deserializedObject["Value"];
                    command.Parameters.Add("@EmployeeNo", SqlDbType.VarChar).Value = deserializedObject["EmployeeNo"];
                    command.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = updatedBy;
                    dbConn.Open();
                    await command.ExecuteNonQueryAsync();
                }
                return true.ToString();
            }
            catch (SqlException exception)
            {
                return exception.Message;
            }
        }

        public async Task<string> DeleteValue(string jsonObject, string deletedBy)
        {
            var cmdText = $"exec uspDeleteRecord @userId , @deletedBy";
            try
            {
                dynamic deserializedObject = JsonConvert.DeserializeObject(jsonObject);
                using (var dbConn = new SqlConnection(connectionString))
                using (var command = new SqlCommand(cmdText, dbConn))
                {
                    command.Parameters.Add("@userId", SqlDbType.VarChar, 255).Value = deserializedObject["EmployeeNo"].Value;
                    command.Parameters.Add("@deletedBy", SqlDbType.VarChar, 255).Value = deletedBy;
                    dbConn.Open();
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
            var cmdText = $"exec uspGetEmployees";
            try
            {
                return Task.Run(() =>
                {
                    using (var dbConn = new SqlConnection(connectionString))
                    using (var query = new SqlDataAdapter(cmdText, dbConn))
                    {
                        dbConn.Open();
                        query.Fill(dataSet);
                        return dataSet;
                    }
                });
            }
            catch (SqlException exception)
            {
                return (Task<DataSet>)Task.Run(() => { Console.WriteLine(exception.Message); });
            }
        }

        public bool LoginQuery(string jsonObject)
        {
            var cmdText = $"exec uspGetLoginCheck @UserName , @Password";
            try
            {
                dynamic deserializedObject = JsonConvert.DeserializeObject(jsonObject);
                using (var dbConn = new SqlConnection(connectionString))
                using (var command = new SqlCommand(cmdText, dbConn))
                {
                    command.Parameters.Add("@UserName", SqlDbType.VarChar, 255).Value = deserializedObject["UserName"].Value;
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 255).Value = deserializedObject["UserPassword"].Value;
                    dbConn.Open();
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

        #endregion Sql Process

        public SqlCommand BatchAddWithValue(string cmdText, SqlConnection databaseConnection, BatchObject batch, string createdBy, string updateBy)

        {
            var command = new SqlCommand(cmdText, databaseConnection);
            try
            {
                #region Mucho texto 2

                command.Parameters.Add("@personName", SqlDbType.VarChar, 255).Value = batch.PersonName;
                command.Parameters.Add("@birthDate", SqlDbType.VarChar, 255).Value = batch.BirthDate;
                command.Parameters.Add("@employeeNo", SqlDbType.VarChar, 255).Value = batch.EmployeeNo;
                command.Parameters.Add("@educationLevel", SqlDbType.VarChar, 255).Value = batch.EducationLevel;
                command.Parameters.Add("@carreerName", SqlDbType.VarChar, 255).Value = batch.CarreerName;
                command.Parameters.Add("@personalMail", SqlDbType.VarChar, 255).Value = batch.PersonalMail;
                command.Parameters.Add("@curp", SqlDbType.VarChar, 255).Value = batch.CURP;
                command.Parameters.Add("@ine", SqlDbType.VarChar, 255).Value = batch.INE;
                command.Parameters.Add("@gender", SqlDbType.VarChar, 255).Value = batch.Gender;
                command.Parameters.Add("@bloodType", SqlDbType.VarChar, 255).Value = batch.Bloodtype;
                command.Parameters.Add("@maritalStatus", SqlDbType.VarChar, 255).Value = batch.MaritalStatus;
                command.Parameters.Add("@rfc", SqlDbType.VarChar, 255).Value = batch.RFC;
                command.Parameters.Add("@phoneNumber", SqlDbType.VarChar, 255).Value = batch.PhoneNumber;
                command.Parameters.Add("@hsbcAccount", SqlDbType.VarChar, 255).Value = batch.HSBCAccount;
                command.Parameters.Add("@passportNo", SqlDbType.VarChar, 255).Value = batch.PassportNo;
                command.Parameters.Add("@usVisaNo", SqlDbType.VarChar, 255).Value = batch.USVisaNo;
                command.Parameters.Add("@birthState", SqlDbType.VarChar, 255).Value = batch.BirthState;
                command.Parameters.Add("@infonavitNo", SqlDbType.VarChar, 255).Value = batch.InfonavitNo;
                command.Parameters.Add("@passportExpiration", SqlDbType.VarChar, 255).Value = batch.PassportExpiration;
                command.Parameters.Add("@usVisaExpiration", SqlDbType.VarChar, 255).Value = batch.USVisaExpiration;
                command.Parameters.Add("@currentAddress", SqlDbType.VarChar, 255).Value = batch.CurrentAddress;
                command.Parameters.Add("@emerContactRelationship", SqlDbType.VarChar, 255).Value = batch.EmerContactRelationship;
                command.Parameters.Add("@emerContactName", SqlDbType.VarChar, 255).Value = batch.EmerContactName;
                command.Parameters.Add("@emerContactPhone", SqlDbType.VarChar, 255).Value = batch.EmerContactPhone;
                command.Parameters.Add("@imssNo", SqlDbType.VarChar, 255).Value = batch.IMSSNo;
                command.Parameters.Add("@department", SqlDbType.VarChar, 255).Value = batch.Department;
                command.Parameters.Add("@area", SqlDbType.VarChar, 255).Value = batch.Area;
                command.Parameters.Add("@position", SqlDbType.VarChar, 255).Value = batch.Position;
                command.Parameters.Add("@paymentType", SqlDbType.VarChar, 255).Value = batch.PaymentType;
                command.Parameters.Add("@mailAccount", SqlDbType.VarChar, 255).Value = batch.MailAccount;
                command.Parameters.Add("@bpmAccount", SqlDbType.VarChar, 255).Value = batch.BPMAccount;
                command.Parameters.Add("@erpAccount", SqlDbType.VarChar, 255).Value = batch.ERPAccount;
                command.Parameters.Add("@transportation", SqlDbType.VarChar, 255).Value = batch.Transportation;
                command.Parameters.Add("@pickupColony", SqlDbType.VarChar, 255).Value = batch.PickupColony;
                command.Parameters.Add("@pickupRoute", SqlDbType.VarChar, 255).Value = batch.PickupRoute;
                command.Parameters.Add("@userImageRoute", SqlDbType.VarChar, 255).Value = batch.UserImageRoute;
                command.Parameters.Add("@createdBy", SqlDbType.VarChar, 255).Value = createdBy;
                command.Parameters.Add("@updatedBy", SqlDbType.VarChar, 255).Value = createdBy;

                #endregion Mucho texto 2

                return command;
            }
            catch (SqlException)
            {
                return command;
            }
        }
    }
}