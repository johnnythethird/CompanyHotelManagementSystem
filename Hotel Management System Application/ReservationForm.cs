using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System_Application
{
    public partial class ReservationForm : Form
    {
        RoomClass room = new RoomClass();
        ReservationClass reservation = new ReservationClass();
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            // Show the available options for room type in the combobox.
            comboBox_roomType.DataSource = room.getRoomType();
            comboBox_roomType.DisplayMember = "Label";
            comboBox_roomType.ValueMember = "CategoryID";

            int type = Convert.ToInt32(comboBox_roomType.SelectedValue.ToString());
            comboBox_roomNo.DataSource = reservation.roomByType(type);
            comboBox_roomNo.DisplayMember = "RoomId";
            comboBox_roomNo.ValueMember = "RoomId";

            dataGridView_reserve.DefaultCellStyle.ForeColor = Color.Black;

            // Show Reservation List in Data Grid
            getReserveTable();

        }

        public void getReserveTable()
        {
            dataGridView_reserve.DataSource = reservation.getReserve();
        }

        private void comboBox_roomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display the room's number depending on the room type
            // display the room status as free
            try
            {
                int type = Convert.ToInt32(comboBox_roomType.SelectedValue.ToString());
                comboBox_roomNo.DataSource = reservation.roomByType(type);
                comboBox_roomNo.DisplayMember = "RoomId";
                comboBox_roomNo.ValueMember = "RoomId";
            }
            catch (Exception ex)
            {
                // Nothin
            }

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                int guestId = Convert.ToInt32(textBox_guestId.Text);
                string roomNo = comboBox_roomNo.SelectedValue.ToString();
                DateTime dIn = dateTimePicker_dateIn.Value;
                DateTime dOut = dateTimePicker_dateOut.Value;

                if (reservation.addReserve(guestId, roomNo, dIn, dOut))
                {
                    MessageBox.Show("Reservation Added!", "Add Resservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getReserveTable();
                }
                else
                {
                    MessageBox.Show("Reservation NOT Added!", "Error Resservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reservation Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.DarkRed;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Crimson;
        }

        // the guest id 32 does not exists in the guest table
        // so we need to prevent this problem, add a foreign key guest id of the reservation table
        // And Room no 101 is busy now, is not available
        // so we need to prevent this problem, date condition
        // now add the foreign key for the guest
    }
}
