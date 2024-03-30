using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Server.DAL
{
     public class DbFactory
    {
        public static IDbConnection GetDbConnection(string conn)
        {
            var dbConnection = new SqlConnection(conn);
            dbConnection.Open();
            return dbConnection;
        }
    }
}