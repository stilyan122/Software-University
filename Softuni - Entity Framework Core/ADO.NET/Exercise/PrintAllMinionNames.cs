using Microsoft.Data.SqlClient;
using System.Threading.Channels;

namespace PrintAllMinionNames
{
    internal class PrintAllMinionNames
    {
        static void Main(string[] args)
        {
            string connectionString =
                "";

            using SqlConnection connection =
                new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command =
                new SqlCommand("SELECT Name FROM Minions", connection);

            List<string> minionNames = new List<string>();
            using SqlDataReader reader = 
                command.ExecuteReader();
            while (reader.Read()) 
            {
                string name = (string)reader[0];
                minionNames.Add(name);
            }
            int start = 0;
            int end = minionNames.Count - 1;
            double length = Math.Ceiling((double)(minionNames.Count) / 2.0);
            for (int i = 0; i < length; i++)
            {
                if (Math.Abs(start - end) == 1 && minionNames.Count % 2 == 0)
                {
                    break;
                }
                else if (minionNames.Count % 2 == 1 && 
                    start==end)
                {
                    Console.WriteLine(minionNames[start+1]);
                    break;
                }
                Console.WriteLine(minionNames[start]);
                Console.WriteLine(minionNames[end]);
                start++;
                end--;
            }
        }
    }
}