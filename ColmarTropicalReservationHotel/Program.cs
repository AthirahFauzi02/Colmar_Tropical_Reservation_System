using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColmarTropicalReservationHotel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Welcome());
        }
        public static double totalPrice = 0;
        public static double discountPrice = 0;
        public static double grandTotal = 0;
        public static string roomtype;
        public static int night = 0;
        public static int room = 0; 
        public static string title;
        public static string name;
        public static string ICno;
        public static string PhoneNo;
        public static DateTime CheckInDate;
        public static DateTime CheckOutDate;
        public static string Code;
    }
}
