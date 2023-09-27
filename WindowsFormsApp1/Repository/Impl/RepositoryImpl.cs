using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repository.Impl
{
    public class RepositoryImpl
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Map;Trusted_Connection=True;";

        public List<US> GetAllCoordsAsync()
        {
            List<US> us = new List<US>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Coords", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        us.Add(new US()
                        {
                            Id = reader.GetValue(1).ToString(),
                            Coordinates = new Coordinates()
                            {
                                Latitude = (double)reader.GetValue(2),
                                Longitude = (double)reader.GetValue(3)
                            }
                        }) ;   
                    }   
                }
            }

            return us;
        }

        public void updateMarker(string id, double lat, double lon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sLan = lat.ToString().Replace(',', '.');
                string sLon = lon.ToString().Replace(',', '.');

                SqlCommand cmd = new SqlCommand("UPDATE Coords SET lat = " + sLan + ", lon = " + sLon + "WHERE cname = '" + id + "'", conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
