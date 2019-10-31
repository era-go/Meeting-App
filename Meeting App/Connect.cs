using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Meeting_App
{
    class Connect
    {
        string connetionString  = "Data Source = ERA; Initial Catalog = meeting; Integrated Security = True";//lokal database.
        public bool AddToServer(modelokaler modelokaler)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            try
            {
                string query = "INSERT INTO modelokale (id, navn, lokation, pladsantal) values(" + modelokaler.Id + ", " + "'" + modelokaler.Navn + "'" + ", " + "'" + modelokaler.Lokation + "'" + ", " + modelokaler.Pladsantal + ")";
                cnn.Open();
                using (cnn)
                {
                    SqlCommand command = new SqlCommand(query, cnn);
                    command.ExecuteNonQuery();
                }
                cnn.Close();
                Console.WriteLine("done");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! -add " + ex);
            }
            return true;
        }
        public bool UpdateServer(modelokaler modelokaler)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            try
            {
                string query = "update modelokale set navn = '" + modelokaler.Navn + "'" + ", lokation = " + "'" + modelokaler.Lokation + "'" + ", Pladsantal = " + modelokaler.Pladsantal + "where id = " + modelokaler.Id;
                cnn.Open();
                using (cnn)
                {
                    SqlCommand command = new SqlCommand(query, cnn);
                    command.ExecuteNonQuery();
                }
                cnn.Close();
                Console.WriteLine("done");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! -add " + ex);
            }
            return true;
        }

        public bool DeleteServer(int delete)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            try
            {
                string query = "delete from modelokale where id = " + delete;
                cnn.Open();
                using (cnn)
                {
                    SqlCommand command = new SqlCommand(query, cnn);
                    command.ExecuteNonQuery();
                }
                cnn.Close();
                Console.WriteLine("done");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! -add " + ex);
            }
            return true;
        }


        public List<modelokaler> GetList()
        {
            List<modelokaler> modelokalers = new List<modelokaler>();
            SqlConnection cnn;
            
            cnn = new SqlConnection(connetionString);
            try
            {
                string query = "select * from modelokale";
                using (cnn)
                {
                    SqlCommand command = new SqlCommand(query, cnn);
                    cnn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            modelokalers.Add(new modelokaler(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString(), reader.GetInt32(3)));
                        }
                    }
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
            return modelokalers;
        }
    }
}
