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
    /// Chỉnh sử cấp độ
    /// </summary>
    public partial class FrmEditLevel : Form
    {
        public FrmEditLevel()
        {
            InitializeComponent();
        }

        private void FrmEditLevel_Load(object sender, EventArgs e)
        {
            // Lấy mã cấp độ từ biến tĩnh 
            string LevelID = Program.LevelID;
            Program.LevelID = string.Empty;

            Level level = new Level();
            level = (new BLLLevel()).Get(LevelID);

            txtLevelID.Text = level.LevelID;
            txtLevelName.Text = level.LevelName;
            txtDescription.Text = level.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string LevelID = txtLevelID.Text;

                Level level = new Level();
                level = (new BLLLevel()).Get(LevelID);

                if (level == null) return;

                level.LevelName = txtLevelName.Text;
                level.Description = txtDescription.Text;

                // Cập nhật
                (new BLLLevel()).Update(level);
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
    }
}
