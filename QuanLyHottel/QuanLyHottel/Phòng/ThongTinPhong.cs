using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHottel
{
    public partial class ThongTinPhong : Form
    {
        Nhanvien NhanVien = new Nhanvien();
        Phong phong = new Phong();
        public ThongTinPhong()
        {
            InitializeComponent();
        }

        private void ThongTinPhong_Load(object sender, EventArgs e)
        {

            Phong phong = new Phong();
            SqlCommand command = new SqlCommand("Select * from ChiTietPhong ");

            dataGridView1.ReadOnly = true;

            dataGridView1.DataSource = phong.getshowkh(command);

            dataGridView1.AllowUserToAddRows = false;

            comboBoxRoomName.DataSource = phong.getDatPhong();
            comboBoxRoomName.DisplayMember = "TenPhong";
            comboBoxRoomName.ValueMember = "MaPhong";
            comboBoxRoomName.SelectedItem = null;
        }

        private void Buttonedit_Click(object sender, EventArgs e)
        {
            string Maphong = (string)comboBoxRoomName.SelectedValue;
            string TenPhong = (string)comboBoxRoomName.Text;
            int COCACOLA = (int)numericUpDownCOCA.Value;
            int BEER = (int)numericUpDownTiger.Value;
            int SNACK = (int)numericUpDownSncack.Value;
            int RUOU = (int)numericUpDownRuou.Value;
            int MI = (int)numericUpDownMi.Value;
          
            if (verif1())
            {

                if (phong.updateChitietPhong(Maphong, TenPhong, COCACOLA, BEER, SNACK, RUOU, MI))
                {
                    MessageBox.Show("Cập Nhập Thành Công", " Information Room", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Thất Bại Xem Lại", " Information Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa Nhập Tên Phòng", "  Information Room ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Refresh();

            bool verif1()
            {
                if ((comboBoxRoomName.Text.Trim() == ""))

                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM ChiTietPhong");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 20;
            dataGridView1.DataSource = NhanVien.getLaoCong(command);
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
