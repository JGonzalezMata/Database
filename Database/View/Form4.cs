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
        private List<Personnel> _personnel;
        private List<SecondaryData> _secondaryData;
        private List<DepartmentData> _departmentData;
        public Form4(Form3 f3, List<Personnel> getPersonnel, List<SecondaryData> getSecondaryData)
        {
            InitializeComponent();
            f3.Close();
            _personnel = new List<Personnel>();
            _secondaryData = new List<SecondaryData>();
            _departmentData = new List<DepartmentData>();
            _personnel = getPersonnel;
            _secondaryData = getSecondaryData;
        }
        #region Buttons
        private void btnNext_Click(object sender, EventArgs e)
        {
            DataBind();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _personnel.Clear();
            _secondaryData.Clear();
            _departmentData.Clear();
            this.Close();
        }
        #endregion

        #region Methods

        private void DataBind()
        {
            var depData = new DepartmentData()
            {
                Department = txtDepartment.Text,
                Area = txtArea.Text,
                Position = txtPosition.Text,
                PaymentType = txtPayment.Text,
                MailAccount = txtCompanyMail.Text,
                BPMAccount = txtBPMAcc.Text,
                ERPAccount = txtERPAcc.Text,
                Transportation = cmbTransportation.Text,
                PickupColony = txtPickupColony.Text,
                Route = txtRoute.Text
            };
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

        #endregion
    }
}
