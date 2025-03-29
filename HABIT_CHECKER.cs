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
    public partial class HABIT_CHECKER: Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();


        public HABIT_CHECKER()
        {
            InitializeComponent();
            this.MouseDown += HABIT_CHECKER_MouseDown;
        }

        private void HABIT_CHECKER_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // Dragging action
            }
        }

        private void HABIT_CHECKER_Load_1(object sender, EventArgs e)
        {
            tblHabitChecker.Controls.Clear();
            tblHabitChecker.RowStyles.Clear();
            tblHabitChecker.RowCount = 0;
            //AddHabitRow();
        }

        private void btnAddHabit_Click(object sender, EventArgs e)
        {
            AddHabitRow();
        }

        private void AddHabitRow()
        {

            tblHabitChecker.RowCount++;
            int rowIndex = tblHabitChecker.RowCount-1; 

            TextBox txtHabit = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(52, 73, 91),
                ForeColor = Color.White, 
                Font = new Font("Pixeltype", 23F, FontStyle.Regular),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = HorizontalAlignment.Left,
            };
            tblHabitChecker.Controls.Add(txtHabit, 1, rowIndex);

            for (int i = 2; i <= 8; i++)
            {
                CheckBox chkDay = new CheckBox
                {
                    Anchor = AnchorStyles.None,
                    AutoSize = false,
                    Size = new Size(30, 30),
                    Margin = new Padding(20, 5, 20, 5) 

                };
                tblHabitChecker.Controls.Add(chkDay, i, rowIndex);
            }

            Button btnDelete = new Button
            {
                Text = "X",
                BackColor = Color.FromArgb(40, 56, 69),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 12F, FontStyle.Regular),
                Size = new Size(20, 20),
                Anchor = AnchorStyles.None,
                FlatStyle = FlatStyle.Flat
            };

            btnDelete.Click += (s, e) => DeleteHabitRow(rowIndex);
            tblHabitChecker.Controls.Add(btnDelete, 0, rowIndex);
            txtHabit.Focus();
        }

        private void DeleteHabitRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= tblHabitChecker.RowCount)
                return;

            // Remove controls in the specified row
            for (int i = 0; i < tblHabitChecker.ColumnCount; i++)
            {
                Control control = tblHabitChecker.GetControlFromPosition(i, rowIndex);
                if (control != null)
                {
                    tblHabitChecker.Controls.Remove(control);
                    control.Dispose();
                }
            }

            // Move all rows up
            for (int i = rowIndex + 1; i < tblHabitChecker.RowCount; i++)
            {
                for (int j = 0; j < tblHabitChecker.ColumnCount; j++)
                {
                    Control control = tblHabitChecker.GetControlFromPosition(j, i);
                    if (control != null)
                        tblHabitChecker.SetRow(control, i - 1);
                }
            }

            tblHabitChecker.RowCount--;
        }

        
    }
}
