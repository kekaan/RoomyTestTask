using RoomyTestTask.Dtos;
using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Models;

namespace RoomyTestTaskTests.FakeRepositories
{
    public class FakePaymentRepositoryBase : IPaymentRepository
    {
        public List<Payment> PaymentsList { get; protected set; }

        public async Task CreatePaymentsAsync(IEnumerable<PaymentDto> payments, Guid documentId)
        {
            foreach (PaymentDto payment in payments)
            {
                PaymentsList.Add(new Payment
                {
                    UserId = payment.UserId,
                    Name = payment.Name,
                    Surname = payment.Surname,
                    ContractNumber = payment.ContractNumber,
                    WriteOffAmount = payment.WriteOffAmount,
                    DocumentId = documentId
                });
            }
        }

        public async Task<IEnumerable<Guid>> DeletePaymentsByContractNumberAsync(string contractNumber)
        {
            IEnumerable<Guid> paymentsToDelete = PaymentsList
                .Where(e => e.ContractNumber == contractNumber)
                .Select(e => e.UserId)
                .ToList();

            PaymentsList.RemoveAll(e => e.ContractNumber == contractNumber);

            return paymentsToDelete;
        }

        public async Task<IEnumerable<Guid>> DeletePaymentsByDocumentIdAsync(Guid documentId)
        {
            IEnumerable<Guid> paymentsToDelete = PaymentsList
                .Where(e => e.DocumentId == documentId)
                .Select(e => e.UserId)
                .ToList();

            PaymentsList.RemoveAll(e => e.DocumentId == documentId);

            return paymentsToDelete;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return PaymentsList;
        }
    }
}
