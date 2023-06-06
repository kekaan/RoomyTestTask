using Dapper;
using RoomyTestTask.Interfaces.Context;
using System.Data;

namespace RoomyTestTask.Migrations
{
    public class Database
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public Database(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public void CreateDatabase(string databaseName)
        {
            string query = "SELECT * FROM sys.databases WHERE name = @name";
            DynamicParameters parameters = new();
            parameters.Add("name", databaseName);

            using (IDbConnection connection = _databaseConnectionFactory.CreateMasterConnection())
            {
                IEnumerable<dynamic> records = connection.Query(query, parameters);
                if (!records.Any())
                    connection.Execute($"CREATE DATABASE {databaseName}");
            }
        }
    }
}
