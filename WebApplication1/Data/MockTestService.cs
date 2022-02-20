using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class MockTestService
    {
        string conString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18290;Integrated Security=True";
        private static IEnumerable<Animal> _Animals;
        static MockTestService()
        {
            _Animals = new List<Animal>();


        }
        public IEnumerable<Animal> GetAnimals(string cat)
        {
            List<Animal> list = new List<Animal>();
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Animal";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Animal
                    {
                        IdAnimal = Int32.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Desctiption = dr["Desctiption"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    });
                }

            }

                return list;
        }

    }
}
