using Microsoft.Data.SqlClient;

namespace VillainNames
{
    internal class VillainNames
    {
        static void Main(string[] args)
        {
            string connectionString =
                "";
            SqlConnection connection
               = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                string commandString = "SELECT v.Name, " +
                    "COUNT(mv.VillainId) AS MinionsCount " +
                    " \r\n    FROM Villains AS v \r\n    " +
                    "JOIN MinionsVillains AS mv ON v.Id = " +
                    "mv.VillainId \r\nGROUP BY v.Id, " +
                    "v.Name \r\n  " +
                    "HAVING COUNT(mv.VillainId) > 3 " +
                    "\r\nORDER BY COUNT(mv.VillainId)";
                SqlCommand command
                    = new SqlCommand(commandString,connection);
                using (SqlDataReader reader
                    = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string villainName = (string)reader["Name"];
                        int minionsCount = (int)reader["MinionsCount"];
                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
            }
        }
    }
}