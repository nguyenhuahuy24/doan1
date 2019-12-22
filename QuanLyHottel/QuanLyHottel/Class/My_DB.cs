using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHottel
{
    class My_DB
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=TTP;Integrated Security=True");
        public SqlConnection GetConnection
        {
            get
            {
                return con;
            }

        }
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }
        }
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }
        }
    }
}
