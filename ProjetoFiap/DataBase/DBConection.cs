using Dapper;
using Microsoft.Data.SqlClient;
using ProjetoFiap.Models;

namespace ProjetoFiap.DataBase
{
    public class DBConection
    {
        public static IEnumerable<T> ExecutarQuery<T>(string query)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                IEnumerable<T> data = connection.Query<T>(query).ToList();

                connection.Close();

                return data;
            }
        }
    }
}
