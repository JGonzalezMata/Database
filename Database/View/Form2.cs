using Database.Controller;
using Database.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace Database.View
{
    public partial class Form2 : Form
    {
        #region Declare

        private Personnel _personnel;
        private readonly PrimDataVal _validate;
        private OpenFileDialog imageRouteDialog;
        private FileStream fileStream;
        private string ImageRoute = "";

        #endregion Declare

        public Form2()
        {
            InitializeComponent();
            _personnel = new Personnel();
            _validate = new PrimDataVal();
        }

        #region Buttons

        private void btnNext_Click(object sender, EventArgs e)
        {
            DataBind();
            Form3 f3 = new Form3(this, _personnel);
            f3.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _personnel = null;
            this.Close();
        }

        #endregion Buttons

        #region Methods

        private void DataBind()
        {
            var primData = new Personnel
            {
                PersonName = txtUsrName.Text,
                BirthDate = dtpBirthDate.Value.ToString("dd/MM/yyyy"),
                EmployeeNo = txtEmployeeNo.Text,
                EducationLevel = cmbEducation.SelectedItem.ToString(),
                CarreerName = txtCarreer.Text,
                PersonalMail = txtPerEmail.Text,
                CURP = txtCURP.Text,
                INE = txtINE.Text,
                Gender = cmbGender.SelectedItem.ToString(),
                Bloodtype = cmbBloodtype.SelectedItem.ToString(),
                MaritalStatus = cmbMaritalStatus.SelectedItem.ToString(),
                RFC = txtRFC.Text,
                PhoneNumber = txtPhoneNumber.Text,
                UserImageRoute = ImageRoute
            };

            _personnel = primData;
        }

        private void ImageLoader()
        {
            imageRouteDialog = new OpenFileDialog();
            imageRouteDialog.Filter = "Image files (*.jpg)|*.jpg";
            imageRouteDialog.Title = "Pick employee image";
            imageRouteDialog.ShowDialog();
            try
            {
                if (!String.IsNullOrEmpty(imageRouteDialog.FileName))
                {
                    fileStream = File.OpenRead(imageRouteDialog.FileName);
                    if (fileStream.Length <= 5120000)
                    {
                        pictureBox1.ImageLocation = imageRouteDialog.FileName;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        ImageRoute = imageRouteDialog.FileName;
                        imageRouteDialog.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods

        #region Events

        private void cmbEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEducation.SelectedItem.ToString() == "Licenciature" || cmbEducation.SelectedItem.ToString() == "Engineering" || cmbEducation.SelectedItem.ToString() == "Master's Degree" || cmbEducation.SelectedItem.ToString() == "Doctorate")
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ImageLoader();
        }

        #endregion Events
    }
}