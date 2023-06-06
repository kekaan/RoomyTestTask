using FluentAssertions;
using RoomyTestTask.Models;
using RoomyTestTaskTests.Helpers;

namespace RoomyTestTaskTests.ServicesTests.PaymentService
{
    public class PaymentServiceDeleteByContractNumberTests : IClassFixture<PaymentServiceTestsFixture>
    {
        private readonly PaymentServiceTestsFixture _paymentServiceTestsFixture;

        public PaymentServiceDeleteByContractNumberTests(PaymentServiceTestsFixture paymentServiceTestsFixture)
        {
            _paymentServiceTestsFixture = paymentServiceTestsFixture;
        }

        [Fact]
        public async void DeletePaymentsByContractNumberAsync_SuccessTest()
        {
            // Arrange
            string contractNumber = "23A653157";
            IEnumerable<Payment> allPayments = await _paymentServiceTestsFixture.PaymentRepository.GetPaymentsAsync();
            int expectedPaymentsCount = allPayments.Count() - PaymentsServiceTestsResults.Get_23A653157ContractNumber_DeletedPaymentsGuids().Count();

            // Act
            IEnumerable<Guid> result = await _paymentServiceTestsFixture.PaymentService.DeletePaymentsByContractNumberAsync(contractNumber);

            // Assert
            result.Should().BeEquivalentTo(PaymentsServiceTestsResults.Get_23A653157ContractNumber_DeletedPaymentsGuids());

            allPayments = await _paymentServiceTestsFixture.PaymentRepository.GetPaymentsAsync();
            int resultPaymentsCount = allPayments.Count();

            Assert.Equal(resultPaymentsCount, expectedPaymentsCount);
        }
    }
    public class PaymentServiceDeleteByDocumentNameTests : IClassFixture<PaymentServiceTestsFixture>
    {
        private readonly PaymentServiceTestsFixture _paymentServiceTestsFixture;

        public PaymentServiceDeleteByDocumentNameTests(PaymentServiceTestsFixture paymentServiceTestsFixture)
        {
            _paymentServiceTestsFixture = paymentServiceTestsFixture;
        }

        [Fact]
        public async void DeletePaymentsByDocumentName_SuccessTest()
        {
            // Arrange
            Guid documentId = new("D414CC1A-CF0D-4E58-BB91-669D42B75F17");
            IEnumerable<Payment> allPayments = await _paymentServiceTestsFixture.PaymentRepository.GetPaymentsAsync();
            int expectedPaymentsCount = allPayments.Count() - PaymentsServiceTestsResults.Get_FB13187Document_DeletedPaymentsGuids().Count();

            // Act
            IEnumerable<Guid> result = await _paymentServiceTestsFixture.PaymentService.DeletePaymentsByDocumentIdAsync(documentId);

            // Assert
            result.Should().BeEquivalentTo(PaymentsServiceTestsResults.Get_FB13187Document_DeletedPaymentsGuids());

            allPayments = await _paymentServiceTestsFixture.PaymentRepository.GetPaymentsAsync();
            int resultPaymentsCount = allPayments.Count();

            Assert.Equal(resultPaymentsCount, expectedPaymentsCount);
        }
    }
}
