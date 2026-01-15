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
    public partial class FrmAccount : Form
    {
        private BindingSource bdAccount;
        public FrmAccount()
        {
            InitializeComponent();
            bdAccount = new BindingSource();
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            bdAccount.DataSource = (new BLLAccount()).GetAll();
            dgvAccount.DataSource = bdAccount;
        }

        // Đặt lại mật khẩu
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy UserName hiện tại
                int index = dgvAccount.CurrentCell.RowIndex;
                string username = (string)dgvAccount.Rows[index].Cells["Username"].Value;

                if (MessageBox.Show("Bạn có muốn đặt lại mật khẩu?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                // Lấy tài khoản từ UserName
                Account account = new Account();
                account = (new BLLAccount()).Get(username);

                if (account == null) return;    // Không làm gì hết

                //Đặt lại mật khẩu bằng UserName
                account.Password = account.Username;
                account.Status = false;
                (new BLLAccount()).Update(account);
                MessageBox.Show("Đặt lại mật khẩu thành công.", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                bdAccount.DataSource = (new BLLAccount()).GetAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Đặt lại mật khẩu không thành công.", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
