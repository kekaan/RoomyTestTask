using RoomyTestTask.Dtos;

namespace RoomyTestTask.Interfaces.Services
{
    public interface IPaymentService
    {
        public Task<IEnumerable<PaymentDto>> GetPaymentsByDocumentIdAsync(Guid? documentId);
        public Task<IEnumerable<PaymentDto>> GetPaymentsByUserIdAsync(Guid userId, Guid? documentId);
        public Task<IEnumerable<PaymentDto>> GetPaymentsByContractNumberAsync(string contractNumber, Guid? documentId);
        public Task<IEnumerable<PaymentDto>> GetPaymentsByUserIdAndContractNumberAsync(Guid userId, string contractNumber, Guid documentId);
        public Task<IEnumerable<Guid>> DeletePaymentsByContractNumberAsync(string contractNumber);
        public Task<IEnumerable<Guid>> DeletePaymentsByDocumentIdAsync(Guid documentId);
    }
}
