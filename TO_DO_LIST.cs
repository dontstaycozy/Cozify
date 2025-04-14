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
using Cozify;

namespace finals // Saves upon closing using database
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
            lblUserTask.Text = GlobalUser.LoggedInUsername + "'s Tasks";
            db.LoadToDoList(tblToDoList);
            for (int i = 0; i < tblToDoList.RowCount; i++)
            {
                RebindDeleteButton(i);
            }
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            db.SaveToDoList(tblToDoList);
        }
        private void btnAddToDoEntry_Click(object sender, EventArgs e)
        {
            db.AddToDoRow(tblToDoList, "", false, DateTime.Now);
            RebindDeleteButton(tblToDoList.RowCount - 1);
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
            for (int col = 0; col < tblToDoList.ColumnCount; col++)
            {
                var control = tblToDoList.GetControlFromPosition(col, rowIndex);
                if (control != null)
                {
                    tblToDoList.Controls.Remove(control);
                    control.Dispose();
                }
            }

            for (int i = rowIndex; i < tblToDoList.RowCount; i++)
            {
                for (int col = 0; col < tblToDoList.ColumnCount; col++)
                {
                    Control c = tblToDoList.GetControlFromPosition(col, i);
                    if (c != null)
                    {
                        tblToDoList.SetRow(c, i - 1);
                    }
                }
            }
            if (tblToDoList.RowCount > 0)
            {
                tblToDoList.RowCount--;
            }
            //tblToDoList.RowCount--;
            if (tblToDoList.RowStyles.Count > rowIndex)
                tblToDoList.RowStyles.RemoveAt(rowIndex);
        }
    }
}
