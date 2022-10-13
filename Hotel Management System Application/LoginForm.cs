using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_Management_System_Application
{
    public partial class LoginForm : Form
    {
        DBConnect connect = new DBConnect();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.DarkRed;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Crimson;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // If Either Textbox is empty, throw an error
            if (TextBox_username.Text.Trim().Equals("") || TextBox_password.Text == "")
            {
                MessageBox.Show("Enter your username and password to login", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string selectquery = "SELECT * FROM `users` WHERE `username` = @usn AND `password` = @pass";
                MySqlCommand command = new MySqlCommand(selectquery, connect.GetConnection());
                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = TextBox_username.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextBox_password.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                // If the username and password already exist,
                if (table.Rows.Count > 0)
                {
                    // Show the Main Form if user
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else // If the username or password doesn't exist, throw error
                {
                    MessageBox.Show("Your username or password doesn't exist", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
