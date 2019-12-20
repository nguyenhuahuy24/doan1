using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHottel
{
    public partial class Quan_ly : Form
    {
        public Quan_ly()
        {
            InitializeComponent();
        }

        private void thêmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ĐặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatPhong datphong = new DatPhong();
            datphong.Show();
        }

        private void TrảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrPhong traphong = new TrPhong();
            traphong.Show();

        }

        private void TìnhTrạngPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyPhong ql = new QuanLyPhong();
            ql.Show();

        }

        private void NhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LễTânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVienLeTan sp = new NhanVienLeTan();
                sp.Show();
        }

        private void InBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCao pr = new BaoCao();
            pr.Show();
        }

        private void DanhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TTKhachHang pr = new TTKhachHang();
            pr.Show();
        }

        private void LaoCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVienLaoCong nv = new NhanVienLaoCong();
            nv.Show();
        }

        private void ThuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThuNhap tn = new ThuNhap();
            tn.Show();
        }

        private void tìnhTrạngPhòngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            ThongTinPhong tt = new ThongTinPhong();
            tt.Show();
        }

        private void báoCáoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoThang nv = new BaoCaoThang();
            nv.Show();
        }

        private void thêmQuảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterQL rql = new RegisterQL();
            rql.Show();
        }

        private void tổngLươngChoNVToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLogin nv = new QuanLyLogin();
            nv.Show();
        }
    }
}
