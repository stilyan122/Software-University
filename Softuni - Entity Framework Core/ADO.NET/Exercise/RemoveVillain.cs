using Microsoft.Data.SqlClient;

namespace RemoveVillain
{
    internal class RemoveVillain
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            string connectionString =
                "";

            using SqlConnection connection =
                new SqlConnection(connectionString);

            connection.Open();

            SqlCommand findVillainCommand =
                new SqlCommand("SELECT Name FROM Villains WHERE Id = @villainId\r\n", connection);

            findVillainCommand.Parameters.Add(new SqlParameter("@villainId", id));
            object villain = findVillainCommand.ExecuteScalar();
            if (villain==null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            SqlCommand deleteMinionsCommand =
                new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @villainId",
                connection);

            deleteMinionsCommand.Parameters.Add(new SqlParameter("@villainId", id));
            int count = deleteMinionsCommand.ExecuteNonQuery();

            SqlCommand deleteVillainCommand =
                new SqlCommand("DELETE FROM Villains WHERE Id = @villainId", connection);

            deleteVillainCommand.Parameters.Add(new SqlParameter("@villainId", id));
            deleteVillainCommand.ExecuteNonQuery();

            Console.WriteLine($"{villain} was deleted.");
            Console.WriteLine($"{count} minions were released.");
        }
    }
}