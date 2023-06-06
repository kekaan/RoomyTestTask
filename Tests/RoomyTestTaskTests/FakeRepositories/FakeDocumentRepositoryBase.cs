using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Models;

namespace RoomyTestTaskTests.FakeRepositories
{
    public class FakeDocumentRepositoryBase : IDocumentRepository
    {
        public List<Document> DocumentsList { get; protected set; }

        public async Task<Guid> CreateDocumentAsync(string documentName)
        {
            Document newDocument = new Document { Id = Guid.NewGuid(), Name = documentName };
            DocumentsList.Add(newDocument);
            return newDocument.Id;
        }

        public async Task<bool> ExistsAsync(Guid documentId)
        {
            return DocumentsList.Any(e => e.Id == documentId);
        }

        public async Task<Guid?> GetDocumentIdByNameAsync(string documentName)
        {
            Guid? id = null;

            Document? document = DocumentsList.SingleOrDefault(e => e.Name == documentName);
            if (document is not null)
            {
                id = document.Id;
            }

            return id;
        }
    }
}
