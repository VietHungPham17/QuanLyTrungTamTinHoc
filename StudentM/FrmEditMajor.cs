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
    /// Chỉnh sữa chuyên ngành
    /// </summary>
    public partial class FrmEditMajor : Form
    {
        public FrmEditMajor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string LevelID = txtMajorID.Text;

                Major major = new Major();
                major = (new BLLMajor()).Get(LevelID);

                if (major == null) return;

                major.MajorID = txtMajorID.Text;
                major.MajorName = txtMajorName.Text;
                major.JobFunction = txtJobFunction.Text;

                (new BLLMajor()).Update(major);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Chỉnh sửa thất bại.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditMajor_Load(object sender, EventArgs e)
        {
            // Lấy mã chuyên ngành từ biến tĩnh
            string MajorID = Program.MajorID;
            Program.MajorID = string.Empty;

            Major major = new Major();
            major = (new BLLMajor()).Get(MajorID);

            txtMajorID.Text = major.MajorID;
            txtMajorName.Text = major.MajorName;
            txtJobFunction.Text = major.JobFunction;
        }
    }
}
