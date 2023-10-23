using Microsoft.Data.SqlClient;

namespace ChangeTownNamesCasing
{
    internal class ChangeTownNamesCasing
    {
        static void Main()
        {
            string country = Console.ReadLine();

            string connectionString =
                "";

            using SqlConnection connection =
                new SqlConnection(connectionString);

            connection.Open();

            SqlCommand changeTownsCommand =
                new SqlCommand("UPDATE Towns\r\n   " +
                "SET Name = UPPER(Name)\r\n WHERE CountryCode = " +
                "(SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)"
                , connection);

            changeTownsCommand.Parameters.AddWithValue
                ("@countryName", country);
            int changedTowns = changeTownsCommand.ExecuteNonQuery();
            
            void PrintNoTowns()
            {
                Console.WriteLine("No town names were affected.");
            }
            if (changedTowns == 0)
            {
                PrintNoTowns();
            }
            else
            {
                SqlCommand selectTownsCommand =
                    new SqlCommand("SELECT t.Name \r\n   " +
                    "FROM Towns as t\r\n   " +
                    "JOIN Countries AS c ON c.Id = t.CountryCode\r\n  " +
                    "WHERE c.Name = @countryName",connection);

                selectTownsCommand.Parameters.AddWithValue("@countryName",
                    country);

                using SqlDataReader reader =
                    selectTownsCommand.ExecuteReader();
                List<string> names = new List<string>();
                while (reader.Read())
                {
                    names.Add((string)reader["Name"]);
                }
                if (names.Count>0)
                {
                    Console.WriteLine($"{changedTowns} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ",names)}]");
                }
                else
                {
                    PrintNoTowns();
                }
            }
        }
    }
}