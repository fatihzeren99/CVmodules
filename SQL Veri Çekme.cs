using System;
using System.Data.SqlClient;

namespace VeriCekme
{
    class Program
    {
        static void Main(string[] args)
        {
            // SQL bağlantı dizesi
            string connectionString = "Data Source=localhost;Initial Catalog=myDatabase;Integrated Security=True";

            // SQL sorgusu
            string query = "SELECT * FROM myTable";

            // SQL bağlantısı açma
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL sorgusunu yürütme
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Bağlantıyı açma
                    connection.Open();

                    // Sorgudan dönen verileri al
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verileri oku
                        while (reader.Read())
                        {
                            // Verileri işle
                            int id = (int)reader["Id"];
                            string name = (string)reader["Name"];
                            int age = (int)reader["Age"];

                            // Verileri yazdır
                            Console.WriteLine("Id: {0}, Name: {1}, Age: {2}", id, name, age);
                        }
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
