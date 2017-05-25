using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace mashaProject
{
    class PGDBConnector
    {
        private static NpgsqlConnection connection;
        public static NpgsqlConnection getConnection()
        {
            if (connection == null)
            {
                string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=772519a;Database=masha_db;";
                connection=new NpgsqlConnection(conn_param);
            }
            return connection;

        }


    }
}
