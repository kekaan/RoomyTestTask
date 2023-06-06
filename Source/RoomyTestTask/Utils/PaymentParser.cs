using System.Text;
using RoomyTestTask.Dtos;
using RoomyTestTask.Interfaces.Utils;

namespace RoomyTestTask.Utils
{
    public class PaymentParser : IPaymentParser
    {
        private const int FieldsCount = 5;

        public IEnumerable<PaymentDto> ParsePayments(StringBuilder data)
        {
            List<PaymentDto> payments = new();

            string dataString = data.ToString();
            string[] lines = dataString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] paymentData = line.Split(" -- ");

                if (paymentData.Length is not FieldsCount)
                    throw new InvalidDataException("Payment data could not be parsed correctly (wrong data format)");

                if (!Guid.TryParse(paymentData[0], out Guid userId))
                    throw new InvalidDataException("Payment data could not be parsed correctly (user id must be in guid format)");

                if (!int.TryParse(paymentData[4], out int writeOffAmount))
                    throw new InvalidDataException("Payment data could not be parsed correctly (write off amount must be integer)");

                payments.Add(new PaymentDto
                {
                    UserId = userId,
                    Name = paymentData[2],
                    Surname = paymentData[1],
                    ContractNumber = paymentData[3],
                    WriteOffAmount = int.Parse(paymentData[4]),
                });
            }

            return payments;
        }
    }
}
