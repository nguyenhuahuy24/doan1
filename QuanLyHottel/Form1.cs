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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            Nhanvien nv = new Nhanvien();
            My_DB db = new My_DB();
            db.openConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE UserName = @User AND PassWord = @Pass ", db.GetConnection);
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUser.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            SqlCommand command2 = new SqlCommand("Select ChucVu From Login where UserName like '" + TextBoxUser.Text + "%'");
            DataTable table2 = nv.getLaoCong(command2);
             string ChucVu = (string)table2.Rows[0]["ChucVu"];
            SqlCommand command3 = new SqlCommand("Select Id From Login where UserName like '" + TextBoxUser.Text + "%'");
            DataTable table3 = nv.getLaoCong(command3);
            int Id = (int)table3.Rows[0]["Id"];
            if(ChucVu == "LaoCong   ")          
            {
                if (table.Rows.Count > 0)
                {
                    Global.SetGlobalUserId(Id);
                    LaoCong str = new LaoCong();
                    this.Hide();
                    str.ShowDialog();
                    this.Show();
                }
                else MessageBox.Show("Invalid Username or Password");
            }
            else if (ChucVu =="LeTan     ")
            {
                if (table.Rows.Count > 0)
                {
                    Global.SetGlobalUserId(Id);
                    LeTan str = new LeTan();
                    this.Hide();
                    str.ShowDialog();
                    this.Show();
                }
                else MessageBox.Show("Invalid Username or Password");
            }
            else if (ChucVu == "QuanLy    ")
            {               
                if (table.Rows.Count > 0)
                {
                    Global.SetGlobalUserId(Id);
                    Quan_ly str = new Quan_ly();
                    this.Hide();
                    str.ShowDialog();
                    this.Show();
                }
                else MessageBox.Show("Invalid Username or Password");
            }
            else MessageBox.Show("Invalid Username or Password");
           
        }

        private void RadiouttonLC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
