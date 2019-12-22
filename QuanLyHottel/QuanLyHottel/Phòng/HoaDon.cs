using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHottel
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonHD_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            string MAKhach = Global.GlobalUserId2;
            phong.deleteKH(MAKhach);
            string Path = "C:\\Users\\DELL\\Downloads\\ToPrinter "+MAKhach+".txt";
            TextWriter w = new StreamWriter(Path);
            w.WriteLine("\t\t\t\t Hóa Đơn Khách Hàng");
            w.WriteLine("");            
            w.WriteLine("\t\t\t Tên Khách Hàng " + TextBoxNameKHHD.Text);
            w.WriteLine("\t\t\t Phòng Đã Thuê: " + TextBoxTPHD.Text);
            if (radioButtonFemaleHD.Checked == true)
            {
                w.WriteLine("\t\t\t Giới Tính: Nữ ");
            }
            else w.WriteLine("\t\t\t Giới Tính: Nam ");
            w.WriteLine("\t\t\t Địa Chỉ Đã Đăng Kí: " + TextBoxDCHD.Text);
            w.WriteLine("\t\t\t Ngày Nhận Phòng: " + DatetimeNPHD.Value);
            w.WriteLine("\t\t\t Ngày Kết Thúc  : " + DatetimeTPHD.Value);
            w.WriteLine("\t\t\t Số Điện Thoại Khách Hàng:" + TextBoxPhoneHD.Text);
            w.WriteLine("");
            w.WriteLine("=====================================================================================");
            w.WriteLine("");
            w.WriteLine("\t\t\t\t Dịch Vụ Đã Sử Dụng");
            w.WriteLine("\t\t\t " + labelcoca.Text);
            w.WriteLine("\t\t\t " + labelTB.Text);
            w.WriteLine("\t\t\t " + labels.Text);
            w.WriteLine("\t\t\t " + labelVK.Text);
            w.WriteLine("\t\t\t " + labelN.Text);
            w.WriteLine("\t\t\t " + labelngay.Text);
            w.WriteLine("\t\t\t " + labelgio.Text);
            w.WriteLine("\t\t\t " + labeltien.Text);
            w.WriteLine("");
            w.WriteLine("\t\t Cảm Ơn Quí Khách Đã Sử Dụng Khách Sạn Chúng Tôi.");
            w.WriteLine("\t\t Hẹn Gặp Lại Quý Khách Trong Thời Gian Sớm Nhất");


            w.Flush();
            MessageBox.Show("In Thành Công", "Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            TrPhong st = new TrPhong();
            st.Show();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
