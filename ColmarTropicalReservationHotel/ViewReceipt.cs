using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColmarTropicalReservationHotel
{
    public partial class ViewReceipt : Form
    {
        public ViewReceipt()
        {
            InitializeComponent();
        }

        private void btnViewReceipt_Click(object sender, EventArgs e)
        {
            listReceipt.Items.Add("Check In Date: " + Program.CheckInDate);
            listReceipt.Items.Add("Check Out Date:" + Program.CheckOutDate);
            listReceipt.Items.Add("Customer's Name:" + Program.title + Program.name);
            listReceipt.Items.Add("I/C Number:" + Program.ICno);
            listReceipt.Items.Add("Phone Number:" + Program.PhoneNo);
            listReceipt.Items.Add("Room Type:" + Program.roomtype);
            listReceipt.Items.Add("Room Quantity:" + Program.room);
            listReceipt.Items.Add("Nights:" + Program.night);
            listReceipt.Items.Add("Total Price: RM" + Program.totalPrice);
            listReceipt.Items.Add("Special Code:" + Program.Code);
            listReceipt.Items.Add("Discount Price: RM" + Program.discountPrice);
            listReceipt.Items.Add("Grand Total: RM" + Program.grandTotal);
        }

        private void btnAddNewReserve_Click(object sender, EventArgs e)
        {
            DialogResult newReservation = MessageBox.Show("Add New Reservation?", " New Reservation ", MessageBoxButtons.YesNo);


            switch (newReservation)
            {
                case DialogResult.Yes:

                    BookHotel bookHotelForm = new BookHotel();

                    bookHotelForm.Show();

                    break;

                case DialogResult.No:

                    break;
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ViewReport report = new ViewReport();

            report.Show();

            this.Close();
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
