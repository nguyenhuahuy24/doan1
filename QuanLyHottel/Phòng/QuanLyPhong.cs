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
    public partial class QuanLyPhong : Form
    {
        My_DB mydb = new My_DB();
        Phong phong = new Phong();
        public QuanLyPhong()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButtonCheckChuaDat.Checked)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM TTPhong Where TrangThai = @TT", mydb.GetConnection);
                command.Parameters.Add("@TT", SqlDbType.Int).Value = 1;
                fillgrid(command);
            }
            if (radioButtonCheckDaDat.Checked)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM TTPhong Where TrangThai = @TT", mydb.GetConnection);
                command.Parameters.Add("@TT", SqlDbType.Int).Value = 0;
                fillgrid(command);
            }
        }
        public void fillgrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 20;
            dataGridView1.DataSource = phong.getshowkh(command);
            dataGridView1.AllowUserToAddRows = false;

        }

        private void QuanLyPhong_Load(object sender, EventArgs e)
        {
            
            Phong phong = new Phong();
            SqlCommand command = new SqlCommand("Select TenPhong,TrangThai,MKPhong from TTPhong ");

            dataGridView1.ReadOnly = true;

            dataGridView1.DataSource = phong.getshowkh(command);

            dataGridView1.AllowUserToAddRows = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
