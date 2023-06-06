using RoomyTestTask.Models;

namespace RoomyTestTaskTests.FakeRepositories
{
    public class FakeDocumentRepositoryForDocumentServiceTests : FakeDocumentRepositoryBase
    {
        public FakeDocumentRepositoryForDocumentServiceTests()
        {
            DocumentsList = new List<Document>()
            {   
                new Document
                {
                    Id = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4"),
                    Name = "FС12833-1 (5)"
                }
            };
        }
    }
}
