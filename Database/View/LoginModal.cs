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