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
    public partial class FrmNewLevel : Form
    {
        public FrmNewLevel()
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
                Level level = new Level();
                level.LevelID = txtLevelID.Text;
                level.LevelName = txtLevelName.Text;
                level.Description = txtDescription.Text;

                (new BLLLevel()).Insert(level);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm không thành công.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNewLevel_Load(object sender, EventArgs e)
        {
            txtLevelID.Text = (new BLLLevel()).NextID();
        }
    }
}
