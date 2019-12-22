using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHottel
{
    public static class Global
    {
        public static int GlobalUserId { get; private set; }
        public static void SetGlobalUserId(int userID)
        {
            GlobalUserId = userID;
        }
        public static string GlobalUserId2 { get; private set; }
        public static void SetGlobalUserId2(string userID)
        {
            GlobalUserId2 = userID;
        }
    }
}
