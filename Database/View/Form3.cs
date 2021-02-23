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
        private List<Personnel> _personnel;
        private List<SecondaryData> _secondaryData;
        public Form3(Form2 f2, List<Personnel> _GetPersonnel)
        {
            InitializeComponent();
            f2.Close();
            _personnel = new List<Personnel>();
            _secondaryData = new List<SecondaryData>();
            _personnel = _GetPersonnel;
            DTP();
        }

        #region Buttons

        private void btnNext_Click(object sender, EventArgs e)
        {
            //DataBind();
            Form4 f4 = new Form4(this, _personnel, _secondaryData);
            f4.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _personnel.Clear();
            _secondaryData.Clear();
            this.Close();
        }

        #endregion

        #region Events

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
            var _secData = new SecondaryData()
            {
                HSBCAccount = txtHSBC.Text,
                PassportNo = txtPassport.Text,
                USVisa = txtUSVISA.Text,
                BirthState = txtBirthState.Text,
                InfonativAccount = txtInfonavit.Text,
                PassportExpiration = dtpPassportExp.Value.ToString("MM/yyyy"),
                VisaExpiration = dtpVisaExp.Value.ToString("MM/yyyy"),
                CurrentAddress = txtCurrentAddress.Text,
                EmerContactRelationship = cmbEmerContactRelation.SelectedItem.ToString(),
                EmerContactName = txtEmerName.Text,
                EmerPhoneNumber = txtEmerNumb.Text
            };

            _secondaryData.Add(_secData);
        }
        #endregion
    }
}
