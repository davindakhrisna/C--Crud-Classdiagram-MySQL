using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CRUD_PTS
{
    public partial class Login : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Username = txtUser.Text;
            Password = txtPass.Text;

            if (Username == "Admin" && Password == "Admin")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username atau Password salah.");
            }
        }
    }
}
