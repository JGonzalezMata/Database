using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.View
{
    public partial class LoginModal : Form
    {
        public LoginModal()
        {
            InitializeComponent();
        }

        public string UserName => txtUsrName.Text;
        public string Password => txtPassword.Text;
    }
}
