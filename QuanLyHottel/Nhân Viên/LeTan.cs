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
    public partial class LeTan : Form
    {
        Nhanvien nhanvien = new Nhanvien();
        public LeTan()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonBD_Click(object sender, EventArgs e)
        {
            int ca;
            DemGio dg = new DemGio();
            My_DB mydb = new My_DB();
            int id = Global.GlobalUserId;
            string chucvu = "len tan";
            DateTime GioBD = DateTime.Now;
            string HT;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("Select * From BaoCaoNgay WHERE @ID= Id", mydb.GetConnection);
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            SqlCommand command3 = new SqlCommand("Select Fname From TTNV WHERE IdNhanVien =" + id);
            DataTable table3 = nhanvien.getLaoCong(command3);
            HT = (string)table3.Rows[0]["Fname"];
            
            SqlCommand command2 = new SqlCommand("Select CaLamViec From TTNV WHERE IdNhanVien =" + id);
            DataTable table2 = nhanvien.getLaoCong(command2);
            ca = (int)table2.Rows[0]["CaLamViec"];
            if ((table.Rows.Count) > 0)
            {
                MessageBox.Show("Đã Bắt Đầu Rồi Nhé", " Start Agint", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);             
            }
            else if (dg.inserBaoCaoNgay(id,HT, GioBD, chucvu, ca))
            {
                dg.inserBaoCaoThang(id, GioBD, chucvu, ca);
                MessageBox.Show("Bắt Đầu Làm Việc", " Start", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bị Lỗi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonKT_Click(object sender, EventArgs e)
        {
            
            int id = Global.GlobalUserId;
            My_DB mydb = new My_DB();
            DemGio dg = new DemGio();
            DateTime GioBD;
            string fname;
            int ca;
            string HoTen;
            double luong = 0;
            Nhanvien nhanvien = new Nhanvien();
            DateTime gioKT = DateTime.Now;
            int tonggiolam;
            int tongphutlam;

           
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("Select * From BaoCaoNgay WHERE @ID= Id", mydb.GetConnection);
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = id; ;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            SqlCommand command4 = new SqlCommand("Select CaLamViec From TTNV WHERE IdNhanVien =" + id);
            DataTable table4 = nhanvien.getLaoCong(command4);
            ca = (int)table4.Rows[0]["CaLamViec"];

            SqlCommand command1 = new SqlCommand("Select Fname From TTNV WHERE IdNhanVien =" + id);
            DataTable table1 = nhanvien.getLaoCong(command1);
            fname = table1.Rows[0]["Fname"].ToString();

            SqlCommand command3 = new SqlCommand("Select HoTen From BaoCaoNgay WHERE Id =" + id);
            DataTable table3 = nhanvien.getLaoCong(command3);
            HoTen = table3.Rows[0]["HoTen"].ToString();

            SqlCommand command2 = new SqlCommand("Select GioBD From BaoCaoNgay WHERE Id =" + id);
            DataTable table2 = nhanvien.getLaoCong(command2);
            GioBD = (DateTime)table2.Rows[0]["GioBD"];

            if (table.Rows.Count > 0)
            {
                

                    if (gioKT.Hour < GioBD.Hour)
                    {
                        if (gioKT.Minute < GioBD.Minute)
                        {
                            tonggiolam = gioKT.Hour + 24 - GioBD.Hour - 1;
                            tongphutlam = gioKT.Minute + 60 - GioBD.Minute;
                        }
                        else
                        {
                            tonggiolam = gioKT.Hour + 24 - GioBD.Hour;
                            tongphutlam = gioKT.Minute - GioBD.Minute;

                        }
                    }
                    else
                    {
                        if (gioKT.Minute < GioBD.Minute)
                        {
                            tonggiolam = gioKT.Hour - GioBD.Hour - 1;
                            tongphutlam = gioKT.Minute + 60 - GioBD.Minute;
                        }
                        else
                        {
                            tonggiolam = gioKT.Hour - GioBD.Hour;
                            tongphutlam = gioKT.Minute - GioBD.Minute;

                        }
                    }
                    if (tonggiolam >= 8)
                    {
                        if (tonggiolam < 9)
                        {
                            luong = Math.Round(8 * 60000 + ((float)tongphutlam / 60) * 0, 0);

                        }
                        else if (tonggiolam >= 9)
                        {
                            luong = Math.Round(tonggiolam * 600000 + ((float)tongphutlam / 60) * 0, 0);


                        }
                    }
                    else
                    {
                        if (tonggiolam == 7 && tongphutlam >= 45)
                        {
                            luong = Math.Round(8 * 60000 + ((float)tongphutlam / 60) * 0, 0);
                        }
                        else
                        {
                            luong = Math.Round(8 * 60000 + ((float)tongphutlam / 60) * 0 - (8 - tonggiolam) * 100000, 0);
                        }
                    }



                    try
                    {
                        if (ca == 1 && ca == 2)
                            ca = ca + 1;
                        else if (ca == 3)
                            ca = 1;
                        if (dg.updateBaoCaoNgay(id, fname, gioKT, tonggiolam, tongphutlam, luong))
                        {
                            dg.deleteBaoCao(id);
                            dg.updateBaoCaoThang(id, fname, gioKT, tonggiolam, tongphutlam, luong);
                            MessageBox.Show("Kết Thúc Giờ Làm", " End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Error Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

            }

            else
            {
                MessageBox.Show(" Please Login", " Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void NhậnPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatPhong dp = new DatPhong();
            dp.Show();
        }

        private void TrảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrPhong tp = new TrPhong();
            tp.Show();
        }

        private void TinhTrạngPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinPhong tt = new ThongTinPhong();
            tt.Show();
        }

        private void LeTan_Load(object sender, EventArgs e)
        {
            int UID = Global.GlobalUserId;
            int ca;
            SqlCommand command1 = new SqlCommand("Select CaLamViec From TTNV WHERE IdNhanVien =" + UID);
            DataTable table1 = nhanvien.getLaoCong(command1);
            ca = (int)table1.Rows[0]["CaLamViec"];
            dataGridView2.ReadOnly = true;
            dataGridView2.RowTemplate.Height = 40;
            dataGridView2.DataSource = nhanvien.showCaLamViecItMeLaoCong(ca);
            dataGridView2.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = nhanvien.showCaLamViecItMeLeTan(ca);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
