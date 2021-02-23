namespace Database.Model
{
    public class Personnel
    {
        private string name;
        private string birthDate;
        private string employeeNo;
        private string educationLevel;
        private string carreer;
        private string personalMail;
        private string cURP;
        private string iNE;
        private string gender;
        private string bloodtype;
        private string maritalStatus;
        private string rFC;
        private string phoneNumber;

        #region GetSet
        public string Name { get => name; set => name = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public string EmployeeNo { get => employeeNo; set => employeeNo = value; }
        public string EducationLevel { get => educationLevel; set => educationLevel = value; }
        public string Carreer { get => carreer; set => carreer = value; }
        public string PersonalMail { get => personalMail; set => personalMail = value; }
        public string CURP { get => cURP; set => cURP = value; }
        public string INE { get => iNE; set => iNE = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Bloodtype { get => bloodtype; set => bloodtype = value; }
        public string MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public string RFC { get => rFC; set => rFC = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        #endregion
    }

    public class SecondaryData
    {
        private string hSBCAccount;
        private string infonativAccount;
        private string passportNo;
        private string passportExpiration;
        private string uSVisa;
        private string visaExpiration;
        private string birthState;
        private string currentAddress;
        private string emerContactRelationship;
        private string emerContactName;
        private string emerPhoneNumber;

        #region GetSet
        public string HSBCAccount { get => hSBCAccount; set => hSBCAccount = value; }
        public string InfonativAccount { get => infonativAccount; set => infonativAccount = value; }
        public string PassportNo { get => passportNo; set => passportNo = value; }
        public string PassportExpiration { get => passportExpiration; set => passportExpiration = value; }
        public string USVisa { get => uSVisa; set => uSVisa = value; }
        public string VisaExpiration { get => visaExpiration; set => visaExpiration = value; }
        public string BirthState { get => birthState; set => birthState = value; }
        public string CurrentAddress { get => currentAddress; set => currentAddress = value; }
        public string EmerContactRelationship { get => emerContactRelationship; set => emerContactRelationship = value; }
        public string EmerContactName { get => emerContactName; set => emerContactName = value; }
        public string EmerPhoneNumber { get => emerPhoneNumber; set => emerPhoneNumber = value; }
        #endregion
    }

    public class DepartmentData
    {
        private string department;
        private string area;
        private string paymentType;
        private string mailAccount;
        private string bPMAccount;
        private string eRPAccount;
        private string transportation;
        private string pickupColony;
        private string route;

        #region GetSet
        public string Department { get => department; set => department = value; }
        public string Area { get => area; set => area = value; }
        public string PaymentType { get => paymentType; set => paymentType = value; }
        public string MailAccount { get => mailAccount; set => mailAccount = value; }
        public string BPMAccount { get => bPMAccount; set => bPMAccount = value; }
        public string ERPAccount { get => eRPAccount; set => eRPAccount = value; }
        public string Transportation { get => transportation; set => transportation = value; }
        public string PickupColony { get => pickupColony; set => pickupColony = value; }
        public string Route { get => route; set => route = value; }
        #endregion
    }
}
