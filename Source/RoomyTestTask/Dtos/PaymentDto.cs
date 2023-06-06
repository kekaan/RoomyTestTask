namespace RoomyTestTask.Dtos
{
    public class PaymentDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string ContractNumber { get; set; } = null!;
        public int WriteOffAmount { get; set; }
    }
}
