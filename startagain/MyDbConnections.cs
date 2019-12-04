using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace startagain
{
    public class MyDbConnections
    {

        public MySqlConnection MyConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["estateporrtalConnectionString"].ConnectionString;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            return myConnection;
        }


    }
}