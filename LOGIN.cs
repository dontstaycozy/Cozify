using Cozify;
using Cozify.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals
{
    public partial class LOGIN: Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }
          
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
        {
            LoginReg loginReg = new LoginReg();
            loginReg.Show();
            this.Hide();
        }

        private void btnLoginExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegisterLogin_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
