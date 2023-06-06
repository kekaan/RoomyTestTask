using FluentAssertions;
using RoomyTestTask.Dtos;
using RoomyTestTask.Models;
using RoomyTestTaskTests.Helpers;

namespace RoomyTestTaskTests.ServicesTests.PaymentService
{
    public class PaymentServiceGetMethodsTests : IClassFixture<PaymentServiceTestsFixture>
    {
        private readonly PaymentServiceTestsFixture _paymentServiceTestsFixture;

        public PaymentServiceGetMethodsTests(PaymentServiceTestsFixture paymentServiceTestsFixture)
        {
            _paymentServiceTestsFixture = paymentServiceTestsFixture;
        }

        [Fact]
        public async void GetPaymentsByDocumentIdAsync_SuccessTest()
        {
            // Arrange
            Guid documentId = new("D414CC1A-CF0D-4E58-BB91-669D42B75F17");

            // Act
            IEnumerable<PaymentDto> result = await _paymentServiceTestsFixture.PaymentService.GetPaymentsByDocumentIdAsync(documentId);

            // Assert
            result.Should().BeEquivalentTo(PaymentsServiceTestsResults.Get_D414Document_Payments());
        }

        [Fact]
        public async void GetPaymentsByUserIdAsync_DocumentIdOverload_SuccessTest()
        {
            // Arrange
            Guid documentId = new("D414CC1A-CF0D-4E58-BB91-669D42B75F17");
            Guid userId = new("2D4C305C-8A0B-4720-B1A0-E5E557339333");

            // Act
            IEnumerable<PaymentDto> result = await _paymentServiceTestsFixture.PaymentService.GetPaymentsByUserIdAsync(userId, documentId);

            // Assert
            result.Should().BeEquivalentTo(PaymentsServiceTestsResults.Get_D414Document_2D4UserId_Payments());
        }

        [Fact]
        public async void GetPaymentsByUserIdAsync_DocumentNameOverload_AllDocuments_SuccessTest()
        {
            // Arrange
            Guid userId = new("3FF97A5A-3ABC-4227-A2C8-2047E5FE68A6");

            // Act
            IEnumerable<PaymentDto> result = await _paymentServiceTestsFixture.PaymentService.GetPaymentsByUserIdAsync(userId, null);

            // Assert
            result.Should().BeEquivalentTo(PaymentsServiceTestsResults.Get_AllDocument_3FFUserId_Payments());
        }

        [Fact]
        public async void GetPaymentsByContractNumberAsync_DocumentIdOverload_SuccessTest()
        {
            // Arrange
            Guid documentId = new("D414CC1A-CF0D-4E58-BB91-669D42B75F17");
            string contractNumber = "23A653157";

            // Act
            IEnumerable<PaymentDto> result = await _paymentServiceTestsFixture.PaymentService.GetPaymentsByContractNumberAsync(contractNumber, documentId);

            // Assert
            result.Should().BeEquivalentTo(PaymentsServiceTestsResults.Get_D414Document_23A653157ContractNumber_Payments());
        }

        [Fact]
        public async void GetPaymentsByContractNumberAsync_DocumentNameOverload_AllDocuments_SuccessTest()
        {
            // Arrange
            string contractNumber = "23A653157";

            // Act
            IEnumerable<PaymentDto> result = await _paymentServiceTestsFixture.PaymentService.GetPaymentsByContractNumberAsync(contractNumber, null);

            // Assert
            result.Should().BeEquivalentTo(PaymentsServiceTestsResults.Get_AllDocuments_23A653157ContractNumber_Payments());
        }

        [Fact]
        public async void GetPaymentsByUserIdAndContractNumberAsync_SuccessTest()
        {
            // Arrange
            Guid userId = new("3FF97A5A-3ABC-4227-A2C8-2047E5FE68A6");
            Guid documentId = new("D414CC1A-CF0D-4E58-BB91-669D42B75F17");
            string contractNumber = "23A653157";

            // Act
            IEnumerable<PaymentDto> result =
                await _paymentServiceTestsFixture.PaymentService.GetPaymentsByUserIdAndContractNumberAsync(userId, contractNumber, documentId);

            // Assert
            result.Should().BeEquivalentTo(PaymentsServiceTestsResults.Get_D414Document_3FFUserId_23A653157ContractNumber_Payments());
        }
    }
}
