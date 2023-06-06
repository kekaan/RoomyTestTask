using RoomyTestTask.Models;

namespace RoomyTestTask.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        public Task<Guid> CreateDocumentAsync(string documentName);
        public Task<Guid?> GetDocumentIdByNameAsync(string documentName);
        public Task<bool> ExistsAsync(Guid documentId);
    }
}
