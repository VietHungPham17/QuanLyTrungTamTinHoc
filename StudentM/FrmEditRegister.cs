using BLLayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrungTamTinHoc
{
    /// <summary>
    /// Chỉnh sữa đăng ký
    /// </summary>
    public partial class FrmEditRegister : Form
    {
        public FrmEditRegister()
        {
            InitializeComponent();
        }

        private void FrmEditRegister_Load(object sender, EventArgs e)
        {
            // Lấy mã từ biến tĩnh
            string StudentID = Program.StudentID;
            string CourseID = Program.CourseID;

            // Cho biến tĩnh bằng Empty
            Program.CourseID = string.Empty;
            Program.StudentID = string.Empty;

            Register register = new Register();

            register = (new BLLRegister()).Get(StudentID, CourseID);

            if (register == null) return;

            Student student = new Student();
            Course course = new Course();
            student = (new BLLStudent()).Get(StudentID);
            course = (new BLLCourse()).Get(CourseID);



            txtStudentID.Text = student.StudentID + " / " + student.StudentName;
            txtCourseID.Text = course.CourseID + " / " + course.CourseName;
            dtpDate.Value = dtpDate.Value;
            txtNote.Text = register.Note;
            nudExemption.Value = register.Exemption;
            nudTuition.Value = register.Total;
        }

        private bool EditRegister()
        {
            try
            {
                Register register = new Register();

                // Cắt chuỗi từ vị trí '/' đưa vào mảng String
                string[] tempStudent = txtStudentID.Text.Split('/');
                string[] tempCourse = txtCourseID.Text.Split('/');

                // Lấy mã từ mảng chuỗi
                string StudentID = tempStudent[0].Trim();
                string CourseID = tempCourse[0].Trim();

                // Lấy đăng ký theo mã học viên và mã khóa học
                register = (new BLLRegister()).Get(StudentID, CourseID);

                if (register == null) return false;

                // Cập nhật đăng ký
                register.Date = dtpDate.Value;
                register.Total = nudTuition.Value;
                register.Exemption = (int)nudExemption.Value;
                register.Debt = nudTuition.Value - register.Payment;
                register.Note = txtNote.Text;

                (new BLLRegister()).Update(register);
            }
            catch (Exception)
            {
                MessageBox.Show("Chỉnh sửa thất bại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void nudExemption_ValueChanged(object sender, EventArgs e)
        {
            string[] tempCourse = txtCourseID.Text.Split('/');
            string CourseID = tempCourse[0].Trim();
            Course course = (new BLLCourse()).Get(CourseID);
            if (course == null) return;

            // Cập nhật lại giá trị học phí khi thay đổi miễn giảm
            nudTuition.Value = course.Tuition - course.Tuition * (nudExemption.Value) / 100;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditRegister();
        }

        private void btnSaveAndQuit_Click(object sender, EventArgs e)
        {
            if (EditRegister() == true) this.Close();
        }
    }
}
