﻿namespace Database.Model
{
    public class Personnel
    {
        private string personName;
        private string birthDate;
        private string employeeNo;
        private string educationLevel;
        private string carreerName;
        private string personalMail;
        private string cURP;
        private string iNE;
        private string gender;
        private string bloodtype;
        private string maritalStatus;
        private string rFC;
        private string phoneNumber;
        private string userImageRoute;

        #region GetSet

        public string PersonName { get => personName; set => personName = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public string EmployeeNo { get => employeeNo; set => employeeNo = value; }
        public string EducationLevel { get => educationLevel; set => educationLevel = value; }
        public string CarreerName { get => carreerName; set => carreerName = value; }
        public string PersonalMail { get => personalMail; set => personalMail = value; }
        public string CURP { get => cURP; set => cURP = value; }
        public string INE { get => iNE; set => iNE = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Bloodtype { get => bloodtype; set => bloodtype = value; }
        public string MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public string RFC { get => rFC; set => rFC = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string UserImageRoute { get => userImageRoute; set => userImageRoute = value; }

        #endregion GetSet
    }

    public class SecondaryData
    {
        private string hSBCAccount;
        private string infonavitNo;
        private string passportNo;
        private string passportExpiration;
        private string uSVisaNo;
        private string uSVisaExpiration;
        private string birthState;
        private string currentAddress;
        private string emerContactRelationship;
        private string emerContactName;
        private string emerContactPhone;
        private string iMSSNo;

        #region GetSet

        public string HSBCAccount { get => hSBCAccount; set => hSBCAccount = value; }
        public string InfonavitNo { get => infonavitNo; set => infonavitNo = value; }
        public string PassportNo { get => passportNo; set => passportNo = value; }
        public string PassportExpiration { get => passportExpiration; set => passportExpiration = value; }
        public string USVisaNo { get => uSVisaNo; set => uSVisaNo = value; }
        public string USVisaExpiration { get => uSVisaExpiration; set => uSVisaExpiration = value; }
        public string BirthState { get => birthState; set => birthState = value; }
        public string CurrentAddress { get => currentAddress; set => currentAddress = value; }
        public string EmerContactRelationship { get => emerContactRelationship; set => emerContactRelationship = value; }
        public string EmerContactName { get => emerContactName; set => emerContactName = value; }
        public string EmerContactPhone { get => emerContactPhone; set => emerContactPhone = value; }
        public string IMSSNo { get => iMSSNo; set => iMSSNo = value; }

        #endregion GetSet
    }

    public class DepartmentData
    {
        private string department;
        private string area;
        private string position;
        private string paymentType;
        private string mailAccount;
        private string bPMAccount;
        private string eRPAccount;
        private string transportation;
        private string pickupColony;
        private string pickupRoute;

        #region GetSet

        public string Department { get => department; set => department = value; }
        public string Area { get => area; set => area = value; }
        public string PaymentType { get => paymentType; set => paymentType = value; }
        public string MailAccount { get => mailAccount; set => mailAccount = value; }
        public string BPMAccount { get => bPMAccount; set => bPMAccount = value; }
        public string ERPAccount { get => eRPAccount; set => eRPAccount = value; }
        public string Transportation { get => transportation; set => transportation = value; }
        public string PickupColony { get => pickupColony; set => pickupColony = value; }
        public string PickupRoute { get => pickupRoute; set => pickupRoute = value; }
        public string Position { get => position; set => position = value; }

        #endregion GetSet
    }

    public class Batch
    {
        private string personName;
        private string birthDate;
        private string employeeNo;
        private string educationLevel;
        private string carreerName;
        private string personalMail;
        private string cURP;
        private string iNE;
        private string gender;
        private string bloodtype;
        private string maritalStatus;
        private string rFC;
        private string phoneNumber;
        private string userImageRoute;

        private string hSBCAccount;
        private string infonavitNo;
        private string passportNo;
        private string passportExpiration;
        private string uSVisaNo;
        private string uSVisaExpiration;
        private string birthState;
        private string currentAddress;
        private string emerContactRelationship;
        private string emerContactName;
        private string emerContactPhone;
        private string iMSSNo;

        private string department;
        private string area;
        private string position;
        private string paymentType;
        private string mailAccount;
        private string bPMAccount;
        private string eRPAccount;
        private string transportation;
        private string pickupColony;
        private string pickupRoute;

        #region GetSet

        public string PersonName { get => personName; set => personName = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public string EmployeeNo { get => employeeNo; set => employeeNo = value; }
        public string EducationLevel { get => educationLevel; set => educationLevel = value; }
        public string CarreerName { get => carreerName; set => carreerName = value; }
        public string PersonalMail { get => personalMail; set => personalMail = value; }
        public string CURP { get => cURP; set => cURP = value; }
        public string INE { get => iNE; set => iNE = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Bloodtype { get => bloodtype; set => bloodtype = value; }
        public string MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public string RFC { get => rFC; set => rFC = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string UserImageRoute { get => userImageRoute; set => userImageRoute = value; }
        public string HSBCAccount { get => hSBCAccount; set => hSBCAccount = value; }
        public string InfonavitNo { get => infonavitNo; set => infonavitNo = value; }
        public string PassportNo { get => passportNo; set => passportNo = value; }
        public string PassportExpiration { get => passportExpiration; set => passportExpiration = value; }
        public string USVisaNo { get => uSVisaNo; set => uSVisaNo = value; }
        public string USVisaExpiration { get => uSVisaExpiration; set => uSVisaExpiration = value; }
        public string BirthState { get => birthState; set => birthState = value; }
        public string CurrentAddress { get => currentAddress; set => currentAddress = value; }
        public string EmerContactRelationship { get => emerContactRelationship; set => emerContactRelationship = value; }
        public string EmerContactName { get => emerContactName; set => emerContactName = value; }
        public string EmerContactPhone { get => emerContactPhone; set => emerContactPhone = value; }
        public string IMSSNo { get => iMSSNo; set => iMSSNo = value; }
        public string Department { get => department; set => department = value; }
        public string Area { get => area; set => area = value; }
        public string Position { get => position; set => position = value; }
        public string PaymentType { get => paymentType; set => paymentType = value; }
        public string MailAccount { get => mailAccount; set => mailAccount = value; }
        public string BPMAccount { get => bPMAccount; set => bPMAccount = value; }
        public string ERPAccount { get => eRPAccount; set => eRPAccount = value; }
        public string Transportation { get => transportation; set => transportation = value; }
        public string PickupColony { get => pickupColony; set => pickupColony = value; }
        public string PickupRoute { get => pickupRoute; set => pickupRoute = value; }

        #endregion GetSet
    }

    public class LoginObject
    {
        private string userName;
        private string userPassword;

        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
    }
}