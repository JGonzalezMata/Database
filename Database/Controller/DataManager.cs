using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Database.Model;

namespace Database.Controller
{
    public class DataManager
    {
        #region Insert Values
        public void InsertNewValue(List<Personnel> personnel, List<SecondaryData> secondaryData, List<DepartmentData> departmentData)
        {
            if (!personnel.Any() && !secondaryData.Any() && !departmentData.Any())
            {
                //TODO: Fill with インサート ~Insâto~ parameters
            }
        }

        public void UpdateValue(List<Personnel> personnel)
        {
            //TODO: Fill with 修正 ~Shûsei~ parameters
        }
        #endregion

        #region Delete Values
        public void DeleteValue(List<Personnel> personnel)
        {
            //TODO: Fill with デリート ~Delîto~ parameters
        }
        #endregion

        #region Get Values
        public Tuple<List<Personnel>, List<SecondaryData>, List<DepartmentData>> GetPersonnels()
        {
            var personnel = new List<Personnel>();
            var departmentData = new List<DepartmentData>();
            var secondaryData = new List<SecondaryData>();

            DataSet ds = new DataSet(); //TODO: Replace this shit with the actual query
            var dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                var _personnel = new Personnel { Name = dr.Table.Rows[1].ToString(), BirthDate = dr.Table.Rows[1].ToString(), EmployeeNo = dr.Table.Rows[1].ToString(), EducationLevel = dr.Table.Rows[1].ToString(), Carreer = dr.Table.Rows[1].ToString(), PersonalMail = dr.Table.Rows[1].ToString(), CURP = dr.Table.Rows[1].ToString(), INE = dr.Table.Rows[1].ToString(), Gender = dr.Table.Rows[1].ToString(), Bloodtype = dr.Table.Rows[1].ToString(), MaritalStatus = dr.Table.Rows[1].ToString(), RFC = dr.Table.Rows[1].ToString(), PhoneNumber = dr.Table.Rows[1].ToString()};
                var _secondaryData = new SecondaryData { HSBCAccount = dr.Table.Rows[1].ToString(), PassportNo = dr.Table.Rows[1].ToString(),  USVisa = dr.Table.Rows[1].ToString(), BirthState = dr.Table.Rows[1].ToString(), InfonativAccount = dr.Table.Rows[1].ToString(), PassportExpiration = dr.Table.Rows[1].ToString(), VisaExpiration = dr.Table.Rows[1].ToString(), CurrentAddress = dr.Table.Rows[1].ToString(), EmerContactRelationship = dr.Table.Rows[1].ToString(), EmerContactName = dr.Table.Rows[1].ToString(), EmerPhoneNumber = dr.Table.Rows[1].ToString()};
                var _departmentData = new DepartmentData { Department = dr.Table.Rows[1].ToString(), Area = dr.Table.Rows[1].ToString(), PaymentType = dr.Table.Rows[1].ToString(), MailAccount = dr.Table.Rows[1].ToString(), BPMAccount = dr.Table.Rows[1].ToString(), ERPAccount = dr.Table.Rows[1].ToString(), Transportation = dr.Table.Rows[1].ToString(), PickupColony = dr.Table.Rows[1].ToString(), Route = dr.Table.Rows[1].ToString()};

                personnel.Add(_personnel);
                secondaryData.Add(_secondaryData);
                departmentData.Add(_departmentData);
            }

            return Tuple.Create(personnel, secondaryData, departmentData);
        }
        #endregion
    }
}
