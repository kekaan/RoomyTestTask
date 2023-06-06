using RoomyTestTask.Dtos;

namespace RoomyTestTaskTests.Helpers
{
    public static class DocumentServiceTestsResults
    {
        public static IEnumerable<PaymentDto> GetAllPayments()
        {
            return new List<PaymentDto>()
            {
                new PaymentDto
                {
                    UserId = new Guid("3FF97A5A-3ABC-4227-A2C8-2047E5FE68A6"),
                    Name = "Петр",
                    Surname = "Васильков",
                    ContractNumber = "23A653157",
                    WriteOffAmount = 2123
                },
                new PaymentDto
                {
                    UserId = new Guid("FA962CC1-FF17-4ED1-8259-2E7073B425A1"),
                    Name = "Сергей",
                    Surname = "Иванов",
                    ContractNumber = "13F579254",
                    WriteOffAmount = 75988
                },
                new PaymentDto
                {
                    UserId = new Guid("DFD80241-4376-4634-B97A-398E165EBE1F"),
                    Name = "Максим",
                    Surname = "Соболев",
                    ContractNumber = "33Q45665",
                    WriteOffAmount = 87895
                },
                new PaymentDto
                {
                    UserId = new Guid("8C59BC66-5B87-4A3E-A884-6F2CBD7635E0"),
                    Name = "Ольга",
                    Surname = "Молотова",
                    ContractNumber = "78C746935",
                    WriteOffAmount = 5846
                },
                new PaymentDto
                {
                    UserId = new Guid("69553757-5D65-461C-8951-92525E50D474"),
                    Name = "Иван",
                    Surname = "Мотогромов",
                    ContractNumber = "18F56446",
                    WriteOffAmount = 549422
                },
                new PaymentDto
                {
                    UserId = new Guid("2D4C305C-8A0B-4720-B1A0-E5E557339333"),
                    Name = "Анна",
                    Surname = "Куликова",
                    ContractNumber = "33D987419",
                    WriteOffAmount = 846222
                }
            };
        }
    }
}
