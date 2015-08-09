using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeptDets
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CredentialCheck Check = new CredentialCheck(@"UserLogin.csv");

            if(Check.Checkfile(txtEmail.Text, txtPassword.Text))
            {
                BehaviourLog em = new BehaviourLog(txtEmail.Text, txtPassword.Text);
                em.Show();
                this.Hide();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // load default user if any..

            int nDefaultUsers = 0;
            FileReader r = new FileReader("UserLogin.csv");
            string[,] strData = r.LoadFile(ref nDefaultUsers);
            txtEmail.Text = strData[0, 0];
        }
    }
}
