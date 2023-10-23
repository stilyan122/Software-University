using Microsoft.Data.SqlClient;

namespace MinionNames
{
    internal class MinionNames
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            string connectionString =
            "";
            SqlConnection connection
                = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                SqlCommand command1 =
                    new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id\r\n\r\n",
                     connection);
                SqlCommand command2 =
                    new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,\r\n " +
                    "m.Name, \r\n" +
                    "m.Age\r\n" +
                    "FROM MinionsVillains AS mv\r\n" +
                    "JOIN Minions As m ON mv.MinionId = m.Id\r\n  " +
                    "WHERE mv.VillainId = @Id\r\n      " +
                    "ORDER BY m.Name", connection);
                command1.Parameters.Add(new SqlParameter("@Id", id));
                command2.Parameters.Add(new SqlParameter("@Id", id));
                object result = command1.ExecuteScalar();
                if (result != null) 
                { 
                    Console.WriteLine($"Villain: {command1.ExecuteScalar()}");
                    using SqlDataReader reader =
                        command2.ExecuteReader();
                    bool canRead = false;
                    int counter = 1;
                    while (reader.Read())
                    {
                        canRead = true;
                        string name = (string)reader["Name"];
                        int age = (int)reader["Age"];
                        Console.WriteLine($"{counter}. {name} {age}");
                        counter++;
                    }
                    if (!canRead)
                    {
                        Console.WriteLine("(no minions)");
                    }
                }
                else
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }
            }
        }
    }
}