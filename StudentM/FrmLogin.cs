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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) == true)
            {
                MessageBox.Show("Tên tài khoản không được để trống.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            // Lấy account theo UserName
            Account account = new Account();
            account = (new BLLAccount()).Get(username);

            if (account != null && account.Password == password)
            {
                // Gán UserName vào biến static
                Program.Username = account.Username;

                // Nếu check ghi nhớ thì cho tất cả account có trạng thái bằng false
                // Cho account hiện tại trạng thái true
                // Cập nhật lại dữ liệu
                if (chkAutoLogin.Checked == true)
                {
                    foreach (Account acc in (new BLLAccount().GetAll()))
                    {
                        acc.Status = false;
                        (new BLLAccount()).Update(acc);
                    }
                    account.Status = true;
                    (new BLLAccount()).Update(account);
                }

                // Thêm lịch sử hoạt động
                (new BLLDiary()).Insert(account.Username, "Đăng nhập hệ thống", "Thành công", false);

                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu.", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {

                    (new BLLDiary()).Insert(account.Username, "Đăng nhập hệ thống", "Thất bại", false);
                }
                catch (Exception)
                {
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            SetInitialize SetInitialize = new SetInitialize();
            SetInitialize.Init(true);

            Account account = new Account();

            // Lấy tất cả account đổ vào list
            List<Account> lstAccount = new List<Account>();
            lstAccount = (new BLLAccount()).GetAll();

            foreach (Account acc in lstAccount)
            {
                txtUsername.Text = acc.Username;
                txtPassword.Text = acc.Password;
                // Account nào có trạng thái = true thì lấy account đó rồi dừng
                if (acc.Status == true)
                {
                    account = acc;
                    break;
                }
            }

            if (account.Username != null)
            {
                try
                {
                    // Thêm lịch sử
                    (new BLLDiary()).Insert(account.Username, "Đăng nhập hệ thống", "Thành công", true);
                }
                catch (Exception)
                {
                }
                // Gán UserName vào biến static
                Program.Username = account.Username;
                this.Close();
            }

            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
