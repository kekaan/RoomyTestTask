namespace RoomyTestTask.Models
{
    public class Payment
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string ContractNumber { get; set; } = null!;
        public int WriteOffAmount { get; set; }
        public Guid DocumentId { get; set; }
    }
}
