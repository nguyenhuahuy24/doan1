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
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            SqlCommand command = new SqlCommand("Select HoTen,GioBD,GioKT,ChucVu,CaLamViec from BaoCaoNgay");

            dataGridView1.ReadOnly = true;

            dataGridView1.DataSource = phong.getshowkh(command);

            dataGridView1.AllowUserToAddRows = false;

        }
    }
}
