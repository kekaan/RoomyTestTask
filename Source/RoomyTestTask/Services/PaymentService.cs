using AutoMapper;
using RoomyTestTask.Dtos;
using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Interfaces.Services;
using RoomyTestTask.Models;

namespace RoomyTestTask.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByDocumentIdAsync(Guid? documentId)
        {
            IEnumerable<Payment> payments = await GetPaymentsByDocumentIdInternalAsync(documentId);

            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByUserIdAsync(Guid userId, Guid? documentId)
        {
            IEnumerable<PaymentDto> documentPayments = await GetPaymentsByDocumentIdAsync(documentId);
            return documentPayments.Where(e => e.UserId == userId);
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByContractNumberAsync(string contractNumber, Guid? documentId)
        {
            IEnumerable<PaymentDto> documentPayments = await GetPaymentsByDocumentIdAsync(documentId);
            return documentPayments.Where(e => e.ContractNumber == contractNumber);
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByUserIdAndContractNumberAsync(Guid userId, string contractNumber, Guid documentId)
        {
            IEnumerable<PaymentDto> documentPayments = await GetPaymentsByDocumentIdAsync(documentId);
            return documentPayments.Where(e => e.UserId == userId && e.ContractNumber == contractNumber);
        }

        private async Task<IEnumerable<Payment>> GetPaymentsByDocumentIdInternalAsync(Guid? documentId)
        {
            IEnumerable<Payment> payments = await _paymentRepository.GetPaymentsAsync();

            return documentId.HasValue ?
                payments.Where(e => e.DocumentId == documentId) :
                payments;
        }

        public async Task<IEnumerable<Guid>> DeletePaymentsByContractNumberAsync(string contractNumber)
        {
            return await _paymentRepository.DeletePaymentsByContractNumberAsync(contractNumber);
        }

        public async Task<IEnumerable<Guid>> DeletePaymentsByDocumentIdAsync(Guid documentId)
        {
            return await _paymentRepository.DeletePaymentsByDocumentIdAsync(documentId);
        }
    }
}
