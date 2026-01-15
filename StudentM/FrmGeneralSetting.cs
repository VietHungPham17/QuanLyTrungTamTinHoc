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
    /// Thiết lập dữ liệu cho trung tâm
    /// </summary>
    public partial class FrmGeneralSetting : Form
    {
        public FrmGeneralSetting()
        {
            InitializeComponent();
            Center center = new Center();
        }

        private void FrmGeneralSetting_Load(object sender, EventArgs e)
        {
            Center center = new Center();

            center = (new BLLCenter()).Get();

            if (center == null)
            {
                // Lấy mã trung tam tự động
                txtCenterID.Text = (new BLLCenter()).NextID();
                return;
            }

            txtCenterID.Text = center.CenterID;
            txtCenterName.Text = center.CenterName;
            txtAddress.Text = center.Address;
            txtPhoneNumber.Text = center.PhoneNumber;
            txtEmail.Text = center.Email;
            txtFax.Text = center.Fax;
            txtWebsite.Text = center.Website;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Center center = new Center();

                // add new
                if ((new BLLCenter()).Get() == null)
                {
                    center.CenterID = txtCenterID.Text;
                    center.CenterName = txtCenterName.Text;
                    center.Address = txtAddress.Text;
                    center.PhoneNumber = txtPhoneNumber.Text;
                    center.Email = txtEmail.Text;
                    center.Fax = txtFax.Text;
                    center.Website = txtWebsite.Text;

                    (new BLLCenter()).Insert(center);
                }
                // update
                else
                {
                    center.CenterID = txtCenterID.Text;
                    center.CenterName = txtCenterName.Text;
                    center.Address = txtAddress.Text;
                    center.PhoneNumber = txtPhoneNumber.Text;
                    center.Email = txtEmail.Text;
                    center.Fax = txtFax.Text;
                    center.Website = txtWebsite.Text;

                    (new BLLCenter()).Update(center);
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Thiết lập chưa thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
