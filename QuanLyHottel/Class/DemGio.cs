using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHottel
{
    class DemGio
    {
        My_DB mydb = new My_DB();
        public bool deleteBaoCao(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM BaoCaoNgay WHERE Id = @Id", mydb.GetConnection);
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
        public bool updateBaoCaoNgay(int id, string fname, DateTime giokt, int tonggiolam, int tongphutlam, double luong)
        {
            SqlCommand command = new SqlCommand("UPDATE BaoCaoNgay SET HoTen = @fn, GioKT = @gioKT, TongGioLam = @tong,TongPhutLam =@Tongp, Luong = @luong WHERE id = @ID", mydb.GetConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@gioKT", SqlDbType.DateTime).Value = giokt;
            command.Parameters.Add("@tong", SqlDbType.Int).Value = tonggiolam;
            command.Parameters.Add("@Tongp", SqlDbType.Int).Value = tongphutlam;
            command.Parameters.Add("luong", SqlDbType.Float).Value = luong;

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
        public bool updateBaoCaoThang(int id, string fname, DateTime giokt, int tonggiolam, int tongphutlam, double luong)
        {
            SqlCommand command = new SqlCommand("UPDATE BaoCaoLuong SET HoTen = @fn, GioKT = @gioKT, TongGioLam = @tong,TongPhutLam =@Tongp, Luong = @luong WHERE id = @ID", mydb.GetConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@gioKT", SqlDbType.DateTime).Value = giokt;
            command.Parameters.Add("@tong", SqlDbType.Int).Value = tonggiolam;
            command.Parameters.Add("@Tongp", SqlDbType.Int).Value = tongphutlam;
            command.Parameters.Add("luong", SqlDbType.Float).Value = luong;

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
        public bool inserBaoCaoNgay(int id,string hoten, DateTime gioBD, string chucvu, int calamviec)
        {
            SqlCommand command = new SqlCommand("insert into BaoCaoNgay(Id ,HoTen, GioBD, ChucVu,CaLamViec)"
                + " Values(@id,@HT,@GioBD,@CV,@ca)", mydb.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@HT", SqlDbType.VarChar).Value = hoten;
            command.Parameters.Add("@GioBD", SqlDbType.DateTime).Value = gioBD;
            command.Parameters.Add("@CV", SqlDbType.VarChar).Value = chucvu;
            command.Parameters.Add("@ca", SqlDbType.Int).Value = calamviec;
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
        public bool inserBaoCaoThang(int id, DateTime gioBD, string chucvu, int calamviec)
        {
            SqlCommand command = new SqlCommand("insert into BaoCaoLuong(Id , GioBD, ChucVu,CaLamViec)"
                + " Values(@id,@GioBD,@CV,@ca)", mydb.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@GioBD", SqlDbType.DateTime).Value = gioBD;
            command.Parameters.Add("@CV", SqlDbType.VarChar).Value = chucvu;
            command.Parameters.Add("@ca", SqlDbType.Int).Value = calamviec;
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
