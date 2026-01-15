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
    public partial class FrmEditReceipt : Form
    {
        private string ReceiptID;
        public FrmEditReceipt(string ReceiptID)
        {
            InitializeComponent();
            this.ReceiptID = ReceiptID;
        }

        private void btnSaveAndQuit_Click(object sender, EventArgs e)
        {

        }

        private void FrmEditReceipt_Load(object sender, EventArgs e)
        {
            Receipt receipt = new Receipt();
            receipt = (new BLLReceipt()).Get(ReceiptID);

            nudPayment.Value = receipt.Payment;
            dtpDate.Value = dtpDate.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Receipt receipt = new Receipt();
                receipt = (new BLLReceipt()).Get(ReceiptID);

                receipt.Payment = nudPayment.Value;
                dtpDate.Value = dtpDate.Value;
                // chỉnh sửa
                (new BLLReceipt()).Update(receipt);


                string StudentID = receipt.StudentID;
                string CourseID = receipt.CourseID;

                List<Receipt> lstReceipt = new List<Receipt>();
                lstReceipt = (new BLLReceipt()).Get(StudentID, CourseID);
                // Cập nhật lại thông tin đăng ký
                Register register = new Register();
                register = (new BLLRegister()).Get(StudentID, CourseID);
                register.Payment = lstReceipt.Sum(r=>r.Payment);
                register.Debt = register.Total- lstReceipt.Sum(r => r.Payment);
                // cập nhật lại bảng hóa đơn
                (new BLLRegister()).Update(register);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa không thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
