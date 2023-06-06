using Microsoft.Data.SqlClient;
using RoomyTestTask.Interfaces.Context;
using System.Data;

namespace RoomyTestTask.Context
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
            => new SqlConnection(_configuration.GetConnectionString("SqlConnection"));

        public IDbConnection CreateMasterConnection()
            => new SqlConnection(_configuration.GetConnectionString("MasterConnection"));
    }
}
