using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreakProj
{
    public static class Common
    {
        public static SqlConnection Connection;
        public static SqlConnection GetConnection()
        {
            if(Connection == null)
                Connection = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022");

            return Connection;
        }
    }
}
