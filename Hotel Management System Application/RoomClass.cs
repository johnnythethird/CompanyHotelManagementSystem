using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_Management_System_Application
{
    internal class RoomClass
    {
        /*
         * This class will be designed to manage the rooms
         * We'll start with the room table for the room type (single, double, family, suite).
         */
        DBConnect connect = new DBConnect();

        // Create a function to get a list of Room Types
        public DataTable getRoomType()
        {
            string selectQuery = "SELECT * FROM `category`";
            MySqlCommand command = new MySqlCommand(selectQuery, connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        // Create a function that adds a new room.
        public bool addRoom(string no, int type, string phone, string status)
        {
            string insertQuery = "INSERT INTO `room`(`RoomId`, `RoomType`, `RoomPhone`, `RoomStatus`) VALUES (@no, @type, @ph, @sts)";
            MySqlCommand command = new MySqlCommand(insertQuery, connect.GetConnection());
            // @no, @type, @ph, @sts
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@sts", MySqlDbType.VarChar).Value = status;

            connect.OpenCon();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseCon();
                return true;
            }
            else
            {
                connect.CloseCon();
                return false;
            }
        }

        // Create a function that will get a table of the room's list.
        public DataTable getRoomList()
        {
            string selectQuery = "SELECT * FROM `room`";
            MySqlCommand command = new MySqlCommand(selectQuery, connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        // Create a function to edit/update a room
        public bool editRoom(string no, int type, string phone, string status)
        {
            string editQuery = "UPDATE `room` SET `RoomType`=@type,`RoomPhone`=@ph,`RoomStatus`=@sts WHERE `RoomId`=@no";
            MySqlCommand command = new MySqlCommand(editQuery, connect.GetConnection());
            // @no, @type, @ph, @sts
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@sts", MySqlDbType.VarChar).Value = status;

            connect.OpenCon();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseCon();
                return true;
            }
            else
            {
                connect.CloseCon();
                return false;
            }
        }

        // Create a function that can remove a room with the Room ID
        public bool removeRoom(string id)
        {
            string editQuery = "DELETE FROM `room` WHERE `RoomId`=@id";
            MySqlCommand command = new MySqlCommand(editQuery, connect.GetConnection());
            // @id
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            connect.OpenCon();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseCon();
                return true;
            }
            else
            {
                connect.CloseCon();
                return false;
            }
        }
    }
}
