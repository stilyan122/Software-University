using Microsoft.Data.SqlClient;

namespace IncreaseMinionAge
{
    internal class IncreaseMinionAge
    {
        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string connectionString =
                "";

            using SqlConnection connection =
                new SqlConnection(connectionString);

            connection.Open();

            foreach (int id in ids)
            {
                SqlCommand updateCommand =
                   new SqlCommand("UPDATE Minions\r\n   SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1\r\n WHERE Id = @Id",
                   connection);
                updateCommand.Parameters.AddWithValue("@Id", id);
                updateCommand.ExecuteNonQuery();
            }

            SqlCommand selectCommand =
                new SqlCommand("SELECT Name, Age FROM Minions", connection);
           
             using SqlDataReader reader =
                selectCommand.ExecuteReader();

            while (reader.Read())
            {;
                string name = (string)reader["Name"];
                int age = (int)reader["Age"];
                Console.WriteLine($"{name} {age}");
            }
        }
    }
}