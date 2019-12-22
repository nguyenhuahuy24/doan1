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
    public partial class ThuNhap : Form
    {
        public ThuNhap()
        {
            InitializeComponent();
        }

        private void ThuNhap_Load(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            SqlCommand command = new SqlCommand("Select * from ThuNhap1 ");

            dataGridView1.ReadOnly = true;

            dataGridView1.DataSource = phong.getshowkh(command);

            dataGridView1.AllowUserToAddRows = false;

        }
    }
}
