using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

            await sqlConnection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            string result = await GetVillainsWithAllMinionsIdSync(sqlConnection, villainId);

            Console.WriteLine(result);
        }


        // Problem 2
        static async Task<string> GetAllVilliainsWithTheirMinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();


            SqlCommand sqlCommand = new SqlCommand(SQLQueries.GetAllVillainsAndCountOfTheirMinions, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");

            }

            return sb.ToString().TrimEnd();
        }

        //Problem 3
        static async Task<string> GetVillainsWithAllMinionsIdSync(SqlConnection sqlConnection, int villainId)
        {


            SqlCommand getVillainNameCmd = new SqlCommand(SQLQueries.GetVillainsNameById, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCmd.ExecuteScalarAsync();

            if (villainNameObj == null)
            {
                return $"No villain with ID {villainId} exist in the databse";
            }

            string villainName = (string)villainNameObj;

            SqlCommand getAllMinonsCmd = new SqlCommand(SQLQueries.GetAllMinionsByVillainId, sqlConnection);
            getAllMinonsCmd.Parameters.AddWithValue("Id", villainId);
            SqlDataReader minionsReader = await getAllMinonsCmd.ExecuteReaderAsync();

            string output = GenerateVillainWithMinionsOutput(villainName, minionsReader);
            return output;
        }
        private static string GenerateVillainWithMinionsOutput(string villainName, SqlDataReader minionsReader)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Villain: {villainName}");
            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNumber = (long)minionsReader["RowNum"];
                    string minionName = (string)minionsReader["Name"];
                    int minionAge = (int)minionsReader["age"];

                    sb.AppendLine($"{rowNumber}. {minionName} {minionAge}");
                }

            }
            return sb.ToString().TrimEnd();
        }

        //Problem 4

        static async Task<string> AddNewMinionAsync(SqlConnection sqlConnection, string minionsInfo, string villainName)
        {
            StringBuilder sb = new StringBuilder();

            string[] minionArgs = minionsInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string minonName = minionArgs[0];
            int minionAge = int.Parse(minionArgs[1]);

            string townName = minionArgs[2];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlCommand getTownIdCommand = new SqlCommand(SQLQueries.GetTownIdByName, sqlConnection);
                getTownIdCommand.Parameters.AddWithValue("@townName", townName);

                object? townIdObj = await getTownIdCommand.ExecuteScalarAsync();
                if (townIdObj == null)
                {
                    SqlCommand addNewTownCmd = new SqlCommand(SQLQueries.AddNewTown, sqlConnection);
                    addNewTownCmd.Parameters.AddWithValue("townName", townName);

                    addNewTownCmd.ExecuteNonQueryAsync();
                    townIdObj = await getTownIdCommand.ExecuteNonQueryAsync();
                    sb.AppendLine($"Town {townName} was added to the database.");
                }

                
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
