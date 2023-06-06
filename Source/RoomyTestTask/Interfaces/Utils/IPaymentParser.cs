using System.Text;
using RoomyTestTask.Dtos;

namespace RoomyTestTask.Interfaces.Utils
{
    public interface IPaymentParser
    {
        public IEnumerable<PaymentDto> ParsePayments(StringBuilder data);
    }
}
