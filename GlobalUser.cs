using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Cozify
{
    public static class GlobalUser//database helper
    {
        public static string LoggedInUsername { get; set; }
    }


    /*public class DatabaseHelper
    {
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\fredwil\Desktop\Cozify Project\CozifyUsers.accdb";
       
        //Connection Test
        public void conenctiontest()
        {
            ds = new DataSet();
            myConn.Open();
            System.Windows.Forms.MessageBox.Show("Connected successfully!");
            myConn.Close();
        }
        //Login and Registration
        public bool RegisterUser(string username, string password)
        {
            try
            {
                myConn.Open();

                // Check if user exists
                string checkUserQuery = "SELECT COUNT(*) FROM [Users Table] WHERE Username = ?";
                using (OleDbCommand cmdCheck = new OleDbCommand(checkUserQuery, myConn))
                {
                    cmdCheck.Parameters.AddWithValue("?", username);
                    int userExists = (int)cmdCheck.ExecuteScalar();

                    if (userExists > 0)
                    {
                        return false; // User already exists
                    }
                }

                // Insert new user
                string insertQuery = "INSERT INTO [Users Table] (Username, [Password], CreatedAt) VALUES (?, ?, ?)";
                using (OleDbCommand cmdInsert = new OleDbCommand(insertQuery, myConn))
                {
                    cmdInsert.Parameters.AddWithValue("?", username);
                    cmdInsert.Parameters.AddWithValue("?", password); // NOTE: You should hash passwords for security!
                    cmdInsert.Parameters.AddWithValue("?", DateTime.Now);

                    cmdInsert.ExecuteNonQuery();
                }

                return true; // Registration successful
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                myConn.Close();
            }
        }

        /*public bool VerifyUserLogin(string username, string password)
        {
            try
            {
                myConn.Open();

                string query = "SELECT COUNT(*) FROM [Users Table] WHERE Username = ? AND [Password] = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", password);

                    int userExists = (int)cmd.ExecuteScalar();
                    return userExists > 0; // Return true if user exists
                }
            }
            catch (Exception ex)
            {
                // Handle error (e.g., logging or showing a message)
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                myConn.Close();
            }
        }

        //Pomodoro Timer Database thingies

        public void SavePomodoroSession(string username, bool isWorkSession, int workTime, int breakTime, int timeSpent)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO [Pomodoro Table] (Username, WorkTime, BreakTime, Completed, TimeSpent, IsWorkSession, SessionDate) VALUES (?, ?, ?, ?, ?, ?, ?);";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = username;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = isWorkSession ? workTime : 0;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = isWorkSession ? 0 : breakTime;
                    cmd.Parameters.Add("?", OleDbType.Boolean).Value = isWorkSession;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = timeSpent;
                    cmd.Parameters.Add("?", OleDbType.Boolean).Value = isWorkSession;
                    cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //To Do List Database thingies
        public void SaveTasks()
        {

        }

        public void LoadTasks()
        {

        }

        //Habit Checker Database thingies

        public void LoadHabits()
        {

        }

        public void SaveHabits()
        {

        }

        //Journal Database thingies

        public void LoadJournalEntries()
        {
        }
        public void lviewJournalEntries()
        {

        }
        public void SaveJournalEntries()
        {
        }

        public void DeleteJournalEntry()
        {
        }

    }*/
}
