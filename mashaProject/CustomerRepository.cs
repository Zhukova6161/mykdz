using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;

namespace mashaProject
{
    class CustomerRepository
    {


        private Customer mapCustomer(NpgsqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.CustomerId = Int32.Parse(reader["id_customer"].ToString());
            customer.Fio = reader["fio"].ToString();
            customer.Balance = Decimal.Parse(reader["balance"].ToString());
            return customer;
        }

        public Customer searchCustomerByFio(String fio)
        {
            String sql = "select * from customer where fio like '%" + fio + "%';"; 
            NpgsqlConnection conn = PGDBConnector.getConnection();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader;
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.Read())
            {
                Customer customer = mapCustomer(reader);
                conn.Close();
                return customer;
            }
            else
            {
                conn.Close();
                throw new NullReferenceException("customer not found");
            }

        }

        public Boolean updateCustomer(Int32 id,String fio,Decimal balance)
        {
            String sql = "update customer set fio='" + fio + "', balance='" + balance.ToString().Replace(',','.') + "' where id_customer="+id+";";
            NpgsqlConnection conn = PGDBConnector.getConnection();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            conn.Open();
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;

        }


        public Boolean addCustomer(String fio, Decimal balance)
        {
            String sql = "INSERT INTO customer(id_customer, fio, balance) VALUES (default, '" + fio +"', "+balance.ToString().Replace(',', '.')+");";
            NpgsqlConnection conn = PGDBConnector.getConnection();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            conn.Open();
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;

        }
       
    }
    
}
