using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;

namespace mashaProject
{
    class AbonementRepository
    {

        private Abonement mapAbonement(NpgsqlDataReader reader)
        {
            Abonement result = new Abonement();
            result.Id = Int32.Parse(reader["id_aboniment"].ToString());
            result.Desc = reader["description"].ToString();
            result.Cost = Decimal.Parse(reader["cost"].ToString());
            result.VisitsCount = Int32.Parse(reader["visits_count"].ToString());
            result.VisitsCountRem = Int32.Parse(reader["visits_count_remaining"].ToString());
            result.IdCust = Int32.Parse(reader["id_customer"].ToString());
            return result;
        }

        public Abonement getAbonementByCustomer(Int32 idCust)
        {
            String sql = "select * from abonement where id_customer ='" + idCust + "';";
            NpgsqlConnection conn = PGDBConnector.getConnection();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader;
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.Read())
            {
                Abonement abonement = mapAbonement(reader);
                conn.Close();
                return abonement;
            }
            else
            {
                conn.Close();
                throw new NullReferenceException("abonement not found");
            }
        }

        public Boolean addAbonement(String desc, Decimal cost, Int32 visitsCount, Int32 visitsCountRem, Int32 idCustomer)
        {
            String sql = "INSERT INTO abonement(id_aboniment, description, cost, visits_count, visits_count_remaining,id_customer) "
            + " VALUES (default, '" + desc + "','" + cost.ToString().Replace(',', '.') + "','" + visitsCount +
            "','" + visitsCountRem + "','" + idCustomer + "')";
            NpgsqlConnection conn = PGDBConnector.getConnection();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            conn.Open();
            try
            {
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        public Boolean decreaseAbomenetVisits(Int32 idCustomer)
        {
            Abonement abonement = getAbonementByCustomer(idCustomer);

            String sql = "update abonement set visits_count_remaining=visits_count_remaining-1 where id_customer=" + idCustomer + ";";
            NpgsqlConnection conn = PGDBConnector.getConnection();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            conn.Open();
            try
            {
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        public Boolean deleteCustAbomenet(Int32 idCustomer)
        {
            Abonement abonement = getAbonementByCustomer(idCustomer);

            String sql = "delete from abonement where id_customer=" + idCustomer + ";";
            NpgsqlConnection conn = PGDBConnector.getConnection();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            conn.Open();
            try
            {
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }
    }
}
