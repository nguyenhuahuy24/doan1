using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHottel
{
    class Phong
    {
        My_DB mydb = new My_DB();
        public DataTable getsKHbymaKH(string MaKH)
        {
            SqlCommand command = new SqlCommand("select * from  TTKH where MaKH =" + MaKH);
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getsPhongbymaphong(string MaPhong)
        {
            SqlCommand command = new SqlCommand("select * from  TTPhong where MaPhong=" + MaPhong);
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getDatPhong()
        {
            My_DB mydb = new My_DB();
            SqlCommand command = new SqlCommand(" select * FROM TTPhong where TrangThai ="+1);
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getTraPhong()
        {
            My_DB mydb = new My_DB();
            SqlCommand command = new SqlCommand(" select * FROM TTPhong where TrangThai =" + 0);
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getAllTraPhong()
        {
            My_DB mydb = new My_DB();
            SqlCommand command = new SqlCommand(" select * FROM TTKH");

            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertKHForQL(string maKH, string tenKH, string gender, string address, string phone, string TP, DateTime ngayBD, MemoryStream picture)
        {
            My_DB mydb = new My_DB();
            SqlCommand command = new SqlCommand("insert into QLKH(MaKh,TenKH ,GioiTinh,DiaChi,DienThoai,ThuePhong,NgayBatDau,CMND)"
                + " Values(@MKH, @tkh, @gt,@adr, @phone,@TP,@date,@pic)", mydb.GetConnection);
            command.Parameters.Add("@MKH", SqlDbType.VarChar).Value = maKH;
            command.Parameters.Add("@tkh", SqlDbType.NVarChar).Value = tenKH;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@adr", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@TP", SqlDbType.VarChar).Value = TP;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = ngayBD;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();


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
        public bool updateNGayKTForQL(string MAKH, DateTime NgayKT)
        {
            SqlCommand command = new SqlCommand("UPDATE QLKH SET NgayKetThuc = @NKT WHERE MaKH = @Ma", mydb.GetConnection);
            command.Parameters.Add("@Ma", SqlDbType.VarChar).Value = MAKH;
            command.Parameters.Add("@NKT", SqlDbType.DateTime).Value = NgayKT;

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
        public bool insertPhong(string maKH,string tenKH,string gender,string address,string phone,string TP,DateTime ngayBD,MemoryStream picture)
        {
            My_DB mydb = new My_DB();
            SqlCommand command = new SqlCommand("insert into TTKH(MaKh,TenKH ,GioiTinh,DiaChi,DienThoai,ThuePhong,NgayBatDau,CMND)"
                + " Values(@MKH, @tkh, @gt,@adr, @phone,@TP,@date,@pic)", mydb.GetConnection);
            command.Parameters.Add("@MKH", SqlDbType.VarChar).Value = maKH;
            command.Parameters.Add("@tkh", SqlDbType.NVarChar).Value = tenKH;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@adr", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@TP", SqlDbType.VarChar).Value = TP;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = ngayBD;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();


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
        public bool updateNGayKT(string MAKH, DateTime NgayKT)
        {
            SqlCommand command = new SqlCommand("UPDATE TTKH SET NgayKetThuc = @NKT WHERE MaKH = @Ma", mydb.GetConnection);
            command.Parameters.Add("@Ma", SqlDbType.VarChar).Value = MAKH;
            command.Parameters.Add("@NKT", SqlDbType.DateTime).Value = NgayKT;

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
        
        public bool updateTPhong(string maP)
        { 
            My_DB mydb = new My_DB();
            SqlCommand command = new SqlCommand("UPDATE TTPhong SET TrangThai = @TP where MaPhong = @mp", mydb.GetConnection);
            command.Parameters.Add("@TP", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@mp", SqlDbType.VarChar).Value = maP;
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
        public bool updateTraPhong(string maP,int mkphong)
        {
            My_DB mydb = new My_DB();
            SqlCommand command = new SqlCommand("UPDATE TTPhong SET TrangThai = @TP, MKPhong = @MK where MaPhong = @mp", mydb.GetConnection);
            command.Parameters.Add("@TP", SqlDbType.Int).Value = 1;
            command.Parameters.Add("@mp", SqlDbType.VarChar).Value = maP;
            command.Parameters.Add("@MK", SqlDbType.Int).Value = mkphong;

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
        public DataTable getsPhong()
        {
            SqlCommand command = new SqlCommand("select * from TTPhong where TrangThai = @TT", mydb.GetConnection);
            command.Parameters.Add("@TT", SqlDbType.Int).Value = 0;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getshowkh(SqlCommand command)
        {
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertThuNhap(DateTime ngay, int thunhap)
        {
            SqlCommand command = new SqlCommand("insert into ThuNhap1(Ngay,ThuNhap) Values(@Ngay,@TN)", mydb.GetConnection);
            command.Parameters.Add("@Ngay", SqlDbType.Date).Value = ngay;
            command.Parameters.Add("@TN", SqlDbType.BigInt).Value = thunhap;
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
        public DataTable getItembyNameITem(string NameItem)
        {
            SqlCommand command = new SqlCommand("select * from  Item where NameItem=" + NameItem);
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getsItem()
        {
            SqlCommand command = new SqlCommand("select * from Item ", mydb.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool insertChitietPhong(string MaPhong, string TenPhong, int VP1, int VP2, int VP3, int VP4, int VP5)
        {
            SqlCommand command = new SqlCommand("insert into ChiTietPhong(MaPhong,TenPhong,VatPham1,VatPham2,VatPham3,VatPham4,VatPham5) Values(@MaKH, @TenKH,@GioiTinh,@DT,@TP,@NBD,@CMND)", mydb.GetConnection);
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = MaPhong;
            command.Parameters.Add("@TenKH", SqlDbType.VarChar).Value = TenPhong;
            command.Parameters.Add("@GioiTinh", SqlDbType.Int).Value = VP1;
            command.Parameters.Add("@DT", SqlDbType.Int).Value = VP2;
            command.Parameters.Add("@TP", SqlDbType.Int).Value = VP3;
            command.Parameters.Add("@NBD", SqlDbType.Int).Value = VP4;
            command.Parameters.Add("@CMND", SqlDbType.Int).Value = VP5;
         

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
        public bool updateChitietPhong(string MaPhong, string tenphong, int vp1, int vp2, int vp3, int vp4, int vp5)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiTietPhong SET TenPhong = @TP, VatPham1 = @VP1, VatPham2 = @VP2, VatPham3 = @VP3, VatPham4 = @VP4, VatPham5 = @VP5  " +
               " WHERE MaPhong = @MP", mydb.GetConnection);
            command.Parameters.Add("@MP", SqlDbType.VarChar).Value = MaPhong;
            command.Parameters.Add("@TP", SqlDbType.VarChar).Value = tenphong;
            command.Parameters.Add("@VP1", SqlDbType.Int).Value = vp1;
            command.Parameters.Add("@VP2", SqlDbType.Int).Value = vp2;
            command.Parameters.Add("@VP3", SqlDbType.Int).Value = vp3;
            command.Parameters.Add("@VP4", SqlDbType.Int).Value = vp4;
            command.Parameters.Add("@VP5", SqlDbType.Int).Value = vp5;
            

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
        public bool deleteKH(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM TTKH WHERE MaKH = @Id", mydb.GetConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
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
    }
}
