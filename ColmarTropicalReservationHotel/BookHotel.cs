using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ColmarTropicalReservationHotel
{
    public partial class BookHotel : Form
    {
        public BookHotel()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
      

            Program.room = int.Parse(txtRoom.Text);
            Program.night = int.Parse(txtNights.Text);
            Program.roomtype = (cmbRoom.Text);

            //choose hotel (using if..else)
            if (cmbRoom.Text == "Family Room")
            {
                Program.totalPrice = (Program.totalPrice + 462) * (Program.night * Program.room);
            }
            else if (cmbRoom.Text == "Two Bedroom Suite")
            {
                Program.totalPrice = (Program.totalPrice + 596) * (Program.night * Program.room);
            }
            else if (cmbRoom.Text == "Deluxe Room Double/Twin")
            {
                Program.totalPrice = (Program.totalPrice + 340) * (Program.night * Program.room);
            }
            else if (cmbRoom.Text == "3 Bedroom Suite")
            {
                Program.totalPrice = (Program.totalPrice + 743) * (Program.night * Program.room);
            }
            else if (cmbRoom.Text == "One Bedroom Deluxe Suite")
            {
                Program.totalPrice = (Program.totalPrice + 407) * (Program.night * Program.room);
            }
            else
            {
                MessageBox.Show("Please select hotel room!");
            }
            //choose breakfast using case
            switch (cmbBreakfast.Text)
            {
                case "Breakfast":
                    Program.totalPrice = (Program.totalPrice + (15*Program.night * Program.room));
                    break;
                case "No Breakfast":
                    Program.totalPrice = (Program.totalPrice + 0);
                    break;
                default:
                    break;
            }

            //discount price 
            Program.discountPrice = discountPrice(Program.totalPrice, Program.discountPrice); //PASSING PARAMETERS

            //Customer detail

            Program.title = (cmbTitle.Text);
            Program.name = (txtName.Text);
            Program.ICno = (txtIC.Text);
            Program.PhoneNo = (txtPhone.Text);
 

            txtTotalPrice.Text = Program.totalPrice.ToString("F2");
            txtDiscountPrice.Text = Program.discountPrice.ToString("F2");

            Program.grandTotal = Program.totalPrice - Program.discountPrice;

            txtGrandtotal.Text = Program.grandTotal.ToString("F2");
        }
        //function 
        public double discountPrice(double totalPrice, double discount)//DATA TYPE FOR PARAMETERS
        {
            
            Program.Code = (txtGroupCode.Text);

                    if (rbGroupCode.Checked == true)
                    {

                        if (Program.Code == "GROUP40")
                        {
                            discount = 0.4 * totalPrice;
                        }
                        else
                        {
                            MessageBox.Show("Please enter the correct code!");
                        }

                    }
                    else if (rbPromotionCode.Checked == true)
                    {

                        if (Program.Code == "PROMO50")
                        {
                            discount = 0.5 * totalPrice;
                        }
                        else
                        {
                            MessageBox.Show("Please enter the correct code!");
                        }
                    }
                    else if (rbTravelIndustryID.Checked == true)
                    {

                        if (Program.Code == "TRAVELID55")
                        {
                            discount = 0.55 * totalPrice;
                        }
                        else
                        {
                            MessageBox.Show("Please enter the correct code!");
                        }
                    }
                    
            return discount;//RETURNS VALUES
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult cancel = MessageBox.Show("Cancel Reservation?", " Cancelation ", MessageBoxButtons.YesNo);

            switch(cancel)
            {
                case DialogResult.Yes:

                    Welcome welcomeForm = new Welcome();

                    welcomeForm.Show();

                    break;

                case DialogResult.No:
 
                    break;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string filename = @"C:\Users\Athirah\Desktop\Assignment\H2\PP\Assignment\ColmarTropicalReservationHotel\ColmarTropicaleTextFile.txt";
            string data1 = "", data2="";
            DialogResult confirm = MessageBox.Show("Confirm reservation?"," Confirmation ", MessageBoxButtons.YesNo);

            
            switch (confirm)
            {
                case DialogResult.Yes:
                    //files structure : textfile
                    data1 = "Check In Date: " + dateTimePicker1.Value.Date.ToString() + "\r\n" + "Check Out Date:" + dateTimePicker2.Value.Date.ToString() + "\r\n" + "Name:" + cmbTitle.Text + txtName.Text + "\r\n" + "I/C Number:" + txtIC.Text + "\r\n" + "Phone Number:" + txtPhone.Text + "\r\n" + "Room type: " + cmbRoom.Text + "\r\n"+ "Room Quantity:" + int.Parse(txtRoom.Text) + "\r\n" + "Nights :" + int.Parse(txtNights.Text) + "\r\n" + "Grand total: RM" + double.Parse(txtGrandtotal.Text) + "\r\n";
                    File.AppendAllText(filename, data1);
                    data2 = "\r\n";
                    File.AppendAllText(filename, data2);

                    ViewReceipt receiptForm = new ViewReceipt();

                    receiptForm.Show();
                    break;

                case DialogResult.No:
                    Welcome welcomeForm = new Welcome();
                    welcomeForm.Show();
                    break;
            }
        }

        private void cmbCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCodes.Text == "Yes")
            {
                gbSpecialCodes.Enabled = true;
            }
            else if (cmbCodes.Text == "No")
            {
                gbSpecialCodes.Enabled=false;
            }
        }

        private void btnNight_Click(object sender, EventArgs e)
        {
           
            Program.CheckInDate = dateTimePicker1.Value;
            Program.CheckOutDate = dateTimePicker2.Value;

            if (Program.CheckOutDate.Date > Program.CheckInDate)
            {
                int diff = Convert.ToInt32((Program.CheckOutDate.Date - Program.CheckInDate.Date).TotalDays);
                txtNights.Text = diff.ToString();
                Program.night = int.Parse(txtNights.Text);
            }
            else
            {
                MessageBox.Show("The check out date must be at least a day after check in date");
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
        }

    }
}
