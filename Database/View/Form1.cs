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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Database.Controller;
using System.Reflection;

namespace Database
{
    public partial class Form1 : Form
    {
        #region Global variables
        public DataManager dataManager;
        public static Batch batch;
        public Batch _existingRecords;
        public static int checkIfAlreadyEnter = 0;
        List<Batch> batchList;
        List<Batch> existingEntries;
        string userName;
        string employeeNo;
        ContextMenu contextMenu;
        MenuItem deleteItem;
        MenuItem sendToBatch;
        GeneralManager generalManager;
        #endregion
        public Form1()
        {
            InitializeComponent();
            batch = new Batch();
            batchList = new List<Batch>();            
            dataManager = new DataManager();
            contextMenu = new ContextMenu();
            generalManager = new GeneralManager();
            deleteItem = contextMenu.MenuItems.Add("Delete");
            deleteItem.Click += DeleteItem_Click;
            sendToBatch = contextMenu.MenuItems.Add("Send to card");
            sendToBatch.Click += SendToBatch_Click;
            existingEntries = new List<Batch>(dataManager.GetPersonnels());
            //TestingInfo();
            FillDataGrid(dgvExistingRecords,existingEntries);
            //FillDataGrid(dgvUsers, batchList);
        }

        protected override void OnLoad(EventArgs e)
        {
            Login();
        }

        private void btnCrtNew_Click(object sender, EventArgs e)
        {
            CallWindow();
        }

        #region Events

        private async void dgvExistingRecords_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dgvExistingRecords.Columns[e.ColumnIndex].Name;
            var jObject = new JObject();
            

            if (columnName != "EmployeeNo" && MessageBox.Show("Do you wish to update this field?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var employeeNumber = dgvExistingRecords.Rows[e.RowIndex].Cells["employeeNo"].Value.ToString();
                var columnNewValue = dgvExistingRecords.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (String.IsNullOrEmpty(columnNewValue)) columnNewValue = "";
                jObject["Column"] = columnName;
                jObject["Value"] = columnNewValue;
                jObject["EmployeeNo"] = employeeNumber;

                if (await dataManager.UpdateIndividualRow(jObject.ToString(), userName) == true.ToString())
                {
                    MessageBox.Show("Row updated successfully");
                }
                RefillRecords();
            }
        }

        private void dgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dgvUsers.Columns[e.ColumnIndex].Name;

            if (columnName != "EmployeeNo" && MessageBox.Show("Do you wish to update this field?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var employeeNumber = dgvUsers.Rows[e.RowIndex].Cells["employeeNo"].Value.ToString();
                var columnNewValue = dgvUsers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                LocalUpdateRow(columnName, columnNewValue, employeeNumber);
            }
        }

        private void dgvUsers_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    var gridIndex = dgvUsers.HitTest(e.X, e.Y).RowIndex;
                    this.dgvUsers.Rows[gridIndex].Cells["EmployeeNo"].ReadOnly = true;
                }
                if (e.Button == MouseButtons.Right)
                {
                    var gridIndex = dgvUsers.HitTest(e.X, e.Y).RowIndex;

                    if (gridIndex >= 0)
                    {
                        employeeNo = dgvExistingRecords.Rows[gridIndex].Cells["EmployeeNo"].Value.ToString();
                        contextMenu.Show(dgvUsers, new Point(e.X, e.Y));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvExistingRecords_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    var gridIndex = dgvExistingRecords.HitTest(e.X, e.Y).RowIndex;
                    this.dgvExistingRecords.Rows[gridIndex].Cells["EmployeeNo"].ReadOnly = true;
                }
                if (e.Button == MouseButtons.Right)
                {
                    var gridIndex = dgvExistingRecords.HitTest(e.X, e.Y).RowIndex;
                    if (gridIndex >= 0)
                    {
                        employeeNo = dgvExistingRecords.Rows[gridIndex].Cells["EmployeeNo"].Value.ToString();
                        contextMenu.Show(dgvExistingRecords, new Point(e.X, e.Y));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (checkIfAlreadyEnter > 0)
            {
                batchList.Add(batch);
                FillDataGrid(dgvUsers, batchList);
                checkIfAlreadyEnter = 0;
                tabControl1.SelectTab(tbpBatchUsers);
            }
        }

        private async void btnSvNew_Click(object sender, EventArgs e)
        {
            await SaveAll();
        }

        private async void btnCrtCards_Click(object sender, EventArgs e)
        {
            await SaveAll();
            generalManager.CreateCard(batchList);
        }

        private void SendToBatch_Click(object sender, EventArgs e)
        {
            var getElement = existingEntries.Find(item => item.EmployeeNo == employeeNo);
            batchList.Add(getElement);
            FillDataGrid(dgvUsers, batchList);
        }

        private async void DeleteItem_Click(object sender, EventArgs e)
        {
            var jObject = new JObject();
            jObject["EmployeeNo"] = employeeNo;

            if (await dataManager.DeleteValue(jObject.ToString(), userName) == true.ToString())
            {
                MessageBox.Show("Employee deleted sucessfully");
                FillDataGrid(dgvExistingRecords, dataManager.GetPersonnels());
                tabControl1.SelectTab(tbpExistingRecords);
            }
        }
        #endregion

        #region Methods
        private async Task SaveAll()
        {
            try
            {
                if (batchList.Any())
                {
                    foreach (var item in batchList)
                    {
                        item.UserImageRoute = SaveImages(item);
                    }
                    await SaveData();
                }
                else
                {
                    MessageBox.Show("Cannot save an empty list");
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Images could not be saved");
            }
        }
        private string SaveImages(Batch batchList)
        {
            var newRoute = "";
            try
            {
                if (!String.IsNullOrEmpty(batchList.UserImageRoute))
                {
                    newRoute = generalManager.StoreImage(batchList.UserImageRoute, batchList.EmployeeNo);
                }
            }
            catch (Exception)
            {
            }
            return newRoute;
        }

        //Login method
        private void Login()
        {
            using (View.LoginModal frmLogin = new View.LoginModal())
            {
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    var loginObject = new LoginObject()
                    {
                        UserName = frmLogin.UserName,
                        UserPassword = frmLogin.Password
                    };
                    var jsonObject = JsonConvert.SerializeObject(loginObject, Formatting.Indented);
                    if (dataManager.LoginCheck(jsonObject))
                    {
                        userName = loginObject.UserName;
                        MessageBox.Show("Welcome, " + userName);
                    }
                    else
                    {
                        MessageBox.Show("Your login information is incorrect, \nplease try again.");
                        Login();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        //Create 
        private void CallWindow()
        {
            View.Form2 f2 = new View.Form2();
            f2.Show();
        }

        private void FillDataGrid(DataGridView dgv, List<Batch> batch)
        {
            dgv.DataSource = batch;
        }

        private void RefillRecords()
        {
            existingEntries = dataManager.GetPersonnels();
            FillDataGrid(dgvExistingRecords, existingEntries);
        }

        //Pura mentira
        private void TestingInfo()
        {
            var _batch = new Batch
            {
                PersonName = "Cesar Enrique Avila Meza",
                BirthDate = "20 DE SEPTIEMBRE 1992",
                EmployeeNo = "00000766",
                EducationLevel = "Licenciature",
                CarreerName = "ADMINISTRACION INDUSTRIAL",
                PersonalMail = "cesar.avila.ipn@gmail.com",
                CURP = "AIMC920920HDFVZS03",
                INE = "1234567890",
                Gender = "Male",
                Bloodtype = "O+",
                MaritalStatus = "Married",
                RFC = "1234567890",
                PhoneNumber = "1234567890",
                UserImageRoute = "",

                HSBCAccount = "1234567890",
                InfonavitNo = "1234567890",
                PassportNo = "",
                PassportExpiration = "",
                USVisaNo = "",
                USVisaExpiration = "",
                BirthState = "CDMX",
                CurrentAddress = "AV DIVISION DEL NORTE 221 LAGOS DE MORENO JALISCO",
                EmerContactRelationship = "Spouse",
                EmerContactName = "ALETHIA MABEL GUTIERREZ VAZQUEZ",
                EmerContactPhone = "5511920494",

                Department = "Administration",
                Area = "HR",
                Position = "Recluitment Specialist",
                PaymentType = "Biweekly",
                MailAccount = "Cesaravila@xinpoint.com",
                BPMAccount = "Cesaravila",
                ERPAccount = "",
                Transportation = "Company",
                PickupColony = "SAN MIGUEL",
                PickupRoute = "RUTA SAN MIGUEL",
            };
            batchList.Add(_batch);
        }

        private async Task SaveData()
        {
            if (batchList.Any())
            {
                var jsonObject = JsonConvert.SerializeObject(batchList);
                var processResult = await dataManager.InsertNewValue(jsonObject, userName);
                if (processResult == true.ToString())
                {
                    MessageBox.Show("This records were saved sucessfully");
                    FillDataGrid(dgvExistingRecords, dataManager.GetPersonnels());
                    tabControl1.SelectTab(tbpExistingRecords);
                }
                else
                {
                    MessageBox.Show(processResult);
                } 
            }
        }

        private void LocalUpdateRow(string columnName, string value, string employeeNumber)
        {
            var elementToUpdate = from element in batchList where element.EmployeeNo == employeeNumber select element;
            foreach (var item in elementToUpdate)
            {
                PropertyInfo info = item.GetType().GetProperty(columnName);

                info.SetValue(item, value);
            }
        }
        #endregion
    }
}