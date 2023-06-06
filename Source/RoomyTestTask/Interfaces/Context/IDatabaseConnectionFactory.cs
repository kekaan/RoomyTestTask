using System.Data;

namespace RoomyTestTask.Interfaces.Context
{
    public interface IDatabaseConnectionFactory
    {
        public IDbConnection GetConnection();
        public IDbConnection CreateMasterConnection();
    }
}
