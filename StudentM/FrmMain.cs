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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 500);

            // Đăng nhập bằng quyến admin thì mở Menu Quản trị ra (ban đầu form Quản trị ẩn)
            if ((new BLLEmployee()).Get(Program.Username).MajorID == "MJO00000")
            {
                adminToolStripMenuItem1.Visible = true;
            }
            // Remove tất cả các tab
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(tab);
            }
            // Load tab Chào mừng lên
            FrmWelcome frmWelcome = new FrmWelcome();
            frmWelcome.TopLevel = false;
            frmWelcome.Dock = DockStyle.Fill;
            frmWelcome.FormBorderStyle = FormBorderStyle.None;
            frmWelcome.Parent = tabPageWelcome;
            tabPageWelcome.Text = frmWelcome.Text;
            frmWelcome.Show();

            // Add tab Welcome vào, chọn nó
            tabControl1.TabPages.Add(tabPageWelcome);
            this.tabControl1.SelectedTab = tabPageWelcome;

            //
            string username = Program.Username;
            Employee employee = new Employee();
            employee = (new BLLEmployee()).Get(username);
            if (employee == null) return;

            // Hiển thị người đăng nhập
            userToolStripButton.Text = employee.EmployeeID + " / " + employee.EmployeeName;

            // Lấy tên trung tâm
            // Gán tên trung tâm thành tiêu đề form
            string Title = (new BLLCenter()).Get().CenterName;
            if (string.IsNullOrEmpty(Title) == false)
                this.Text = (new BLLCenter()).Get().CenterName + " - Student M";
        }

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            // Double click thì remove tab hiện tại
            TabPage currentTab = this.tabControl1.SelectedTab;
            try
            {
                currentTab.Controls.RemoveAt(0);
            }
            catch (Exception)
            {
            }
            this.tabControl1.Controls.Remove(currentTab);
        }

        /// <summary>
        /// Click vào để chọn tab Học viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void studentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageStudent)
                {
                    this.tabControl1.SelectedTab = tabPageStudent;
                    return;
                }
            }
            FrmStudent frmStudent = new FrmStudent();
            frmStudent.TopLevel = false;
            frmStudent.Dock = DockStyle.Fill;
            frmStudent.FormBorderStyle = FormBorderStyle.None;
            frmStudent.Parent = tabPageStudent;
            tabPageStudent.Text = frmStudent.Text;
            frmStudent.Show();
            this.tabControl1.Controls.Add(tabPageStudent);
            this.tabControl1.SelectedTab = tabPageStudent;
        }
        /// <summary>
        /// Click vào để chọn tab đăng ký
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageRegister)
                {

                    this.tabControl1.SelectedTab = tabPageRegister;
                    return;
                }
            }
            Fr frmRegistration = new Fr();
            frmRegistration.TopLevel = false;
            frmRegistration.Dock = DockStyle.Fill;
            frmRegistration.FormBorderStyle = FormBorderStyle.None;
            frmRegistration.Parent = tabPageRegister;
            tabPageRegister.Text = frmRegistration.Text;
            frmRegistration.Show();
            this.tabControl1.Controls.Add(tabPageRegister);
            this.tabControl1.SelectedTab = tabPageRegister;
        }

        /// <summary>
        ///  Click vào để chọn tab khóa học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void courseToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageCourse)
                {

                    this.tabControl1.SelectedTab = tabPageCourse;
                    return;
                }
            }
            FrmCourse frmCourse = new FrmCourse();
            frmCourse.TopLevel = false;
            frmCourse.Dock = DockStyle.Fill;
            frmCourse.FormBorderStyle = FormBorderStyle.None;
            frmCourse.Parent = tabPageCourse;
            tabPageCourse.Text = frmCourse.Text;
            frmCourse.Show();
            this.tabControl1.Controls.Add(tabPageCourse);
            this.tabControl1.SelectedTab = tabPageCourse;
        }

        /// <summary>
        ///  Click vào để chọn tab chấm thi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transcriptToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageTranscript)
                {

                    this.tabControl1.SelectedTab = tabPageTranscript;
                    return;
                }
            }
            FrmTranscript frmTranscript = new FrmTranscript();
            frmTranscript.TopLevel = false;
            frmTranscript.Dock = DockStyle.Fill;
            frmTranscript.FormBorderStyle = FormBorderStyle.None;
            frmTranscript.Parent = tabPageTranscript;
            tabPageTranscript.Text = frmTranscript.Text;
            frmTranscript.Show();
            this.tabControl1.Controls.Add(tabPageTranscript);
            this.tabControl1.SelectedTab = tabPageTranscript;
        }

        /// <summary>
        ///  Click vào để chọn tab nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageEmployee)
                {
                    this.tabControl1.SelectedTab = tabPageEmployee;
                    return;
                }
            }
            FrmEmployee demEmployee = new FrmEmployee();
            demEmployee.TopLevel = false;
            demEmployee.Dock = DockStyle.Fill;
            demEmployee.FormBorderStyle = FormBorderStyle.None;
            demEmployee.Parent = tabPageEmployee;
            tabPageEmployee.Text = demEmployee.Text;
            demEmployee.Show();
            this.tabControl1.Controls.Add(tabPageEmployee);
            this.tabControl1.SelectedTab = tabPageEmployee;
        }

        /// <summary>
        /// Click vào để gọi form Level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void levelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FrmLevel()).ShowDialog();
        }

        /// <summary>
        /// Click vào để gọi form chuyên ngành
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void majorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new FrmMajor()).ShowDialog();
        }

        /// <summary>
        /// Click vào để gọi form lịch sử
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diaryToolStripButton_Click(object sender, EventArgs e)
        {
            string Username = Program.Username;
            // Đăng nhập bằng quyền Admin mới xem được lịch sử hoạt động
            if ((new BLLEmployee()).Get(Program.Username).MajorID == "MJO00000")
            {
                (new FrmDiary()).ShowDialog();
            }
            else
            {
                MessageBox.Show("Chỉ người quản trị mới thực hiện được chức năng này.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Close();
        }

        private void diaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FrmDiary()).ShowDialog();
        }

        /// <summary>
        /// Click vào để chọn tab nợ học phí
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tuitionDebtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageTuitionDebt)
                {

                    this.tabControl1.SelectedTab = tabPageTuitionDebt;
                    return;
                }
            }
            FrmTuitionDebt frmTuitionDebt = new FrmTuitionDebt();
            frmTuitionDebt.TopLevel = false;
            frmTuitionDebt.Dock = DockStyle.Fill;
            frmTuitionDebt.FormBorderStyle = FormBorderStyle.None;
            frmTuitionDebt.Parent = tabPageTuitionDebt;
            tabPageTuitionDebt.Text = frmTuitionDebt.Text;
            frmTuitionDebt.Show();
            this.tabControl1.Controls.Add(tabPageTuitionDebt);
            this.tabControl1.SelectedTab = tabPageTuitionDebt;
        }

        /// <summary>
        /// Click vào để chọn tab bảng điểm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportTranscriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageTranscriptSummary)
                {

                    this.tabControl1.SelectedTab = tabPageTranscriptSummary;
                    return;
                }
            }
            FrmTranscriptSummary frmTranscriptSummary = new FrmTranscriptSummary();
            frmTranscriptSummary.TopLevel = false;
            frmTranscriptSummary.Dock = DockStyle.Fill;
            frmTranscriptSummary.FormBorderStyle = FormBorderStyle.None;
            frmTranscriptSummary.Parent = tabPageTranscriptSummary;
            tabPageTranscriptSummary.Text = frmTranscriptSummary.Text;
            frmTranscriptSummary.Show();
            this.tabControl1.Controls.Add(tabPageTranscriptSummary);
            this.tabControl1.SelectedTab = tabPageTranscriptSummary;
        }

        /// <summary>
        /// Click vào để chọn tab học phí
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportTuitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageTuitionSummary)
                {

                    this.tabControl1.SelectedTab = tabPageTuitionSummary;
                    return;
                }
            }
            FrmTuitionSummary frmFrmTuitionSummary = new FrmTuitionSummary();
            frmFrmTuitionSummary.TopLevel = false;
            frmFrmTuitionSummary.Dock = DockStyle.Fill;
            frmFrmTuitionSummary.FormBorderStyle = FormBorderStyle.None;
            frmFrmTuitionSummary.Parent = tabPageTuitionSummary;
            tabPageTuitionSummary.Text = frmFrmTuitionSummary.Text;
            frmFrmTuitionSummary.Show();
            this.tabControl1.Controls.Add(tabPageTuitionSummary);
            this.tabControl1.SelectedTab = tabPageTuitionSummary;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Đăng xuất thì cho trạng thái Account bằng false
            string username = Program.Username;
            Account account = new Account();
            account = (new BLLAccount()).Get(username);
            if (account.Status == true)
            {
                account.Status = false;
                (new BLLAccount()).Update(account);
            }

            (new BLLDiary()).Insert(account.Username, "Đăng xuất hệ thống", "Thành công", false);

            Application.Restart();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            string username = Program.Username;
            (new BLLDiary()).Insert(username, "Đăng xuất hệ thống", "Thành công", false);
            base.OnClosing(e);
        }

        private void transcriptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            transcriptToolStripMenuItem2_Click(null, null);
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            studentToolStripMenuItem2_Click(null, null);
        }

        private void courseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            courseToolStripMenuItem2_Click(null, null);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new Help.FrmAboutStudentM()).ShowDialog();
        }

        /// <summary>
        /// Click vào để chọn tab thống kê doanh thu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void revenueStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageRevenueStatistics)
                {

                    this.tabControl1.SelectedTab = tabPageRevenueStatistics;
                    return;
                }
            }
            Statistics.FrmRevenueStatistics frmRevenueStatistics =
                new Statistics.FrmRevenueStatistics();
            frmRevenueStatistics.TopLevel = false;
            frmRevenueStatistics.Dock = DockStyle.Fill;
            frmRevenueStatistics.FormBorderStyle = FormBorderStyle.None;
            frmRevenueStatistics.Parent = tabPageRevenueStatistics;
            tabPageRevenueStatistics.Text = frmRevenueStatistics.Text;
            frmRevenueStatistics.Show();
            this.tabControl1.Controls.Add(tabPageRevenueStatistics);
            this.tabControl1.SelectedTab = tabPageRevenueStatistics;
        }
        /// <summary>
        /// Gọi form đổi mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FrmChangePassword()).ShowDialog();
        }

        private void userToolStripButton_Click(object sender, EventArgs e)
        {
            Program.EmployeeID = Program.Username;
            (new FrmEditEmployee()).ShowDialog();
            Employee employee = new Employee();
            employee = (new BLLEmployee()).Get(Program.Username);
            if (employee == null) return;

            userToolStripButton.Text = employee.EmployeeID + " / " + employee.EmployeeName;
        }

        /// <summary>
        /// Click vào để chọn tab thống kê chất lượng đào tạo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void courseStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == tabPageEducationQuality)
                {
                    this.tabControl1.SelectedTab = tabPageEducationQuality;
                    return;
                }
            }
            Statistics.FrmEducationQuality frmEducationQuality =
                new Statistics.FrmEducationQuality();

            frmEducationQuality.TopLevel = false;
            frmEducationQuality.Dock = DockStyle.Fill;
            frmEducationQuality.FormBorderStyle = FormBorderStyle.None;
            frmEducationQuality.Parent = tabPageEducationQuality;
            tabPageEducationQuality.Text = frmEducationQuality.Text;
            frmEducationQuality.Show();
            this.tabControl1.Controls.Add(tabPageEducationQuality);
            this.tabControl1.SelectedTab = tabPageEducationQuality;
        }

        private void acountManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FrmAccount()).ShowDialog();
        }

        private void generalSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FrmGeneralSetting()).ShowDialog();

            string Title = (new BLLCenter()).Get().CenterName;
            if (string.IsNullOrEmpty(Title) == false)
                this.Text = (new BLLCenter()).Get().CenterName + " - Student M";
        }

        private void registerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            registerToolStripMenuItem2_Click(null, null);
        }
    }
}
