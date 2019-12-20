using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHottel
{
    public partial class NhanVienLeTan : Form
    {
        Nhanvien NhanVien = new Nhanvien();
        public NhanVienLeTan()
        {
            InitializeComponent();
        }

        private void TextboxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridViewManagerStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            NhanVienLeTan nhanVienLeTan = new NhanVienLeTan();
            TextboxID.Clear();
            TextboxFirstName.Clear();
            TextboxLastName.Clear();
            TextboxPhone.Clear();
            textBoxSearch.Clear();
            TextboxAddress.Clear();
            dateTimePickerLetan.Value = DateTime.Now;
            pictureBox1.Image = null;
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {

            try
            {
                string UserName = TextBoxUSERNAME.Text;
                int studentID = Convert.ToInt32(TextboxID.Text);
                if (MessageBox.Show("Ban muốn xóa nhân viên Lễ tân", "Xóa Lễ Tân",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    if (NhanVien.deleteNV(studentID))
                    {
                        if (NhanVien.deleteLogin(UserName))
                        {
                            MessageBox.Show("Thành công", "Xóa Lễ Tân", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //clear filed after delete
                            TextboxID.Text = "";
                            TextboxFirstName.Text = "";
                            TextboxLastName.Text = "";
                            TextboxAddress.Text = "";
                            TextboxPhone.Text = "";
                            dateTimePickerLetan.Value = DateTime.Now;
                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thất bại", "Xóa Lễ Tân", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Chưa nhập Id để xóa", " Xóa Lễ Tân", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            string cv = "LeTan     ";
            SqlCommand command = new SqlCommand("SELECT * FROM TTNV as a,Login as b where b.ChucVu like '" + cv + "%' and a.IdNhanVien = b.Id ");
            dataGridViewManagerStudent.ReadOnly = true;
            DataGridViewImageColumn piccol = new DataGridViewImageColumn();
            dataGridViewManagerStudent.RowTemplate.Height = 40;
            dataGridViewManagerStudent.DataSource = NhanVien.getLaoCong(command);
            piccol = (DataGridViewImageColumn)dataGridViewManagerStudent.Columns[7];
            piccol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewManagerStudent.AllowUserToAddRows = false;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if ((TextboxID.Text.Trim() == ""))
            {
                MessageBox.Show("Hãy nhập Id", " Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                My_DB db = new My_DB();
                Nhanvien nhanvien = new Nhanvien();
                int ca = (int)ComboBoxCaDK.SelectedValue;
                int id = Convert.ToInt32(TextboxID.Text);
                string cv = "LeTan";
                string fname = TextboxFirstName.Text;
                string lname = TextboxLastName.Text;
                DateTime bdate = dateTimePickerLetan.Value;
                string phone = TextboxPhone.Text;
                string adrs = TextboxAddress.Text;
                string UserName = TextBoxUSERNAME.Text;
                string Password = TextBoxPASSWORD.Text;
                string LBGT = "Male";
                if (RadioButtonFemale.Checked)
                {
                    LBGT = "Female";

                }
                MemoryStream pic = new MemoryStream();
                int born_year = dateTimePickerLetan.Value.Year;
                int this_year = DateTime.Now.Year;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("Select * From TTNV WHERE @ID= IdNhanVien", db.GetConnection);
                command.Parameters.Add("@ID", SqlDbType.VarChar).Value = TextboxID.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if ((table.Rows.Count) > 0)
                {
                    MessageBox.Show("Trùng Id", "Nhập Lại", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else if (((this_year - born_year) < 17) || ((this_year - born_year) > 50))
                {
                    MessageBox.Show("Tuổi nhân viên phải lớn hơn 17 và nhỏ hơn 50", " Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

                }
                else if (verif1())
                {
                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if (nhanvien.insertNhanVien(id, fname, lname, bdate, LBGT, phone, adrs, pic, ca))
                    {                                             
                        nhanvien.insertLogin(UserName, Password, cv, id);
                        MessageBox.Show("Thành Công", " Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thiếu thông tin", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
        bool verif1()
        {
            if ((TextboxFirstName.Text.Trim() == "")
                || (TextboxLastName.Text.Trim() == "")
                || (TextboxAddress.Text.Trim() == "")
                || (TextboxPhone.Text.Trim() == "")
                || (TextBoxPASSWORD.Text.Trim() == "")
                || (TextBoxUSERNAME.Text.Trim() == "")
                || (ComboBoxCaDK.SelectedValue == null)
                || (pictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            int id;
            int ca = (int)ComboBoxCaDK.SelectedValue;
            string fname = TextboxFirstName.Text;
            string lname = TextboxLastName.Text;
            DateTime bdate = dateTimePickerLetan.Value;
            string phone = TextboxPhone.Text;
            
            string adrs = TextboxAddress.Text;
            string UserName = TextBoxUSERNAME.Text;
            string PassWord = TextBoxPASSWORD.Text;
            string LBGT = "Male";
            if (RadioButtonFemale.Checked)
            {
                LBGT = "Female";
            }
            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePickerLetan.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 18) || (this_year - born_year) > 50)
            {
                MessageBox.Show("Tuổi lễ tân phải từ 18 -> 50", " Birth Date Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(TextboxID.Text);

                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if (NhanVien.updateNhanVien(id, fname, lname, bdate, LBGT, phone, adrs, pic, ca))
                    {                       
                            MessageBox.Show("Cập nhập thông tin thành công", " Cập nhập lễ tân", MessageBoxButtons.OK, MessageBoxIcon.Information);                      
                    }
                    else
                    {
                        MessageBox.Show("Error", "Cập nhập lễ tân", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            bool verif()
            {
                if ((TextboxFirstName.Text.Trim() == "")
                    || (TextboxID.Text.Trim() == "")
                    || (TextboxLastName.Text.Trim() == "")
                    || (TextboxAddress.Text.Trim() == "")
                    || (TextboxPhone.Text.Trim() == "")
                     || (ComboBoxCaDK.SelectedValue == null)
                    || (pictureBox1.Image == null))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = " select Image(*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = (" lao cong" + TextboxID.Text);
            if ((pictureBox1.Image == null))
            {
                MessageBox.Show(" no image in the PICTUREBOx");

            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image.Save(svf.FileName + ("." + ImageFormat.Jpeg.ToString()));
            }
        }

        private void DateTimePickerLetan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void NhanVienLeTan_Load(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            string cv = "LeTan    ";
            SqlCommand command = new SqlCommand("SELECT * FROM TTNV as a,Login as b where b.ChucVu like '" + cv + "%' and a.IdNhanVien = b.Id ");
            dataGridViewManagerStudent.ReadOnly = true;

            dataGridViewManagerStudent.DataSource = phong.getshowkh(command);

            dataGridViewManagerStudent.AllowUserToAddRows = false;
            ComboBoxCaDK.DataSource = NhanVien.getAllCalam();
            ComboBoxCaDK.DisplayMember = "CaLamViec";
            ComboBoxCaDK.ValueMember = "CaLamViec";
            ComboBoxCaDK.SelectedItem = null;
        }

        private void DataGridViewManagerStudent_DoubleClick(object sender, EventArgs e)
        {
            TextboxID.Text = dataGridViewManagerStudent.CurrentRow.Cells[0].Value.ToString();
            TextboxFirstName.Text = dataGridViewManagerStudent.CurrentRow.Cells[1].Value.ToString();
            TextboxLastName.Text = dataGridViewManagerStudent.CurrentRow.Cells[2].Value.ToString();
            dateTimePickerLetan.Value = (DateTime)dataGridViewManagerStudent.CurrentRow.Cells[3].Value;

            if ((dataGridViewManagerStudent.CurrentRow.Cells[4].Value.ToString() == "Female    "))
            {
                RadioButtonFemale.Checked = true;
            }
            else
            {
                RadioButtonMale.Checked = true;
            }
            TextboxPhone.Text = dataGridViewManagerStudent.CurrentRow.Cells[5].Value.ToString();
            TextboxAddress.Text = dataGridViewManagerStudent.CurrentRow.Cells[6].Value.ToString();
            byte[] pic;
            pic = (byte[])dataGridViewManagerStudent.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            pictureBox1.Image = Image.FromStream(picture);
            ComboBoxCaDK.Text = dataGridViewManagerStudent.CurrentRow.Cells[8].Value.ToString();
            TextBoxUSERNAME.Text = dataGridViewManagerStudent.CurrentRow.Cells[9].Value.ToString();
            TextBoxPASSWORD.Text = dataGridViewManagerStudent.CurrentRow.Cells[10].Value.ToString();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string cv = "LeTan     ";

            SqlCommand command = new SqlCommand("SELECT * FROM TTNV as a,Login as b where b.ChucVu like '" + cv + "%' and a.IdNhanVien = b.Id and CONCAT(Fname,Phone,IdNhanVien) LIKE'%" + textBoxSearch.Text + "%'");
            fillGrid(command);

        }
        public void fillGrid(SqlCommand command)
        {
            Nhanvien nhanvien = new Nhanvien();
            dataGridViewManagerStudent.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewManagerStudent.RowTemplate.Height = 100;
            dataGridViewManagerStudent.DataSource = nhanvien.getAllTTKH(command);
            picCol = (DataGridViewImageColumn)dataGridViewManagerStudent.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewManagerStudent.AllowUserToAddRows = false;
        }
    }
}
