using Dapper;
using System.Data;
using RoomyTestTask.Dtos;
using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Models;
using RoomyTestTask.Interfaces.Context;

namespace RoomyTestTask.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public PaymentRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            string query = "SELECT * FROM Payment";

            return await _databaseConnectionFactory.GetConnection().QueryAsync<Payment>(query);
        }

        public async Task<IEnumerable<Guid>> DeletePaymentsByDocumentIdAsync(Guid documentId)
        {
            string query = "DELETE FROM Payment WHERE DocumentId = @DocumentId";

            DynamicParameters parameters = new();
            parameters.Add("DocumentId", documentId, DbType.Guid);

            IEnumerable<Payment> deletedPayments = await _databaseConnectionFactory.GetConnection().QueryAsync<Payment>(query, parameters);
            return deletedPayments.Select(x => x.UserId);
        }

        public async Task CreatePaymentsAsync(IEnumerable<PaymentDto> payments, Guid documentId)
        {
            string query = "INSERT INTO Payment (UserId, Name, Surname, ContractNumber, WriteOffAmount, DocumentId) " +
                "VALUES (@UserId, @Name, @Surname, @ContractNumber, @WriteOffAmount, @DocumentId)";

            using (IDbConnection connection = _databaseConnectionFactory.GetConnection())
            {
                foreach (PaymentDto payment in payments)
                {
                    DynamicParameters parameters = new();

                    parameters.Add("UserId", payment.UserId, DbType.Guid);
                    parameters.Add("Name", payment.Name, DbType.String);
                    parameters.Add("Surname", payment.Surname, DbType.String);
                    parameters.Add("ContractNumber", payment.ContractNumber, DbType.String);
                    parameters.Add("WriteOffAmount", payment.WriteOffAmount, DbType.Int32);
                    parameters.Add("DocumentId", documentId, DbType.Guid);

                    await connection.QueryAsync(query, parameters);
                }
            }
        }

        public async Task<IEnumerable<Guid>> DeletePaymentsByContractNumberAsync(string contractNumber)
        {
            string query = "DELETE FROM Payment WHERE ContractNumber = @ContractNumber";

            DynamicParameters parameters = new();
            parameters.Add("ContractNumber", contractNumber, DbType.String);

            IEnumerable<Payment> deletedPayments = await _databaseConnectionFactory.GetConnection().QueryAsync<Payment>(query, parameters);
            return deletedPayments.Select(x => x.UserId);
        }
    }
}
