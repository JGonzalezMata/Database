using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Model;

namespace Database.View
{
    public partial class Form4 : Form
    {
        private Personnel _personnel;
        private SecondaryData _secondaryData;
        private DepartmentData _departmentData;
        public Form4(Form3 f3, Personnel getPersonnel, SecondaryData getSecondaryData)
        {
            InitializeComponent();
            f3.Close();
            _personnel = new Personnel();
            _secondaryData = new SecondaryData();
            _departmentData = new DepartmentData();
            _personnel = getPersonnel;
            _secondaryData = getSecondaryData;
        }
        #region Buttons
        private void btnNext_Click(object sender, EventArgs e)
        {
            InputAllIntoBatch(_personnel, _secondaryData);
            Form1.checkIfAlreadyEnter = 1;
            this.Close();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _personnel = null;
            _secondaryData = null;
            _departmentData = null;
            this.Close();
        }
        #endregion

        #region Methods

        private void InputAllIntoBatch(Personnel personnel, SecondaryData secondaryData)
        {
            var _batch = new Batch
            {
                #region Batch
                PersonName = personnel.PersonName,
                BirthDate = personnel.BirthDate,
                EmployeeNo = personnel.EmployeeNo,
                EducationLevel = personnel.EducationLevel,
                CarreerName = personnel.CarreerName,
                PersonalMail = personnel.PersonalMail,
                CURP = personnel.CURP,
                INE = personnel.INE,
                Gender = personnel.Gender,
                Bloodtype = personnel.Bloodtype,
                MaritalStatus = personnel.MaritalStatus,
                RFC = personnel.RFC,
                PhoneNumber = personnel.PhoneNumber,
                UserImageRoute = personnel.UserImageRoute,

                HSBCAccount = secondaryData.HSBCAccount,
                InfonavitNo = secondaryData.InfonavitNo,
                PassportNo = secondaryData.PassportNo,
                PassportExpiration = secondaryData.PassportExpiration,
                USVisaNo = secondaryData.USVisaNo,
                USVisaExpiration = secondaryData.USVisaExpiration,
                BirthState = secondaryData.BirthState,
                CurrentAddress = secondaryData.CurrentAddress,
                EmerContactRelationship = secondaryData.EmerContactRelationship,
                EmerContactName = secondaryData.EmerContactName,
                EmerContactPhone = secondaryData.EmerContactPhone,
                IMSSNo = secondaryData.IMSSNo,

                Department = txtDepartment.Text,
                Area = txtArea.Text,
                Position = txtPosition.Text,
                PaymentType = txtPayment.Text,
                MailAccount = txtCompanyMail.Text,
                BPMAccount = txtBPMAcc.Text,
                ERPAccount = txtERPAcc.Text,
                Transportation = cmbTransportation.SelectedItem.ToString(),
                PickupColony = txtPickupColony.Text,
                PickupRoute = txtRoute.Text, 
                #endregion
            };

            Form1.batch = _batch;
        }

        private string FillMail(string mailName)
        {
            if (!mailName.Contains("@xinpoint.com"))
            {
                return mailName + "@xinpoint.com"; 
            }
            else
            {
                return mailName;
            }
        }

        private string GetBPMAccount(string companyMail)
        {
            if (companyMail.Contains("@xinpoint.com"))
            {
                var replaced = companyMail.Replace("@xinpoint.com", "");
                return replaced;
            }
            else
            {
                return companyMail;
            }
        }
        #endregion

        #region Events
        private void cmbTransportation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransportation.SelectedItem.ToString() == "Company")
            {
                txtPickupColony.Enabled = true;
                txtRoute.Enabled = true;
            }
            else
            {
                txtPickupColony.Enabled = false;
                txtRoute.Enabled = false;
            }
        }

        private void txtCompanyMail_TextChanged(object sender, EventArgs e)
        {
            txtBPMAcc.Text = GetBPMAccount(txtCompanyMail.Text);
        }

        private void txtCompanyMail_Leave(object sender, EventArgs e)
        {
            txtCompanyMail.Text = FillMail(txtCompanyMail.Text);
        }
        #endregion


    }
}
