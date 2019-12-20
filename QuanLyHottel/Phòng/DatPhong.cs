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
    public partial class DatPhong : Form
    {
        Phong phong = new Phong();
        public DatPhong()
        {
            InitializeComponent();
        }

        private void DatPhong_Load(object sender, EventArgs e)
        {
            ComboBoxPhong.DataSource = phong.getDatPhong();
            ComboBoxPhong.DisplayMember = "TenPhong";
            ComboBoxPhong.ValueMember = "MaPhong";
            ComboBoxPhong.SelectedItem = null;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ((TextBoxMaKH.Text.Trim() == ""))
            {
                MessageBox.Show("NhapID", " Add ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                
                string id = TextBoxMaKH.Text;
                string name = TextBoxNameKH.Text;
                DateTime datebd = DatetimeBD.Value;
                string phone = TextBoxPhone.Text;
                string adrs = TextBoxDC.Text;  
                string LBGT = "Male";
               int mk;
                string TPhong = ComboBoxPhong.SelectedValue.ToString();
                if (radioButtonFemale.Checked)
                {
                    LBGT = "Female";

                }
                MemoryStream pic = new MemoryStream();
                SqlCommand command5 = new SqlCommand("Select MKPhong From TTPhong where MaPhong  like'" + TPhong + "%'");
                DataTable table5 = phong.getshowkh(command5);
                mk = (int)table5.Rows[0]["MKPhong"];
                if (verif())
                {
                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if (phong.insertPhong(id,name,LBGT,adrs,phone,TPhong,datebd,pic))
                    {
                        phong.updateTPhong(TPhong);
                        phong.insertKHForQL(id, name, LBGT, adrs, phone, TPhong, datebd, pic);
                        MessageBox.Show("Thành Công", "Thêm Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Mật Khẩu Phòng là: "+mk, "Thêm Khách Hàng", MessageBoxButtons.OK);
                        
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Thất Bại", "Thêm Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thiếu gì đó", "Thêm Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        bool verif()
        {
            if ((TextBoxMaKH.Text.Trim() == "")
                || (TextBoxNameKH.Text.Trim() == "")
                || (TextBoxDC.Text.Trim() == "")
                || (TextBoxPhone.Text.Trim() == "")
                || (ComboBoxPhong.Text == null)
                || (pictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ButtonUpLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
