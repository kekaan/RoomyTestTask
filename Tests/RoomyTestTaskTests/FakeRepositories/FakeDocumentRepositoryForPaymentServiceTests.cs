using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Models;


namespace RoomyTestTaskTests.FakeRepositories
{
    public class FakeDocumentRepositoryForPaymentServiceTests : FakeDocumentRepositoryBase
    {
        public FakeDocumentRepositoryForPaymentServiceTests()
        {
            SeedDocuments();
        }

        public void SeedDocuments()
        {
            DocumentsList = new List<Document>()
            {
                new Document
                {
                    Id = new Guid("D414CC1A-CF0D-4E58-BB91-669D42B75F17"),
                    Name = "FB13187-3 (1)"
                },
                new Document
                {
                    Id = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4"),
                    Name = "FС12833-1 (5)"
                }
            };
        }

        public async Task<Guid> CreateDocumentAsync(string documentName)
        {
            Document newDocument = new Document { Id = Guid.NewGuid(), Name = documentName };
            DocumentsList.Add(newDocument);
            return newDocument.Id;
        }

        public async Task<bool> ExistsAsync(string documentName)
        {
            return DocumentsList.Any(e => e.Name == documentName);
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
