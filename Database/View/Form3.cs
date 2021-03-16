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
    public partial class Form3 : Form
    {
        private Personnel _personnel;
        private SecondaryData _secondaryData;
        public Form3(Form2 f2, Personnel getPersonnel)
        {
            InitializeComponent();
            f2.Close();
            _personnel = new Personnel();
            _secondaryData = new SecondaryData();
            _personnel = getPersonnel;
            DTP();
        }

        #region Buttons

        private void btnNext_Click(object sender, EventArgs e)
        {
            DataBind();
            Form4 f4 = new Form4(this, _personnel, _secondaryData);
            f4.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _personnel = null;
            _secondaryData = null;
            this.Close();
        }

        #endregion

        #region Events
        private void txtPassport_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPassport.Text))
            {
                dtpPassportExp.Enabled = true;
            }
            else
            {
                dtpPassportExp.Enabled = false;
            }
        }

        private void txtUSVISA_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUSVISA.Text))
            {
                dtpVisaExp.Enabled = true;
            }
            else
            {
                dtpVisaExp.Enabled = false;
            }
        }
        #endregion

        #region Methods

        private void DTP() //Customize Datetimepicker values
        {
            dtpPassportExp.Format = DateTimePickerFormat.Custom;
            dtpPassportExp.MinDate = new DateTime(2000, 1, 1);
            dtpPassportExp.MaxDate = new DateTime(2050, 1, 1);
            dtpPassportExp.CustomFormat = "MMMM yyyy";
            dtpPassportExp.ShowUpDown = true;

            dtpVisaExp.Format = DateTimePickerFormat.Custom;
            dtpVisaExp.MinDate = new DateTime(2000, 1, 1);
            dtpVisaExp.MaxDate = new DateTime(2050, 1, 1);
            dtpVisaExp.CustomFormat = "MMMM yyyy";
            dtpVisaExp.ShowUpDown = true;
        }

        private void DataBind()
        {
            var getPassportExpiration = "";
            var getVisaExpiration = "";
            if(dtpPassportExp.Enabled) getPassportExpiration = dtpPassportExp.Value.ToString("MM/yyyy");
            if(dtpVisaExp.Enabled) getVisaExpiration = dtpVisaExp.Value.ToString("MM/yyyy");
            var secData = new SecondaryData()
            {
                HSBCAccount = txtHSBC.Text,
                PassportNo = txtPassport.Text,
                USVisaNo = txtUSVISA.Text,
                BirthState = txtBirthState.Text,
                InfonavitNo = txtInfonavit.Text,
                PassportExpiration = getPassportExpiration,
                USVisaExpiration  = getVisaExpiration,
                CurrentAddress = txtCurrentAddress.Text,
                EmerContactRelationship = cmbEmerContactRelation.SelectedItem.ToString(),
                EmerContactName = txtEmerName.Text,
                EmerContactPhone = txtEmerNumb.Text,
                IMSSNo = txtIMSS.Text
            };

            _secondaryData = secData;
        }
        #endregion
    }
}
