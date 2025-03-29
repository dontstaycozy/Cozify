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

namespace finals//saves upon closing using database
{
    public partial class TO_DO_LIST : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public TO_DO_LIST()
        {
            InitializeComponent();
            this.MouseDown += TO_DO_LIST_MouseDown;
            tblToDoList.Controls.Clear();
            tblToDoList.RowCount = 0;
        }

        private void TO_DO_LIST_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // Dragging action
            }
        }

        private void btnAddToDoEntry_Click(object sender, EventArgs e)
        {
            AddToDoRow();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            tblToDoList.Controls.Clear();
            tblToDoList.RowCount = 0;
        }

        private void AddToDoRow()
        {
            tblToDoList.RowCount++;
            int rowIndex = tblToDoList.RowCount - 1;


            Button btnDelete = new Button
            {
                Text = "X",
                BackColor = Color.FromArgb(40, 56, 69),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 12F, FontStyle.Regular),
                Size = new Size(23, 23),
                Anchor = AnchorStyles.None,
                FlatStyle = FlatStyle.Flat
            };

            TextBox txtTask = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(52, 73, 91),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 20F, FontStyle.Regular),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = HorizontalAlignment.Left,
            };

            btnDelete.Click += (s, e) => DeleteToDoRow(rowIndex);

            tblToDoList.Controls.Add(txtTask, 1, rowIndex);
            tblToDoList.Controls.Add(btnDelete, 0, rowIndex);

            txtTask.Focus();
        }

        private void DeleteToDoRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= tblToDoList.RowCount)
                return;

            for (int i = 0; i < tblToDoList.ColumnCount; i++)
            {
                Control control = tblToDoList.GetControlFromPosition(i, rowIndex);
                if (control != null)
                {
                    tblToDoList.Controls.Remove(control);
                    control.Dispose();
                }
            }

            for (int i = rowIndex + 1; i < tblToDoList.RowCount; i++)
            {
                for (int j = 0; j < tblToDoList.ColumnCount; j++)
                {
                    Control control = tblToDoList.GetControlFromPosition(j, i);
                    if (control != null)
                        tblToDoList.SetRow(control, i - 1);
                }
            }

            tblToDoList.RowCount--;
        }
    }
}
