using Microsoft.Data.SqlClient;

namespace AddMinion
{
    internal class AddMinion
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split(" ");
            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string[] villainInfo = Console.ReadLine().Split(" ");
            string villainName = villainInfo[1];

            string connectionString =
                "";

            using SqlConnection connection
                = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand findTownCommand = 
                new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", connection);
            
            findTownCommand.Parameters.Add(new SqlParameter("@townName", minionTown));
            object town = findTownCommand.ExecuteScalar();
            if (town==null)
            {
                SqlCommand addTownCommand =
                    new SqlCommand("INSERT INTO Towns (Name) VALUES (@townName)"
                    , connection);
                addTownCommand.Parameters.Add(new SqlParameter("@townName", minionTown));
                addTownCommand.ExecuteScalar();
                Console.WriteLine($"Town {minionTown} was added to the database.");
                town = findTownCommand.ExecuteScalar();
            }

            SqlCommand findVillainCommand =
                new SqlCommand("SELECT Id FROM Villains WHERE Name = @Name", connection);

            findVillainCommand.Parameters.Add(new SqlParameter("@Name", villainName));
            object villain = findVillainCommand.ExecuteScalar();
            if (villain == null)
            {
                SqlCommand addVillainCommand =
                    new SqlCommand("INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)"
                    , connection);
                addVillainCommand.Parameters.Add(new SqlParameter("@villainName", villainName));
                addVillainCommand.ExecuteScalar();
                Console.WriteLine($"Villain {villainName} was added to the database.");
                villain = findVillainCommand.ExecuteScalar();
            }

            SqlCommand findMinionCommand =
                new SqlCommand("SELECT Id FROM Minions WHERE Name = @Name", connection);

            findMinionCommand.Parameters.Add(new SqlParameter("@Name",minionName));
            object minion = findMinionCommand.ExecuteScalar();

            SqlCommand insertMinionCommand =
                new SqlCommand("INSERT INTO Minions (Name, Age, TownId) " +
                "VALUES (@name, @age, @townId)",connection);

            insertMinionCommand.Parameters.Add(new SqlParameter("@name",minionName));
            insertMinionCommand.Parameters.Add(new SqlParameter("@age",minionAge));
            insertMinionCommand.Parameters.Add(new SqlParameter("@townId",town));

            insertMinionCommand.ExecuteScalar();

            SqlCommand insertMinionVillainCommand =
                new SqlCommand("INSERT INTO MinionsVillains (MinionId, VillainId) " +
                "VALUES (@minionId, @villainId)", connection);

            insertMinionVillainCommand.Parameters.Add(new SqlParameter("@minionId", minion));
            insertMinionVillainCommand.Parameters.Add(new SqlParameter("@villainId", villain));

            insertMinionVillainCommand.ExecuteScalar();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}