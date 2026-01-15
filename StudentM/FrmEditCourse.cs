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
    /// Chỉnh sữa khóa học
    /// </summary>
    public partial class FrmEditCourse : Form
    {
        public FrmEditCourse()
        {
            InitializeComponent();
        }

        private void FrmEditCourse_Load(object sender, EventArgs e)
        {
            nudTuiTion.ThousandsSeparator = true;


            cmbLevel.DataSource = (new BLLLevel()).GetAll();
            cmbLevel.DisplayMember = "LevelName";
            cmbLevel.ValueMember = "LevelID";

            cmbEmployee.DataSource = (new BLLEmployee()).GetTeach();
            cmbEmployee.DisplayMember = "EmployeeName";
            cmbEmployee.ValueMember = "EmployeeID";

            // Lấy khóa học từ biến tĩnh
            string CourseID = Program.CourseID; 
            Program.CourseID = string.Empty;    // cho biến tĩnh bằng Empty

            Course course = new Course();

            course = (new BLLCourse()).Get(CourseID);
            if (course == null) return;

            txtCourseID.Text = course.CourseID;
            txtCourseName.Text = course.CourseName;
            dtpTime.Value = DateTime.Parse(course.Time.ToString());
            dtpOpening.Value = course.Opening;
            dtpClosing.Value = course.Closing;
            cmbSchedule.Text = course.Schedule;
            cmbRoom.Text = course.Room;
            nudTuiTion.Value = course.Tuition;
            cmbLevel.SelectedValue = course.LevelID;
            cmbEmployee.SelectedValue = course.EmployeeID;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Edit()
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

                (new BLLCourse()).Update(course);

                List<Register> lstRegister = new List<Register>();
                lstRegister = (new BLLRegister()).GetByCourse(course.CourseID);

                foreach (Register reg in lstRegister)
                {
                    reg.Total = course.Tuition - reg.Exemption * course.Tuition / 100;
                    reg.Debt = reg.Total- reg.Payment;
                    (new BLLRegister()).Update(reg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSaveAndQuit_Click(object sender, EventArgs e)
        {
            if (Edit() == true) this.Close();
        }
    }
}
