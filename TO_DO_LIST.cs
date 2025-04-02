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
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\fredwil\Desktop\Cozify Project\CozifyUsers.accdb";


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
            lblUserTask.Text = GlobalUser.LoggedInUsername + "'s Tasks";
            LoadTasks();
        }

        private void LoadTasks()
        {
            tblToDoList.Controls.Clear();
            tblToDoList.RowStyles.Clear();
            tblToDoList.RowCount = 0;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Activity, isDone FROM [ToDo List Table] WHERE Username = ?;";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string activity = reader["Activity"].ToString();
                            bool isDone = reader.GetBoolean(reader.GetOrdinal("isDone"));
                            AddToDoRow(activity, isDone);
                        }
                    }
                }
            }
        }
        private void btnSaveList_Click(object sender, EventArgs e)
        {
            SaveTasks();
        }
        private void SaveTasks()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM [ToDo List Table] WHERE Username = ?;";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    cmd.ExecuteNonQuery();
                }
                query = "INSERT INTO [ToDo List Table] (Username, Activity, isDone) VALUES (?, ?, ?);";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    foreach (Control control in tblToDoList.Controls)
                    {
                        if (control is CheckBox chkDone)
                        {
                            int rowIndex = tblToDoList.GetRow(chkDone);
                            Control txtTask = tblToDoList.GetControlFromPosition(1, rowIndex);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                            cmd.Parameters.AddWithValue("?", txtTask.Text);
                            cmd.Parameters.AddWithValue("?", chkDone.Checked);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        private void btnAddToDoEntry_Click(object sender, EventArgs e)
        {
            AddToDoRow("", false);
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            tblToDoList.Controls.Clear();
            tblToDoList.RowStyles.Clear();
            tblToDoList.RowCount = 0;
        }

        private void AddToDoRow(string taskText, bool isDone)
        {
            int rowIndex = tblToDoList.RowCount;
            tblToDoList.RowCount++;

            CheckBox chkDone = new CheckBox
            {
                Checked = isDone,
                Anchor = AnchorStyles.None
            };

            TextBox txtTask = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(52, 73, 91),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 20F, FontStyle.Regular),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = HorizontalAlignment.Left,
                Text = taskText
            };

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

            btnDelete.Click += (s, e) => DeleteToDoRow(rowIndex);

            tblToDoList.Controls.Add(chkDone, 2, rowIndex);
            tblToDoList.Controls.Add(txtTask, 1, rowIndex);
            tblToDoList.Controls.Add(btnDelete, 0, rowIndex);
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
