using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHottel
{
    public partial class RegisterQL : Form
    {
        public RegisterQL()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string user = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            string CV = "QuanLy";
            Random rd = new Random();
            int id = rd.Next(200, 300);
            Nhanvien nv = new Nhanvien();
            if (nv.insertLogin(user, pass,CV,id))
            {
                MessageBox.Show("Thêm Quản Lý thành Công", "Register Quản Lý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Thất Bại xem lại thông tin", "Regiter Quản Lý", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
