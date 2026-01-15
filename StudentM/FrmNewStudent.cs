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
    public partial class FrmNewStudent : Form
    {

        public FrmNewStudent()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewStudent_Load(object sender, EventArgs e)
        {
            // Custom Fotmat date timepicker
            dtpBirthDay.CustomFormat = "dd/MM/yyyy";

            string StudentID = (new BLLStudent()).NextID();
            txtStudentID.Text = StudentID;
        }

        private bool NewStudent()
        {
            try
            {
                Student student = new Student();

                student.StudentID = txtStudentID.Text;
                student.StudentName = txtStudentName.Text;
                student.Gender = cmbGender.Text;
                student.BirthDay = dtpBirthDay.Value;
                student.PhoneNumber = txtPhoneNumber.Text;
                student.Email = txtEmail.Text;
                student.Address = cmbAddress.Text;
                student.Staying = cmbStaying.Text;
                student.Education = cmbEducation.Text;
                student.University = cmbUniversity.Text;
                student.Status = false;// alwway 

                try
                {
                    MemoryStream stream = new MemoryStream();
                    picAvatar.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    student.Avatar = stream.ToArray();
                }
                catch (Exception)
                {
                }

                if (string.IsNullOrEmpty(student.StudentID) ||
                    string.IsNullOrEmpty(student.StudentName))
                {
                    MessageBox.Show("Bạn chưa nhập mã hoặc tên học viên.",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStudentName.Focus();
                    return false;
                }

                (new BLLStudent()).Insert(student);

                Program.StudentID = student.StudentID;
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm học viên này. Vui lòng kiểm tra lại thông tin đã nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnInsertAndQuit_Click(object sender, EventArgs e)
        {
            if (NewStudent() == true) this.Close();
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if(ofd.ShowDialog()==DialogResult.OK)
            {
                string FileName = ofd.FileName;

                if (string.IsNullOrEmpty(FileName)) return;

                try
                {
                    picAvatar.Image = Image.FromFile(FileName);
                }
                catch (Exception)
                {

                    MessageBox.Show("Tệp tin không hợp lệ.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
