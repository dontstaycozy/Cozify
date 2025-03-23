using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals
{
    public partial class TO_DO_LIST: Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        public TO_DO_LIST()
        {
            InitializeComponent();
            this.MouseDown += TO_DO_LIST_MouseDown;//put this in the form to make the form draggable
        }
        private void TO_DO_LIST_MouseDown(object sender, MouseEventArgs e)//function to make the form draggable
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
        private void btnAddToDoEntry_Click(object sender, EventArgs e)
        {

        }

        private void btnClearList_Click(object sender, EventArgs e)
        {

        }
    }
}
