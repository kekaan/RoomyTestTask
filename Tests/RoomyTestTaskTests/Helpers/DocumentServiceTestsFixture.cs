using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Interfaces.Services;
using RoomyTestTask.Services;
using RoomyTestTask.Utils;
using RoomyTestTaskTests.FakeRepositories;

namespace RoomyTestTaskTests.Helpers
{
    public class DocumentServiceTestsFixture
    {
        public IDocumentService DocumentService { get; private set; }
        public IPaymentRepository PaymentRepository { get; private set; }
        public IDocumentRepository DocumentRepository { get; private set; }

        public DocumentServiceTestsFixture()
        {
            PaymentRepository = new FakePaymentRepositoryForDocumentServiceTests();
            DocumentRepository = new FakeDocumentRepositoryForDocumentServiceTests();
            DocumentService = new DocumentService(new FileReader(), new PaymentParser() , DocumentRepository, PaymentRepository);
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
        }
    }
}
