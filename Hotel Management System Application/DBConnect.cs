using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // Don't forget to add MySQL as a resource.

namespace Hotel_Management_System_Application
{
    internal class DBConnect
    {
        // Create the connection 
        private MySqlConnection connection = new MySqlConnection("datasource=localhost;port=9000;username=root;password=;database=hotel_data");

        // Return our connection
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        // Create a function to open the connection
        public void OpenCon()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Create a function to close the connection
        public void CloseCon()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
