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
    public partial class FrmNewTranscript : Form
    {
        private string CourseID;
        private string StudentID;
        private DateTime TestDate;

        public FrmNewTranscript()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewTranscript_Load(object sender, EventArgs e)
        {
            CourseID = Program.CourseID;
            StudentID = Program.StudentID;
            TestDate = Program.TestDate;

            Program.TestDate = DateTime.MinValue;
            Program.StudentID = string.Empty;
            Program.CourseID = string.Empty;

            // Lấy điểm của học viên học khóa học đó và ngày kiểm tra đó
            Transcript transcript = new Transcript();
            transcript = (new BLLTranscript()).Get(TestDate, CourseID, StudentID);

            if (transcript == null) return;

            // Nếu transcrip trả về có thì lấy dữ liệu của học viên đó đưa vào
            nudScore.Value = (decimal)transcript.Score;
            txtNote.Text = transcript.Note;

            // Nếu trang thái bằng true ( khóa điểm rồi ), thì thiết lập lại các button
            if (transcript.Status == true)
            {
                nudScore.Enabled = false;
                txtNote.Enabled = false;
                btnNew.Enabled = false;
            }
        }

        /// <summary>
        /// Chỉnh sữa điểm cho học viên, vì khi tạo kỳ thi đã cho điểm tất cả sinh viên là 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Transcript transcript = new Transcript();
                transcript = (new BLLTranscript()).Get(TestDate, CourseID, StudentID);

                transcript.Score = (double)nudScore.Value;
                transcript.Note = txtNote.Text;
                transcript.EmployeeID = Program.Username;

                (new BLLTranscript()).Update(transcript);
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Ghi điểm chưa xong.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
