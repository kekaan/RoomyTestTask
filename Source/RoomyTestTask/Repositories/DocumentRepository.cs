using Dapper;
using System.Data;
using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Interfaces.Context;
using RoomyTestTask.Models;

namespace RoomyTestTask.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public DocumentRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<bool> ExistsAsync(Guid documentId)
        {
            string query = "SELECT * FROM Document WHERE Id = @Id";

            DynamicParameters parameters = new();
            parameters.Add("Id", documentId, DbType.Guid);

            IEnumerable<Document> documents = await _databaseConnectionFactory.GetConnection().QueryAsync<Document>(query, parameters);
            return documents.Any();
        }

        public async Task<Guid?> GetDocumentIdByNameAsync(string documentName)
        {
            string query = "SELECT * FROM Document WHERE Name = @Name";

            DynamicParameters parameters = new();
            parameters.Add("Name", documentName, DbType.String);

            Document document = await _databaseConnectionFactory.GetConnection().QuerySingleOrDefaultAsync<Document>(query, parameters);
            return document is not null ? document.Id : null;
        }

        public async Task<Guid> CreateDocumentAsync(string documentName)
        {
            string query = "INSERT INTO Document (Id, Name) VALUES (@Id, @Name)";

            Guid documentId = Guid.NewGuid();

            DynamicParameters parameters = new();
            parameters.Add("Id", documentId, DbType.Guid);
            parameters.Add("Name", documentName, DbType.String);

            await _databaseConnectionFactory.GetConnection().QueryAsync(query, parameters);

            return documentId;
        }
    }
}
