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
using Database.Controller;

namespace Database.View
{
    public partial class Form2 : Form
    {
        #region Declare
        private List<Personnel> _personnel;
        private PrimDataVal _validate;
        #endregion

        public Form2()
        {
            InitializeComponent();
            _personnel = new List<Personnel>();
            _validate = new PrimDataVal();
        }

        #region Buttons
        private void btnNext_Click(object sender, EventArgs e)
        {
            //DataBind();
            Form3 f3 = new Form3(this, _personnel);
            f3.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _personnel.Clear();
            this.Close();
        }

        #endregion

        #region Methods

        private void DataBind()
        {
            var _primData = new Personnel
            {
                Name = txtUsrName.Text,
                BirthDate = dtpBirthDate.Value.ToString("dd/MM/yyyy"),
                EmployeeNo = txtEmployeeNo.Text,
                EducationLevel = cmbEducation.SelectedItem.ToString(),
                Carreer = txtCarreer.Text,
                PersonalMail = txtPerEmail.Text,
                CURP = txtCURP.Text,
                INE = txtINE.Text,
                Gender = cmbGender.SelectedItem.ToString(),
                Bloodtype = cmbBloodtype.SelectedItem.ToString(),
                MaritalStatus = cmbMaritalStatus.SelectedItem.ToString(),
                RFC = txtRFC.Text,
                PhoneNumber = txtPhoneNumber.Text
            };

            _personnel.Add(_primData);
        }

        #endregion

        #region Events
        private void cmbEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEducation.SelectedItem == "Licenciature" || cmbEducation.SelectedItem == "Engineering" || cmbEducation.SelectedItem == "Master's Degree" || cmbEducation.SelectedItem == "Doctorate")
            {
                txtCarreer.Enabled = true;
            }
            else
            {
                txtCarreer.Enabled = false;
            }
        }

        private void txtEmployeeNo_Leave(object sender, EventArgs e)
        {
            txtEmployeeNo.Text = _validate.GenerateEmployeeNomber(txtEmployeeNo.Text);
        }

        #endregion
    }
}
