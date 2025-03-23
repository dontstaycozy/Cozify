using finals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cozify
{
    public partial class LoginReg: Form
    {
        public LoginReg()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MAIN_HUB mAIN_HUB = new MAIN_HUB();
            mAIN_HUB.Show();
            this.Hide();
        }

        private void centering()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int tbx1 = (formWidth - textBox1.Width) / 2;
            int tbx2 = (formWidth - textBox2.Width) / 2;
            int regbtn = (formWidth - btnLogin.Width) / 2;
        }

        private void LoginReg_Load(object sender, EventArgs e)
        {
            centering();
        }

        private void btnGoBackToRegister_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Close();
        }
    }
}
