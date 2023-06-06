using RoomyTestTask.Dtos;
using RoomyTestTask.Models;

namespace RoomyTestTask.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        public Task<IEnumerable<Payment>> GetPaymentsAsync();
        public Task CreatePaymentsAsync(IEnumerable<PaymentDto> payments, Guid documentId);
        public Task<IEnumerable<Guid>> DeletePaymentsByDocumentIdAsync(Guid documentId);
        public Task<IEnumerable<Guid>> DeletePaymentsByContractNumberAsync(string contractNumber);
    }
}
