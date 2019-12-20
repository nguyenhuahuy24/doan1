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
    public partial class QuanLyLogin : Form
    {
        public QuanLyLogin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Nhanvien nv = new Nhanvien();
                string username = textBox1.Text;
                string password = textBox2.Text;
                if (nv.updateLogin(username, password))
                {
                    MessageBox.Show("Cập nhập thành công", " Cập Nhập Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thất Bại", " Cập Nhập Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void QuanLyLogin_Load(object sender, EventArgs e)
        {
            Nhanvien nv = new Nhanvien();
            SqlCommand command = new SqlCommand("SELECT * FROM TTNV as a, Login as b WHERE a.IdNhanVien = b.Id ");
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = nv.getLaoCong(command);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM TTNV as a, Login as b WHERE b.ChucVu like '" + "LeTan     " + "%' and a.IdNhanVien = b.Id ");
            fillGrid(command);
        }
        public void fillGrid(SqlCommand command)
        {
            Nhanvien nhanvien = new Nhanvien();
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = nhanvien.getAllTTKH(command);            
            dataGridView1.AllowUserToAddRows = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM TTNV as a, Login as b WHERE b.ChucVu like '"+"LaoCong   "+ "%' and  a.IdNhanVien = b.Id ");
            fillGrid(command);
        }
    }
}
