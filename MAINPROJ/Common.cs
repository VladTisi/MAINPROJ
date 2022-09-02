using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAINPROJ
{
    public static class Common
        
    {
        public static OleDbConnection Connection;
        public static SqlConnection Connection2;
        public static OleDbConnection GetConnection()
        {
            if(Connection == null)
                Connection = new OleDbConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int;Provider=SQLOLEDB");

            return Connection;
        }
        public static SqlConnection GetSqlConnection()
        {
            if (Connection2 == null)
                Connection2 = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int;");



            return Connection2;
        }
    }
}
