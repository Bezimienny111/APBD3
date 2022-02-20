using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public interface IDatabaseService
    {
     //   IEnumerable<Animal> GetAnimals();
    //    IEnumerable<Animal> GetAnimals(int integ);
        IEnumerable<Animal> AddAnimal(Animal newAnimal);
        IEnumerable<Animal> GetAnimals(String category);

        IEnumerable<Animal> UpdateAnimal(int index,Animal newAnimal);
        IEnumerable<Animal> DeleteAnimal(int idAnimal);
    }

    public class SqlServerDatabaseService : IDatabaseService {
        string conString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18290;Integrated Security=True";

        //Dodawanie
        public IEnumerable<Animal> AddAnimal(Animal newAnimal)
        {
            List<Animal> list = new List<Animal>();
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Animal ORDER BY IdAnimal";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Animal
                    {
                        IdAnimal = Int32.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Desctiption = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    });
                }
                dr.Close();

            
         //   int nextId = (list.Count() + 1);
       //     newAnimal.IdAnimal = nextId;

                String query = "INSERT INTO Animal (Name,Description,Category,Area) VALUES (@b,@c,@d,@e)";

                SqlCommand comTwo = new SqlCommand();

                comTwo.Connection = con;
                comTwo.CommandText = query;
             //   comTwo.Parameters.AddWithValue("@a", newAnimal.IdAnimal);
                comTwo.Parameters.AddWithValue("@b", newAnimal.Name);
                comTwo.Parameters.AddWithValue("@c", newAnimal.Desctiption);
                comTwo.Parameters.AddWithValue("@d", newAnimal.Category);
                comTwo.Parameters.AddWithValue("@e", newAnimal.Area);
                //    + newAnimal.IdAnimal + ", "
                //     + newAnimal.Name + ", "
                ////     + newAnimal.Desctiption + ", "
                //     + newAnimal.Category + ", "
                //     + newAnimal.Area + ");"

                //     ;

                //   com.CommandText 
                int result = comTwo.ExecuteNonQuery();
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");

                dr = com.ExecuteReader();
                list = new List<Animal>();
                while (dr.Read())
                {
                    
                    list.Add(new Animal
                    {
                        IdAnimal = Int32.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Desctiption = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    });
                }

                con.Close();
            }


            return GetAnimals("name");
        }

        public IEnumerable<Animal> DeleteAnimal(int idAnimal)
        {

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand();


                String query = "DELETE FROM Animal WHERE IdAnimal = @a";

                con.Open();

                com.Connection = con;
                com.CommandText = query;
                com.Parameters.AddWithValue("@a", idAnimal);

                int result = com.ExecuteNonQuery();
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");

                SqlDataReader dr = com.ExecuteReader();

                List<Animal> list = new List<Animal>();
                while (dr.Read())
                {

                    list.Add(new Animal
                    {
                        IdAnimal = Int32.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Desctiption = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    });
                }

                con.Close();



                return GetAnimals("name");

            }
        }


        // Zwracanie listy
        public IEnumerable<Animal> GetAnimals(string orderIn)
        {
            try
            {
                string order = "name";
                if (testerOrder(orderIn) == 1)
                    order = orderIn;
                if (testerOrder(orderIn) == 3)
                    throw new ArgumentException("Błędny OrderBY");
                if (testerOrder(orderIn) == 2)
                    order = "name";

                List<Animal> list = new List<Animal>();
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = "SELECT * FROM Animal ORDER BY " + order;

                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new Animal
                        {
                            IdAnimal = Int32.Parse(dr["IdAnimal"].ToString()),
                            Name = dr["Name"].ToString(),
                            Desctiption = dr["Description"].ToString(),
                            Category = dr["Category"].ToString(),
                            Area = dr["Area"].ToString()
                        });
                    }

                }

                return list;
            } catch(Exception e)
            {
                Console.WriteLine(String.Format("Błędny OrderBY"));
            }
            return null;
        }





        public int testerOrder(string order)
        {
            string empty = string.Empty;
            if (order == null)
                return 2;
            if (order.Equals("name"))
                return 1;
            if (order.Equals("description"))
                return 1;
            if (order.Equals("category"))
                return 1;
            if (order.Equals("area"))
                return 1;
            if (order.Equals(string.Empty))
                return 2;


            return 3;   

              

            }

        //Aktualizacja 
        public IEnumerable<Animal> UpdateAnimal(int index, Animal newAnimal)
        {

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand();


                String query = "UPDATE Animal SET Name = @b, Description = @c, Category = @d, Area = @e WHERE IdAnimal = @a";

                con.Open();

                com.Connection = con;
                com.CommandText = query;
                com.Parameters.AddWithValue("@a", index);
                com.Parameters.AddWithValue("@b", newAnimal.Name);
                com.Parameters.AddWithValue("@c", newAnimal.Desctiption);
                com.Parameters.AddWithValue("@d", newAnimal.Category);
                com.Parameters.AddWithValue("@e", newAnimal.Area);

                int result = com.ExecuteNonQuery();
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                
                SqlDataReader dr = com.ExecuteReader();
             
                List<Animal> list = new List<Animal>();
                while (dr.Read())
                {

                    list.Add(new Animal
                    {
                        IdAnimal = Int32.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Desctiption = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    });
                }

                con.Close();


                return GetAnimals("name");

            }
        }
        }
    }

   

