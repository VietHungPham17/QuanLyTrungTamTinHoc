using BLLayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrungTamTinHoc
{
    /// <summary>
    /// Chi tiết học viên
    /// </summary>
    public partial class FrmDetailsStudent : Form
    {
        public FrmDetailsStudent()
        {
            InitializeComponent();
        }

        private void FrmDetailsStudent_Load(object sender, EventArgs e)
        {
            // Custom Fotmat date timepicker
            dtpBirthDay.CustomFormat = "dd/MM/yyyy";

            Student student = new Student();
            string StudentID = Program.StudentID;
            Program.StudentID = string.Empty;

            student = (new BLLStudent()).Get(StudentID);

            if (student == null) return;

            txtStudentID.Text = student.StudentID;
            txtStudentName.Text = student.StudentName;
            dtpBirthDay.Value = student.BirthDay;
            cmbGender.Text = student.Gender;
            txtPhoneNumber.Text = student.PhoneNumber;
            txtEmail.Text = student.Email;
            cmbAddress.Text = student.Address;
            cmbStaying.Text = student.Staying;
            cmbEducation.Text = student.Education;
            cmbUniversity.Text = student.University;

            try
            {
                byte[] image = student.Avatar;
                MemoryStream stream = new MemoryStream(image);

                picAvatar.Image = Image.FromStream(stream);
            }
            catch (Exception)
            {
            }

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
