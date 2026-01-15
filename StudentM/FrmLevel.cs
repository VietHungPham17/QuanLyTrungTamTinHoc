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
    public partial class FrmLevel : Form
    {
        private BindingSource bdLevel;

        public FrmLevel()
        {
            InitializeComponent();
            bdLevel = new BindingSource();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewLevel_Load(object sender, EventArgs e)
        {
            // Lấy tất cả cấp độ đổ lên dataGirdView
            bdLevel.DataSource = (new BLLLevel()).GetAll();
            dgvLevel.DataSource = bdLevel;
        }

        /// <summary>
        /// Gọi form thêm cấp độ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            (new FrmNewLevel()).ShowDialog();
            bdLevel.DataSource = (new BLLLevel()).GetAll();
        }

        /// <summary>
        /// Gọi form chỉnh sữa cấp độ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvLevel.CurrentCell.RowIndex;
                string LevelID = (string)dgvLevel.Rows[index].Cells["LevelID"].Value;

                // gán mã cấp độ hiện tại vào biến static
                Program.LevelID = LevelID;

                (new FrmEditLevel()).ShowDialog();

                // Cập nhật hiển thị
                bdLevel.DataSource = (new BLLLevel()).GetAll();
            }
            catch { }
        }

        /// <summary>
        /// Xóa cập độ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvLevel.CurrentCell.RowIndex;
                string LevelID = (string)dgvLevel.Rows[index].Cells["LevelID"].Value;

                if (MessageBox.Show("Bạn muốn xóa cấp độ này?",
                  "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                (new BLLLevel()).Delete(LevelID);

                MessageBox.Show("Đã xóa.",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bdLevel.DataSource = (new BLLLevel()).GetAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
