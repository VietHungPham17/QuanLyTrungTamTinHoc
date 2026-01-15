using BLLayer;
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
    public partial class FrmMajor : Form
    {
        private BindingSource bdMajor;

        public FrmMajor()
        {
            InitializeComponent();
            bdMajor = new BindingSource();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            (new FrmNewMajor()).ShowDialog();
            bdMajor.DataSource = (new BLLMajor()).GetAll();
        }

        private void FrmMajor_Load(object sender, EventArgs e)
        {
            bdMajor.DataSource = (new BLLMajor()).GetAll();
            dgvMajor.DataSource = bdMajor;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MajorID = (string)dgvMajor.Rows[dgvMajor.CurrentCell.RowIndex].Cells["MajorID"].Value;
            Program.MajorID = MajorID;
            (new FrmEditMajor()).ShowDialog();
            bdMajor.DataSource = (new BLLMajor()).GetAll();
        }
        /// <summary>
        /// Xóa chuyên ngành
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
           

            try
            {
                int index = dgvMajor.CurrentCell.RowIndex;
                string MajorID = (string)dgvMajor.Rows[index].Cells["MajorID"].Value;

                if (MessageBox.Show("Bạn muốn xóa chuyên ngành này?",
                 "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                (new BLLMajor()).Delete(MajorID);

                MessageBox.Show("Đã xóa.",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bdMajor.DataSource = (new BLLMajor()).GetAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
