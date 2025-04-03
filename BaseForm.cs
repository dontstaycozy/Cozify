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
using System.Data.OleDb;

namespace Cozify
{
    public partial class BaseForm: Form
    {
        
        //for dragging window
        [DllImport("user32.dll")]
        protected static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        protected static extern bool ReleaseCapture();

        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // Allows dragging window
            }
        }
        public BaseForm()
        {
            InitializeComponent();
            this.MouseDown += BaseForm_MouseDown;
        }
    }
}
