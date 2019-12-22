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
    public partial class TTKhachHang : Form
    {
        Nhanvien NhanVien = new Nhanvien();
        public TTKhachHang()
        {
            InitializeComponent();
        }

        private void TTKhachHang_Load(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            SqlCommand command = new SqlCommand("Select * from QLKH ");

            dataGridView1.ReadOnly = true;

            dataGridView1.DataSource = phong.getshowkh(command);

            dataGridView1.AllowUserToAddRows = false;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM QLKH");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn piccol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 20;
            dataGridView1.DataSource = NhanVien.getAllTTKH(command);
            piccol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            piccol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
