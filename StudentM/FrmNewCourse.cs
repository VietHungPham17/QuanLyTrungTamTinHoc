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
    /// Thêm khóa học mới
    /// </summary>
    public partial class FrmNewCourse : Form
    {
        public FrmNewCourse()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmNewCourse_Load(object sender, EventArgs e)
        {
            nudTuiTion.ThousandsSeparator = true;

            txtCourseID.Text = (new BLLCourse()).NextID();

            cmbLevel.DataSource = (new BLLLevel()).GetAll();
            cmbLevel.DisplayMember = "LevelName";
            cmbLevel.ValueMember = "LevelID";

            // Đổ dữ liệu lên ConboBox, chỉ lấy những nhân viên có chuyên ngành là giáo viên
            cmbEmployee.DataSource = (new BLLEmployee()).GetTeach();
            cmbEmployee.DisplayMember = "EmployeeName";
            cmbEmployee.ValueMember = "EmployeeID";
        }
        private bool Insert()
        {
            try
            {
                Course course = new Course();
                course.CourseID = txtCourseID.Text;
                course.CourseName = txtCourseName.Text;
                course.Time = dtpTime.Value.TimeOfDay;
                course.Opening = dtpOpening.Value;
                course.Closing = dtpClosing.Value;
                course.Schedule = cmbSchedule.Text;
                course.Tuition = nudTuiTion.Value;
                course.Status = true;
                course.LevelID = cmbLevel.SelectedValue.ToString();
                course.EmployeeID = cmbEmployee.SelectedValue.ToString();
                course.Room = cmbRoom.Text;
                //course.Number = 0;

                (new BLLCourse()).Insert(course);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnNewAndQuit_Click(object sender, EventArgs e)
        {
            if (Insert() == true) this.Close();
        }
    }
}
