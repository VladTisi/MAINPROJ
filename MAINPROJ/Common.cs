using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreakProj
{
    public static class Common
    {
        public static OleDbConnection Connection;
        public static OleDbConnection GetConnection()
        {
            if(Connection == null)
                Connection = new OleDbConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022");
            
            return Connection;
        }
    }
}
