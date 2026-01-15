using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrungTamTinHoc
{
    static class Program
    {
        public static string LevelID;
        public static string StudentID;
        public static string CourseID;
        public static string EmployeeID;
        public static string MajorID;
        public static DateTime TestDate;
        public static string Username;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           (new FrmLogin()).ShowDialog();

            if (string.IsNullOrEmpty(Username) == false)
                Application.Run(new FrmMain());
        }
    }
}
