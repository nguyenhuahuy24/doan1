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
    public partial class TrPhong : Form
    {
        My_DB mydb = new My_DB();
        Phong phong = new Phong();
        Nhanvien nhanvien = new Nhanvien();
        public TrPhong()
        {
            InitializeComponent();
        }

        private void buttonTraPhong_Click(object sender, EventArgs e)
        {
            int Coca = (int)numericUpDownCOCA.Value;
            int Tiger = (int)numericUpDownTiger.Value;
            int Ruou = (int)numericUpDownRuou.Value;
            int Mi = (int)numericUpDownMi.Value;
            int Snack = (int)numericUpDownSncack.Value;
            DateTime NgayKT = DateTime.Now;
            int day = NgayKT.Day;
            int month = NgayKT.Month;
            int year = NgayKT.Year;
            
            string MAKhach = comboBox1.SelectedValue.ToString();
            DateTime NgayBD;
            string MaPhong;
            int tonggio;
            int tongngay;
            int vp1;
            int vp2;
            int vp3;
            int vp4;
            int vp5;
            string tenPhong;
            string TenKhang;
            string DC;
            string DT;
            string GT;
            string TP;
            Random rb = new Random();
            int mk = rb.Next(1, 99);
            //
            SqlCommand command5 = new SqlCommand("Select TenKH From TTKH where MaKH like '" + MAKhach + "%'");
            DataTable table5 = phong.getshowkh(command5);
            TenKhang = (string)table5.Rows[0]["TenKH"];
            SqlCommand command6 = new SqlCommand("Select GioiTinh From TTKH where MaKH like '" + MAKhach + "%'");
            DataTable table6 = phong.getshowkh(command6);
            GT = (string)table6.Rows[0]["GioiTinh"];
            SqlCommand command7 = new SqlCommand("Select DiaChi From TTKH where MaKH like '" + MAKhach + "%'");
            DataTable table7 = phong.getshowkh(command7);
            DC = (string)table7.Rows[0]["DiaChi"];
            SqlCommand command8 = new SqlCommand("Select DienThoai From TTKH where MaKH like '" + MAKhach + "%'");
            DataTable table8 = phong.getshowkh(command8);
            DT = (string)table8.Rows[0]["DienThoai"];
            SqlCommand command9 = new SqlCommand("Select ThuePhong From TTKH where MaKH like '" + MAKhach + "%'");
            DataTable table9 = phong.getshowkh(command9);
            TP = (string)table9.Rows[0]["ThuePhong"];
            //
            SqlCommand command1 = new SqlCommand("Select NgayBatDau From TTKH where MaKH like '" + MAKhach + "%'");
            DataTable table1 = phong.getshowkh(command1);
            NgayBD = (DateTime)table1.Rows[0]["NgayBatDau"];
            SqlCommand command2 = new SqlCommand("Select ThuePhong From TTKH ");
            DataTable table2 = phong.getshowkh(command2);
            MaPhong = table2.Rows[0]["ThuePhong"].ToString();
            SqlCommand command4 = new SqlCommand("Select * From ChiTietPhong where MaPhong like '" + MaPhong + "%'");
            DataTable table4 = phong.getshowkh(command4);
            vp1 = (int)table4.Rows[0]["VatPham1"];
            vp2 = (int)table4.Rows[0]["VatPham2"];
            vp3 = (int)table4.Rows[0]["VatPham3"];
            vp4 = (int)table4.Rows[0]["VatPham4"];
            vp5 = (int)table4.Rows[0]["VatPham5"];       
            tenPhong = table4.Rows[0]["TenPhong"].ToString();
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataTable table3 = new DataTable();
            SqlCommand command3 = new SqlCommand("Select * From TTKH WHERE @MA = MaKH", mydb.GetConnection);
            command3.Parameters.Add("@MA", SqlDbType.VarChar).Value = MAKhach;
            adapter1.SelectCommand = command3;
            adapter1.Fill(table3);         
             TimeSpan tn = NgayKT - NgayBD;
            HoaDon hd = new HoaDon();        
            if (Coca <= vp1 && Tiger <= vp2 && Snack <= vp3 && Ruou <= vp4 && Mi <= vp5)
            {
                vp1 = vp1 - Coca;
                vp2 = vp2 - Tiger;
                vp3 = vp3 - Snack;
                vp4 = vp4 - Ruou;
                vp5 = vp5 - Mi;
                labelgio.Text = Convert.ToString(tn.Hours) + "  Gio";
                labelNgay.Text = Convert.ToString(tn.Days) + "  Ngay";
                labelTien.Text = Convert.ToString((tn.Days * 1000000) + (tn.Hours * (1000000 / 24)) + (Coca * 15000 + Snack * 10000 + Ruou * 200000 + Tiger * 20000 + Mi * 10000)) + "  VNĐ";
                int ThuNhap = Convert.ToInt32((tn.Days * 1000000) + (tn.Hours * (1000000 / 24)) + (Coca * 15000 + Snack * 10000 + Ruou * 200000 + Tiger * 20000 + Mi * 10000));
                if (table3.Rows.Count <= 0)
                {
                    MessageBox.Show("MA KHACH HANG CHUA DUOC DAT PHONG", " nhap lai", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (phong.updateTraPhong(MaPhong,mk))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();
                    SqlCommand command = new SqlCommand("Select * From TTKH WHERE @MA = MaKH", mydb.GetConnection);
                    command.Parameters.Add("@MA", SqlDbType.VarChar).Value = MAKhach;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    fillgrid(command);
                    if (phong.updateNGayKT(MAKhach, NgayKT))
                    {
                        Global.SetGlobalUserId2(MAKhach);
                        phong.insertThuNhap(NgayKT, ThuNhap);
                        phong.updateNGayKTForQL(MAKhach, NgayKT);
                        phong.updateChitietPhong(MaPhong, tenPhong, vp1, vp2, vp3, vp4, vp5);
                        
                        
                        hd.TextBoxMaKHHD.Text = MAKhach;
                        hd.TextBoxNameKHHD.Text = TenKhang;
                        hd.TextBoxPhoneHD.Text = DT;
                        if (GT == "Female")
                        {
                            hd.radioButtonFemaleHD.Checked = true;
                        }
                        else
                        {
                            hd.radioButtonMaleHD.Checked = true;
                        }
                        hd.TextBoxTPHD.Text = TP;
                        hd.TextBoxDCHD.Text = DC;
                        hd.DatetimeNPHD.Value = NgayBD;
                        hd.DatetimeTPHD.Value = NgayKT;
                        hd.labelcoca.Text = "CoCaCoLa(15k/1): "+Convert.ToString(Coca);
                        hd.labelTB.Text = "Tiger Beer(20k/1): " + Convert.ToString(Coca);
                        hd.labels.Text = "Snack (10k/1): " + Convert.ToString(Snack);
                        hd.labelVK.Text = "Vodka (200k/1): " + Convert.ToString(Ruou);
                        hd.labelN.Text = "Noodles(10k/1): " + Convert.ToString(Mi);
                        hd.labeltien.Text = Convert.ToString((tn.Days * 1000000) + (tn.Hours * (1000000 / 24)) + (Coca * 15000 + Snack * 10000 + Ruou * 200000 + Tiger * 20000 + Mi * 10000)) + "  VNĐ";
                        hd.labelgio.Text = Convert.ToString(tn.Hours) + "  Gio";
                        hd.labelngay.Text = Convert.ToString(tn.Days) + "  Ngay";
                        this.Close();
                        hd.Show();

                    }
                    else
                    {
                        MessageBox.Show("Lỗi Update", "Trả Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Emty fields", " Thue Phong ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("So Luonng Vat Pham Nhap Vao La Sai Lech So Voi Vat Pham Trong Phong", " Nhap Lai ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void fillgrid(SqlCommand command)
        {
            dataGridViewKH.ReadOnly = true;
            dataGridViewKH.RowTemplate.Height = 40;
            dataGridViewKH.DataSource = phong.getshowkh(command);
            dataGridViewKH.AllowUserToAddRows = false;

        }
        private void TrPhong_Load(object sender, EventArgs e)
        {

            Phong phong = new Phong();
            SqlCommand command = new SqlCommand("Select * from TTKH ");

            dataGridViewKH.ReadOnly = true;

            dataGridViewKH.DataSource = phong.getshowkh(command);

            dataGridViewKH.AllowUserToAddRows = false;
            comboBox1.DataSource = phong.getAllTraPhong(); ;
            comboBox1.DisplayMember = "MaKH";
            comboBox1.ValueMember = "MaKH";
            comboBox1.SelectedItem = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string MAKH = Convert.ToString(comboBox1.SelectedValue);
                DataTable table = new DataTable();
                table = phong.getsKHbymaKH(MAKH);

            }
            catch
            {

            }
        }

        private void dataGridViewKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonRF_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM TTKH");
            dataGridViewKH.ReadOnly = true;
            DataGridViewImageColumn piccol = new DataGridViewImageColumn();
            dataGridViewKH.RowTemplate.Height = 20;
            dataGridViewKH.DataSource = nhanvien.getAllTTKH(command);
            piccol = (DataGridViewImageColumn)dataGridViewKH.Columns[7];
            piccol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewKH.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Coca = (int)numericUpDownCOCA.Value;
            int Tiger = (int)numericUpDownTiger.Value;
            int Ruou = (int)numericUpDownRuou.Value;
            int Mi = (int)numericUpDownMi.Value;
            int Snack = (int)numericUpDownSncack.Value;
            DateTime NgayKT = DateTime.Now;
            int day = NgayKT.Day;
            int month = NgayKT.Month;
            int year = NgayKT.Year;

            string MAKhach = comboBox1.SelectedValue.ToString();
            DateTime NgayBD;
            string MaPhong;
            int tonggio;
            int tongngay;
            int vp1;
            int vp2;
            int vp3;
            int vp4;
            int vp5;
            string tenPhong;
             
            SqlCommand command1 = new SqlCommand("Select NgayBatDau From TTKH where MaKH like '" + MAKhach + "%'");
            DataTable table1 = phong.getshowkh(command1);
            NgayBD = (DateTime)table1.Rows[0]["NgayBatDau"];
            SqlCommand command2 = new SqlCommand("Select ThuePhong From TTKH ");
            DataTable table2 = phong.getshowkh(command2);
            MaPhong = table2.Rows[0]["ThuePhong"].ToString();
            SqlCommand command4 = new SqlCommand("Select * From ChiTietPhong where MaPhong like '" + MaPhong + "%'");
            DataTable table4 = phong.getshowkh(command4);
            vp1 = (int)table4.Rows[0]["VatPham1"];
            vp2 = (int)table4.Rows[0]["VatPham2"];
            vp3 = (int)table4.Rows[0]["VatPham3"];
            vp4 = (int)table4.Rows[0]["VatPham4"];
            vp5 = (int)table4.Rows[0]["VatPham5"];
            tenPhong = table4.Rows[0]["TenPhong"].ToString();
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataTable table3 = new DataTable();
            SqlCommand command3 = new SqlCommand("Select * From TTKH WHERE @MA = MaKH", mydb.GetConnection);
            command3.Parameters.Add("@MA", SqlDbType.VarChar).Value = MAKhach;
            adapter1.SelectCommand = command3;
            adapter1.Fill(table3);
            TimeSpan tn = NgayKT - NgayBD;
            HoaDon hd = new HoaDon();
            if (Coca <= vp1 && Tiger <= vp2 && Snack <= vp3 && Ruou <= vp4 && Mi <= vp5)
            {

                labelgio.Text = Convert.ToString(tn.Hours) + "  Gio";
                labelNgay.Text = Convert.ToString(tn.Days) + "  Ngay";
                labelTien.Text = Convert.ToString((tn.Days * 1000000) + (tn.Hours * (1000000 / 24)) + (Coca * 15000 + Snack * 10000 + Ruou * 200000 + Tiger * 20000 + Mi * 10000)) + "  VNĐ";
                
                if (table3.Rows.Count <= 0)
                {
                    MessageBox.Show("MA KHACH HANG CHUA DUOC DAT PHONG", " nhap lai", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                              
            }
            else
            {
                MessageBox.Show("So Luonng Vat Pham Nhap Vao La Sai Lech So Voi Vat Pham Trong Phong", " Nhap Lai ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
