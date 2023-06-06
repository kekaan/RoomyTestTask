using System.Text;
using RoomyTestTask.Dtos;
using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Interfaces.Services;
using RoomyTestTask.Interfaces.Utils;
using RoomyTestTask.Models;

namespace RoomyTestTask.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IFileReader _fileReader;
        private readonly IPaymentParser _paymentParser;
        private readonly IDocumentRepository _documentRepository;
        private readonly IPaymentRepository _paymentRepository;

        public DocumentService(IFileReader fileReader, IPaymentParser paymentParser, IDocumentRepository documentRepository, IPaymentRepository paymentRepository)
        {
            _fileReader = fileReader;
            _paymentParser = paymentParser;
            _documentRepository = documentRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> DocumentExistsAsync(Guid documentId)
        {
            return await _documentRepository.ExistsAsync(documentId);
        }

        public async Task<Guid?> GetDocumentIdByNameAsync(string documentName)
        {
            return await _documentRepository.GetDocumentIdByNameAsync(documentName);
        }

        public async Task<Guid> PostDocumentAsync(IFormFile postedDocument)
        {
            string documentName = postedDocument.FileName;

            Guid? documentId = await _documentRepository.GetDocumentIdByNameAsync(documentName);
            bool documentExists = documentId.HasValue;

            IEnumerable<PaymentDto> payments = GetPaymentsFromDocumentFile(postedDocument);

            if (documentExists)
            {
                documentId = await _documentRepository.GetDocumentIdByNameAsync(documentName);
                await _paymentRepository.DeletePaymentsByDocumentIdAsync(documentId.Value);
            }
            else
            {
                documentId = await _documentRepository.CreateDocumentAsync(documentName);
            }

            await _paymentRepository.CreatePaymentsAsync(payments, documentId.Value);

            return documentId.Value;
        }

        private async Task CreateUsersAsync(IFormFile documentFile, Guid documentId)
        {
            IEnumerable<PaymentDto> payments = GetPaymentsFromDocumentFile(documentFile);

            await _paymentRepository.CreatePaymentsAsync(payments, documentId);
        }

        private IEnumerable<PaymentDto> GetPaymentsFromDocumentFile(IFormFile documentFile)
        {
            StringBuilder fileText = _fileReader.GetFileText(documentFile);
            IEnumerable<PaymentDto> payments = _paymentParser.ParsePayments(fileText);
            return payments;
        }
    }
}
