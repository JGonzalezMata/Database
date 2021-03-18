
namespace Database
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.btnCrtNew = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpExistingRecords = new System.Windows.Forms.TabPage();
            this.dgvExistingRecords = new System.Windows.Forms.DataGridView();
            this.tbpBatchUsers = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnSvNew = new System.Windows.Forms.Button();
            this.btnCrtCards = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbpExistingRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistingRecords)).BeginInit();
            this.tbpBatchUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search by name";
            // 
            // txtSchName
            // 
            this.txtSchName.Location = new System.Drawing.Point(214, 31);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(181, 21);
            this.txtSchName.TabIndex = 2;
            // 
            // btnCrtNew
            // 
            this.btnCrtNew.Location = new System.Drawing.Point(401, 29);
            this.btnCrtNew.Name = "btnCrtNew";
            this.btnCrtNew.Size = new System.Drawing.Size(75, 23);
            this.btnCrtNew.TabIndex = 3;
            this.btnCrtNew.Text = "Create new";
            this.btnCrtNew.UseVisualStyleBackColor = true;
            this.btnCrtNew.Click += new System.EventHandler(this.btnCrtNew_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpExistingRecords);
            this.tabControl1.Controls.Add(this.tbpBatchUsers);
            this.tabControl1.Location = new System.Drawing.Point(12, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 369);
            this.tabControl1.TabIndex = 4;
            // 
            // tbpExistingRecords
            // 
            this.tbpExistingRecords.Controls.Add(this.dgvExistingRecords);
            this.tbpExistingRecords.Location = new System.Drawing.Point(4, 22);
            this.tbpExistingRecords.Name = "tbpExistingRecords";
            this.tbpExistingRecords.Padding = new System.Windows.Forms.Padding(3);
            this.tbpExistingRecords.Size = new System.Drawing.Size(777, 343);
            this.tbpExistingRecords.TabIndex = 0;
            this.tbpExistingRecords.Text = "Existing Records";
            this.tbpExistingRecords.UseVisualStyleBackColor = true;
            // 
            // dgvExistingRecords
            // 
            this.dgvExistingRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExistingRecords.Location = new System.Drawing.Point(0, 0);
            this.dgvExistingRecords.Name = "dgvExistingRecords";
            this.dgvExistingRecords.RowTemplate.Height = 23;
            this.dgvExistingRecords.Size = new System.Drawing.Size(777, 343);
            this.dgvExistingRecords.TabIndex = 0;
            this.dgvExistingRecords.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExistingRecords_CellValueChanged);
            this.dgvExistingRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvExistingRecords_MouseClick);
            // 
            // tbpBatchUsers
            // 
            this.tbpBatchUsers.Controls.Add(this.dgvUsers);
            this.tbpBatchUsers.Location = new System.Drawing.Point(4, 22);
            this.tbpBatchUsers.Name = "tbpBatchUsers";
            this.tbpBatchUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBatchUsers.Size = new System.Drawing.Size(777, 343);
            this.tbpBatchUsers.TabIndex = 1;
            this.tbpBatchUsers.Text = "Batch Users";
            this.tbpBatchUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowTemplate.Height = 23;
            this.dgvUsers.Size = new System.Drawing.Size(776, 346);
            this.dgvUsers.TabIndex = 2;
            this.dgvUsers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellValueChanged);
            this.dgvUsers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvUsers_MouseClick);
            // 
            // btnSvNew
            // 
            this.btnSvNew.Location = new System.Drawing.Point(501, 29);
            this.btnSvNew.Name = "btnSvNew";
            this.btnSvNew.Size = new System.Drawing.Size(96, 23);
            this.btnSvNew.TabIndex = 5;
            this.btnSvNew.Text = "Save / Update";
            this.btnSvNew.UseVisualStyleBackColor = true;
            this.btnSvNew.Click += new System.EventHandler(this.btnSvNew_Click);
            // 
            // btnCrtCards
            // 
            this.btnCrtCards.Location = new System.Drawing.Point(626, 29);
            this.btnCrtCards.Name = "btnCrtCards";
            this.btnCrtCards.Size = new System.Drawing.Size(135, 23);
            this.btnCrtCards.TabIndex = 6;
            this.btnCrtCards.Text = "Save and Create card";
            this.btnCrtCards.UseVisualStyleBackColor = true;
            this.btnCrtCards.Click += new System.EventHandler(this.btnCrtCards_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCrtCards);
            this.Controls.Add(this.btnSvNew);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCrtNew);
            this.Controls.Add(this.txtSchName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main View";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tbpExistingRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistingRecords)).EndInit();
            this.tbpBatchUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSchName;
        private System.Windows.Forms.Button btnCrtNew;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpExistingRecords;
        private System.Windows.Forms.TabPage tbpBatchUsers;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvExistingRecords;
        private System.Windows.Forms.Button btnSvNew;
        private System.Windows.Forms.Button btnCrtCards;
    }
}

