using RoomyTestTask.Models;

namespace RoomyTestTaskTests.FakeRepositories
{
    public class FakePaymentRepositoryForDocumentServiceTests : FakePaymentRepositoryBase
    {
        public FakePaymentRepositoryForDocumentServiceTests()
        {
            PaymentsList = new List<Payment>();
        }
    }
}
