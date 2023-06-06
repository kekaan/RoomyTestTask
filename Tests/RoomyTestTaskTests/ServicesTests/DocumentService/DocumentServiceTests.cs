using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using RoomyTestTask.Dtos;
using RoomyTestTask.Models;
using RoomyTestTaskTests.Helpers;

namespace RoomyTestTaskTests.ServicesTests.DocumentService
{
    public class DocumentServiceTests : IClassFixture<DocumentServiceTestsFixture>
    {
        private const string ValidTestFileName = "FB13187-3 (1)";

        private readonly DocumentServiceTestsFixture _documentServiceTestsFixture;

        public DocumentServiceTests(DocumentServiceTestsFixture documentServiceTestsFixture)
        {
            _documentServiceTestsFixture = documentServiceTestsFixture;
        }

        [Fact]
        public async void PostDocumentAsync_SuccessTest()
        {
            // Arrange
            string filePath = $"TestDocuments/{ValidTestFileName}";
            using MemoryStream stream1 = new(File.ReadAllBytes(filePath).ToArray());
            FormFile formFile = new(stream1, 0, stream1.Length, "streamFile", ValidTestFileName);

            // Act
            Guid documentId = await _documentServiceTestsFixture.DocumentService.PostDocumentAsync(formFile);

            // Assert
            IEnumerable<Payment> allPayments = await _documentServiceTestsFixture.PaymentRepository.GetPaymentsAsync();
            MapperConfiguration config = new(config =>
            {
                config.CreateMap<Payment, PaymentDto>();
            });
            IMapper mapper = config.CreateMapper();

            IEnumerable<Payment> allPaymentsDtos = mapper.Map<IEnumerable<Payment>>(allPayments);
            allPayments.Should().BeEquivalentTo(DocumentServiceTestsResults.GetAllPayments());

            Assert.True(await _documentServiceTestsFixture.DocumentRepository.ExistsAsync(documentId));
        }

        [Theory]
        [InlineData("NotValid", "Payment data could not be parsed correctly (wrong data format)")]
        [InlineData("NotValidUserId", "Payment data could not be parsed correctly (user id must be in guid format)")]
        [InlineData("NotValidWriteOffAmount", "Payment data could not be parsed correctly (write off amount must be integer)")]
        public async void PostDocumentAsync_ThrowsInvalidDataException(string fileName, string expectedExceptionMessage)
        {
            // Arrange
            string filePath = $"TestDocuments/{fileName}";
            using MemoryStream stream1 = new(File.ReadAllBytes(filePath).ToArray());
            FormFile formFile = new(stream1, 0, stream1.Length, "streamFile", fileName);

            // Act
            // Assert
            InvalidDataException exception =
                await Assert.ThrowsAsync<InvalidDataException>(() => _documentServiceTestsFixture.DocumentService.PostDocumentAsync(formFile));
            Assert.Equal(exception.Message, expectedExceptionMessage);
        }

        [Fact]
        public async void GetDocumentIdByNameAsync_SuccessTest()
        {
            // Arrange
            Guid expectedDocumentId = new("C55B2087-A689-4581-A582-2E5D7AC162D4");

            // Act
            Guid? result = await _documentServiceTestsFixture.DocumentService.GetDocumentIdByNameAsync("FС12833-1 (5)");

            //Assert
            Assert.Equal(expectedDocumentId, result);
        }
    }
}
