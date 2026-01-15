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
    public partial class Fr : Form
    {
        private BindingSource bdStudent;
        private List<Student> lstStudent;
        private BindingSource bdRegister;
        private List<Register> lstRegister;
        private BindingSource bdReceipt;
        public Fr()
        {
            InitializeComponent();
            bdStudent = new BindingSource();
            lstStudent = new List<Student>();
            bdRegister = new BindingSource();
            bdReceipt = new BindingSource();
            lstRegister = new List<Register>();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            //StudentName.DataSource = (new BLLStudent()).GetAll();
            //StudentName.DisplayMember = "StudentName";
            //StudentName.ValueMember = "StudentID";

            // Đổ dữ liệu vào TreeView
            lstStudent = (new BLLStudent()).GetAll();

            List<Level> lstLevel = new List<Level>();
            lstLevel = (new BLLLevel()).GetAll();

            List<Course> lstCourse = new List<Course>();


            foreach (Level level in lstLevel)
            {
                TreeNode treeNode = new TreeNode(level.LevelName);
                treeNode.Tag = level.LevelID;

                lstCourse = (new BLLCourse()).GetByLevel(level.LevelID, true);
                foreach (Course course in lstCourse)
                {
                    TreeNode treeNodeChild = new TreeNode(course.CourseName);
                    treeNodeChild.Tag = course.CourseID;
                    treeNode.Nodes.Add(treeNodeChild);
                }

                treCourse.Nodes.Add(treeNode);
            }

            // binding data

            dgvRegister.DataSource = bdRegister;

            // Search theo mã học viên
            cmbSearchToolStripComboBox.SelectedIndex = 0;

            // Lấy Id tự động
            txtReceiptID.Text = (new BLLReceipt()).NextID();

            // Hiển thị nhân viên khi đăng nhập lên textBox
            Employee employee = new Employee();
            employee = (new BLLEmployee()).Get(Program.Username);
            txtEmployee.Text = employee.EmployeeID + " / " + employee.EmployeeName;
        }

        /// <summary>
        /// Tìm kiếm
        ///     1. Mã học viên
        ///     2. Mã khóa học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            string TextSearch = txtSearchToolStripTextBox.Text;
            int indexSearch = cmbSearchToolStripComboBox.SelectedIndex;

            if (indexSearch == 0)
                bdRegister.DataSource = lstRegister
                    .Where(p => p.StudentID.Contains(TextSearch))
                    .Select(p => p)
                    .ToList<Register>();
            else if (indexSearch == 1)
                bdRegister.DataSource = lstRegister
                        .Where(p => p.CourseID.Contains(TextSearch))
                        .Select(p => p)
                        .ToList<Register>();
            ShowStudentName();
        }

        private void dgvRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvRegister.CurrentCell.RowIndex;
                string StudentID = (string)dgvRegister.Rows[index].Cells["StudentID"].Value;
                string CourseID = (string)dgvRegister.Rows[index].Cells["CourseID"].Value;

                Register register = new Register();
                register = (new BLLRegister()).Get(StudentID, CourseID);

                if (register == null) return; // quit

                nudDebt.Value = register.Debt;

                Receipt receipt = new Receipt();

                receipt.StudentID = StudentID;
                receipt.CourseID = CourseID;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Bạn có muốn đăng ký khóa học cho học viên này?.", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                Register register = new Register();


                string[] tmpStudent = cmbStudent.Text.ToString().Split('/');
                string[] tmpCourse = txtCourse.Text.ToString().Split('/');

                string StudentID = tmpStudent[0].Trim();
                string CourseID = tmpCourse[0].Trim();

                register.StudentID = StudentID;
                register.CourseID = CourseID;

                register.Date = DateTime.Now;
                register.Total = nudTuition.Value;
                register.Exemption = (int)nudExemption.Value;
                register.Payment = 0;
                register.Debt = nudTuition.Value;
                register.Note = txtNote.Text;

                // Insert register
                (new BLLRegister()).Insert(register);



                //Message
                MessageBox.Show("Đăng ký thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // update number of stdent in course
                Course course = new DTLayer.Course();
                course = (new BLLCourse()).Get(CourseID);
                if (course != null)
                {
                    course.Number += 1;
                    (new BLLCourse()).Update(course);
                }

                // set is active
                Student student = new Student();
                student = (new BLLStudent()).Get(register.StudentID);
                if (student.Status == false)
                {
                    student.Status = true;
                    (new BLLStudent()).Update(student);
                }
                //
                btnRegister.Enabled = false;

                // Update data grid view
                lstRegister = (new BLLRegister()).GetByCourse(CourseID);
                bdRegister.DataSource = lstRegister;
                ShowStudentName();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký không thành công.\n" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kiểm tra lại thông tin thanh toán trước khi tiếp tục.\nNhấn Yes để thanh toán.", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                int index = dgvRegister.CurrentCell.RowIndex;

                string StudentID = (string)dgvRegister.Rows[index].Cells["StudentID"].Value;
                string CourseID = (string)dgvRegister.Rows[index].Cells["CourseID"].Value;
                string ReceiptID = txtReceiptID.Text;
                decimal Payment = nudPayment.Value;
                DateTime Date = DateTime.Now;

                Receipt receipt = new Receipt();
                receipt.ReceiptID = ReceiptID;
                receipt.StudentID = StudentID;
                receipt.CourseID = CourseID;
                receipt.Payment = Payment;
                receipt.Date = Date;

                string[] tempEmployee = txtEmployee.Text.Split('/');
                receipt.EmployeeID = tempEmployee[0].Trim();

                // Payment
                (new BLLReceipt()).Insert(receipt);
                bdReceipt.DataSource = (new BLLReceipt()).Get(StudentID, CourseID);

                // Next Receipt ID
                txtReceiptID.Text = (new BLLReceipt()).NextID();

                // Update register
                Register register = new Register();
                register = (new BLLRegister()).Get(StudentID, CourseID);
                register.Payment += nudPayment.Value;
                register.Debt -= nudPayment.Value;

                (new BLLRegister()).Update(register);
                bdRegister.DataSource = (new BLLRegister()).GetByCourse(CourseID);
                ShowStudentName();

                // Enable btnPayment
                btnPayment.Enabled = false;
                nudPayment.Value = 0;

                MessageBox.Show("Thanh toán thành công.", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Thanh toán không thành công.\n" + ex.Message, "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.No)
                    return;
            }
        }

        // Check Valid Register
        private bool ValidRegister()
        {
            if (string.IsNullOrEmpty(cmbStudent.Text) == false &&
                string.IsNullOrEmpty(txtCourse.Text) == false)
                return true;
            return false;
        }

        private void txtCourse_TextChanged(object sender, EventArgs e)
        {
            if (ValidRegister() == true)
                btnRegister.Enabled = true;
            else
                btnRegister.Enabled = false;
        }

        private void cmbStudent_TextChanged(object sender, EventArgs e)
        {
            if (ValidRegister() == true)
                btnRegister.Enabled = true;
            else
                btnRegister.Enabled = false;
        }

        private void nudPayment_ValueChanged(object sender, EventArgs e)
        {
            if (nudPayment.Value >= 100000)
                btnPayment.Enabled = true;
            else
                btnPayment.Enabled = false;

            try
            {
                int index = dgvRegister.CurrentCell.RowIndex;
                string StudentID = (string)dgvRegister.Rows[index].Cells["StudentID"].Value;
                string CourseID = (string)dgvRegister.Rows[index].Cells["CourseID"].Value;

                Register register = new Register();
                register = (new BLLRegister()).Get(StudentID, CourseID);

                if (register != null)
                    nudDebt.Value = register.Debt - nudPayment.Value;
            }
            catch (Exception)
            {
            }
        }

        private void treCourse_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeNode treeNode = treCourse.SelectedNode;

                string CourseID = treeNode.Tag.ToString();

                Level level = (new BLLLevel()).Get(CourseID);
                if (level != null) return;

                Course course = (new BLLCourse()).Get(CourseID);
                if (course == null) return;

                txtCourse.Text = course.CourseID + " / " + course.CourseName;

                nudTuition.Value = course.Tuition;

                //StudentName.DataSource = (new BLLStudent()).GetAll();
                //StudentName.DisplayMember = "StudentName";
                //StudentName.ValueMember = "StudentID";

                lstRegister = (new BLLRegister()).GetByCourse(CourseID);
                bdRegister.DataSource = lstRegister;
                ShowStudentName();
                nudExemption.Value = 0;
            }
            catch (Exception)
            {
            }
        }

        private void nudExemption_ValueChanged(object sender, EventArgs e)
        {
            string[] tempCourse = txtCourse.Text.Split('/');
            string CourseID = tempCourse[0].Trim();
            Course course = (new BLLCourse()).Get(CourseID);
            if (course == null) return;

            nudTuition.Value = course.Tuition - course.Tuition * (nudExemption.Value) / 100;
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbStudent.SelectedIndex;

            if (index == 0)
            {
                (new FrmFindStudent()).ShowDialog();
            }
            else if (index == 1)
            {
                (new FrmNewStudent()).ShowDialog();
            }

            string StudentID = Program.StudentID;
            Program.StudentID = string.Empty;

            Student student = new Student();
            student = (new BLLStudent()).Get(StudentID);
            if (student == null) return;

            cmbStudent.Items.Add(student.StudentID + " / " + student.StudentName);
            cmbStudent.SelectedIndex = cmbStudent.Items.Count - 1;
        }

        private void deleteTtoolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa đăng ký này?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                int index = dgvRegister.CurrentCell.RowIndex;
                string StudentID = (string)dgvRegister.Rows[index].Cells["StudentID"].Value;
                string CourseID = (string)dgvRegister.Rows[index].Cells["CourseID"].Value;

                (new BLLRegister()).Delete(StudentID, CourseID);

                MessageBox.Show("Đã xóa xong.", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                (new BLLStudent()).SetNotActive(StudentID);

                bdRegister.DataSource = (new BLLRegister()).GetByCourse(CourseID);
                ShowStudentName();
                // update number of stdent in course
                Course course = new DTLayer.Course();
                course = (new BLLCourse()).Get(CourseID);
                if (course != null)
                {
                    course.Number -= 1;
                    (new BLLCourse()).Update(course);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công.\n" + ex.Message, "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegister_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int index = dgvRegister.CurrentCell.RowIndex;
                string StudentID = (string)dgvRegister.Rows[index].Cells["StudentID"].Value;
                string CourseID = (string)dgvRegister.Rows[index].Cells["CourseID"].Value;

                Program.StudentID = StudentID;
                Program.CourseID = CourseID;

                (new FrmReceipt()).ShowDialog();
                lstRegister = (new BLLRegister()).GetByCourse(CourseID);
                bdRegister.DataSource = lstRegister;
                ShowStudentName();
            }
            catch (Exception)
            {
            }
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvRegister.CurrentCell.RowIndex;
                string StudentID = (string)dgvRegister.Rows[index].Cells["StudentID"].Value;
                string CourseID = (string)dgvRegister.Rows[index].Cells["CourseID"].Value;

                Program.StudentID = StudentID;
                Program.CourseID = CourseID;

                (new FrmEditRegister()).ShowDialog();

                lstRegister = (new BLLRegister()).GetByCourse(CourseID);
                bdRegister.DataSource = lstRegister;
                ShowStudentName();
            }
            catch (Exception)
            {
            }
        }

        private void nudDebt_ValueChanged(object sender, EventArgs e)
        {
            //if (nudDebt.Value <= 0) nudPayment.Enabled = false;
            //else nudPayment.Enabled = true;
        }

        private void exportToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvRegister.CurrentCell.RowIndex;
                string StudentID = (string)dgvRegister.Rows[index].Cells["StudentID"].Value;
                string CourseID = (string)dgvRegister.Rows[index].Cells["CourseID"].Value;
                List<Receipt> lstReceipt = new List<Receipt>();
                //Receipt receipt = new Receipt();
                lstReceipt = (new BLLReceipt()).Get(StudentID, CourseID);

                (new Report.FrmReceiptReport(lstReceipt)).ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        private void ShowStudentName()
        {
            foreach (DataGridViewRow row in dgvRegister.Rows)
            {
                string studentName = (new BLLStudent()).Get((string)row.Cells["StudentID"].Value).StudentName;
                row.Cells["StudentName"].Value = studentName;
            }
        }
    }
}
