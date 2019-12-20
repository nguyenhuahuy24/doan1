using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;

namespace QuanLyHottel
{
    class Nhanvien
    {
        My_DB mydb = new My_DB();  
        public bool insertNhanVien(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture, int CaLamViec)
        {
            SqlCommand command = new SqlCommand("insert into TTNV(IdNhanVien , Fname, Lname, Bdate, Gender, Phone, Address, Picture,CaLamViec)"
                + " Values(@id, @fn, @ln,@bdt, @gdr, @phn, @adrs, @pic,@Ca)", mydb.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@Ca", SqlDbType.Int).Value = CaLamViec;
            
           
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;

            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }
        
        public bool insertLogin(string username,string password,string chucvu,int id)
        {
            SqlCommand command = new SqlCommand("insert into Login(UserName,PassWord,ChucVu,Id)"
                + " Values(@user,@pass,@CV,@ID)", mydb.GetConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@CV", SqlDbType.VarChar).Value = chucvu;           
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;

            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }
        public DataTable getLaoCong(SqlCommand command)
        {
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }       
        public bool updateLogin(string UserName, string PassWord)
        {
            SqlCommand command = new SqlCommand("UPDATE Login SET PassWord = @Pass WHERE UserName = @User", mydb.GetConnection);           
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = UserName;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = PassWord;
            
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool deleteLogin(string username)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Login WHERE UserName = @User", mydb.GetConnection);
            command.Parameters.Add("@User", SqlDbType.Int).Value = username;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;

            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateNhanVien(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture, int CaLamViec)
        {
            SqlCommand command = new SqlCommand("UPDATE TTNV SET Fname = @fn, Lname =@ln, Bdate = @bdt, Gender = @gdr, Phone = @phn,Address" +
                "= @adr, Picture =  @pic,CaLamViec = @ca WHERE IdNhanVien = @ID", mydb.GetConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("adr", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@ca", SqlDbType.Int).Value = CaLamViec;
            

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool deleteNV(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM TTNV WHERE IdNhanVien = @Id", mydb.GetConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;

            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public DataTable showCaLamViecItMeLeTan(int ca)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.GetConnection;
            command.CommandText = "Select TTNV.IdNhanVien as Ma_Nhan_Vien , TTNV.Fname as First_Name,TTNV.Lname as Last_Name, TTNV.Phone,TTNV.CaLamViec from TTNV,Login as a Where a.Id = TTNV.IdNhanVien and a.ChucVu like '" + "LeTan     " + "%'and TTNV.CaLamViec =" + ca;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        public DataTable showCaLamViecItMeLaoCong(int ca)
        {
           
            SqlCommand command = new SqlCommand("Select TTNV.IdNhanVien as Ma_Nhan_Vien , TTNV.Fname as First_Name,TTNV.Lname as Last_Name, TTNV.Phone,TTNV.CaLamViec from TTNV,Login as a Where a.Id = TTNV.IdNhanVien and a.ChucVu like '"+"LaoCong   "+"%'and TTNV.CaLamViec =" + ca); 
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        public DataTable getAllCalam()
        {
            SqlCommand command = new SqlCommand(" select * FROM CaLamViec");
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getAllTTKH(SqlCommand command)
        {
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}

