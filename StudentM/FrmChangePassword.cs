using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTLayer;
using BLLayer;

namespace QuanLyTrungTamTinHoc
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy UserName từ người đăng nhập (Program.UserName là biến tĩnh)
            string username = Program.Username;

            // Lấy đối tượng Account từ UserName
            Account account = new Account();
            account = (new BLLAccount()).Get(username);
            if (account == null) return;

            // Kiểm tra tính hợp lệ
            if(account.Password!=txtOldPassword.Text)
            {
                MessageBox.Show("Mật khẩu cũ không đúng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtNewPassword.Text!=txtConfirm.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng.", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đổi mật khẩu
            account.Password = txtNewPassword.Text;
            (new BLLAccount()).Update(account);

            MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
