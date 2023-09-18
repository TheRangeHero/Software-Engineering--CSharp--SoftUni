using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace AdoDotNetIntroduction
{
    class Program
    {
        static async Task Main(string[] args) // async Task се прави специално за Async методти като command.ExecuteScalarAsync и се слага await пред него за да не минава по маин треда по време на екзекютване
        {
            SqlConnection connection = new SqlConnection("Server=TheRangeHero\\SQLEXPRESS;Database=SoftUni;User=THERANGEHERO\\STORM;Integrated Security=true;Trust Server Certificate=true");

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT* FROM Employees WHERE DepartmentID = 9", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string? firstName = reader["FirstName"]?.ToString();
                        string lastName = reader[2].ToString();
                        Console.WriteLine($"{firstName} {lastName}");
                    }
                }

            }
        }
    }
}
