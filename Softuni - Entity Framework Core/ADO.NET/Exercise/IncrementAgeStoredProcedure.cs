using Microsoft.Data.SqlClient;

namespace IncrementAgeStoredProcedure
{
    internal class IncrementAgeStoredProcedure
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            string connectionString =
                "";

            using SqlConnection connection =
                new SqlConnection(connectionString);
            
            connection.Open();

            SqlCommand createProcedureCommand =
                new SqlCommand("CREATE OR ALTER PROC usp_GetOlder @id INT\r\nAS\r\nUPDATE Minions\r\n   SET Age += 1\r\n WHERE Id = @id", connection);

            createProcedureCommand.ExecuteNonQuery();

            SqlCommand procedureCommand =
                new SqlCommand("EXEC usp_GetOlder @Id", connection);

            procedureCommand.Parameters.AddWithValue("@Id", id);
            procedureCommand.ExecuteNonQuery();

            SqlCommand outputCommand =
                new SqlCommand("SELECT Name, Age " +
                "FROM Minions WHERE Id = @Id", connection);

            outputCommand.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader =
                outputCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = (string)reader["Name"];
                int age = (int)reader["Age"];
                Console.WriteLine($"{name} - {age} years old");
            }
        }
    }
}