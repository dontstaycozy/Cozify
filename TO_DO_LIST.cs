using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cozify;

namespace finals
{
    public partial class TO_DO_LIST : BaseForm
    {
        public TO_DO_LIST()
        {
            InitializeComponent();
            this.MouseDown += TO_DO_LIST_MouseDown;
        }

        private void TO_DO_LIST_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void TO_DO_LIST_Load(object sender, EventArgs e)
        {
            tblToDoList.Controls.Clear();
            tblToDoList.RowStyles.Clear();
            tblToDoList.RowCount = 0;

            lblUserTask.Text = $"{GlobalUser.LoggedInUsername}'s Tasks";

            db.LoadToDoList(tblToDoList);

            for (int i = 0; i < tblToDoList.RowCount; i++)
            {
                RebindDeleteButton(i);
            }
        }

        private void btnAddToDoEntry_Click(object sender, EventArgs e)
        {
            db.AddToDoRow(tblToDoList, "", false, DateTime.Now);
            RebindDeleteButton(tblToDoList.RowCount - 1);
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            db.SaveToDoList(tblToDoList);
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            tblToDoList.Controls.Clear();
            tblToDoList.RowStyles.Clear();
            tblToDoList.RowCount = 0;
        }

        private void RebindDeleteButton(int rowIndex)
        {
            Control control = tblToDoList.GetControlFromPosition(0, rowIndex);

            if (control is Button btnDelete)
            {
                btnDelete.Click += (s, e) => DeleteToDoRow(rowIndex);
            }
        }

        private void DeleteToDoRow(int rowIndex)
        {
            db.DeleteToDoRow(tblToDoList, rowIndex);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
