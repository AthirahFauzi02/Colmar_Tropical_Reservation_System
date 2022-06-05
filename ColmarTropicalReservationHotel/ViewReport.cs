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
    public partial class ViewReport : Form
    {
        public ViewReport()
        {
            InitializeComponent();
        }

        private void btnViewReceipt_Click(object sender, EventArgs e)
        {
            //REPORT OF DATA FROM TEXT FILE 
            //file path based on file name
            string filepath = @"C:\Users\Athirah\Desktop\Assignment\H2\PP\Assignment\ColmarTropicalReservationHotel\ColmarTropicaleTextFile.txt";            

            string[] readTextFile = File.ReadAllLines(filepath);

            for (int i = 0; i < readTextFile.Length; i++)
            {
                listReport.Items.Add(readTextFile[i]);
            }
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();

            welcomeForm.Show();

            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\Athirah\Desktop\Assignment\H2\PP\Assignment\ColmarTropicalReservationHotel\ColmarTropicaleTextFile.txt";

            File.WriteAllText(filepath, String.Empty);

        }
    }
}
