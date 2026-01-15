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
    /// Nhật ký hoạt động
    /// Theo dõi hoạt động đăng nhập đăng xuất
    /// Chỉ admin mới có thể sử dụng chức năng này
    /// </summary>
    public partial class FrmDiary : Form
    {
        private List<Diary> lstDiary;
        private BindingSource bdDiary;
        public FrmDiary()
        {
            InitializeComponent();
            lstDiary = new List<Diary>();
            bdDiary = new BindingSource();
        }

        private void FrmDiary_Load(object sender, EventArgs e)
        {
           // lstDiary = (new BLLDiary()).GetAll();
            bdDiary.DataSource = (new BLLDiary()).GetAll();
            dgvDiary.DataSource = bdDiary;
        }

        private void quitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
