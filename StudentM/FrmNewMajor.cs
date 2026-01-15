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
    public partial class FrmNewMajor : Form
    {
        public FrmNewMajor()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Major major = new Major();

                major.MajorID = txtMajorID.Text;
                major.MajorName = txtMajorName.Text;
                major.JobFunction = txtJobFunction.Text;

                (new BLLMajor()).Insert(major);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm không thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNewMajor_Load(object sender, EventArgs e)
        {
            txtMajorID.Text = (new BLLMajor()).NextID();
        }
    }
}
