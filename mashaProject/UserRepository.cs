using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;

namespace mashaProject
{
    class UserRepository
    {

        private User mapUser(NpgsqlDataReader reader)
        {
            User result = new User();
            result.UserId = Int32.Parse(reader["id_user"].ToString());
            result.Username = reader["login"].ToString();
            result.Password = reader["password"].ToString();
            return result;
        }

        public User getUserByUsername(String username)
        {
            String sql = "select * from users where login like '" + username + "';";
            NpgsqlConnection conn = PGDBConnector.getConnection();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader;
            conn.Open(); 
            reader = comm.ExecuteReader();
            if (reader.Read())
            {
                User user= mapUser(reader);
                conn.Close();
                return user;
            }
            else
            {
                conn.Close();
                throw new NullReferenceException("user not found");
            }

            
        }
        
    }
}
