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
    public partial class BaoCaoThang : Form
    {
        public BaoCaoThang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            LuongNV nv = new LuongNV();
            SqlCommand command = new SqlCommand("Select HoTen,ChucVu,sum(Luong) as Luong from BaoCaoLuong where convert(char(7), GioKT,21)='2019-"+textBox1.Text+"' group by HoTen,ChucVu");
            nv.dataGridViewLuong.ReadOnly = true;

            nv.dataGridViewLuong.DataSource = phong.getshowkh(command);

            nv.dataGridViewLuong.AllowUserToAddRows = false;
            this.Close();
            nv.Show();
        }

        private void BaoCaoThang_Load(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            SqlCommand command = new SqlCommand("Select * from BaoCaoLuong ");

            dataGridView1.ReadOnly = true;

            dataGridView1.DataSource = phong.getshowkh(command);

            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
