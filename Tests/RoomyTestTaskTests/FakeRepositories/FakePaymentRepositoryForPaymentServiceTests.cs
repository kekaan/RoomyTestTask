using RoomyTestTask.Models;

namespace RoomyTestTaskTests.FakeRepositories
{
    public class FakePaymentRepositoryForPaymentServiceTests : FakePaymentRepositoryBase
    {
        public FakePaymentRepositoryForPaymentServiceTests()
        {
            SeedPayments();
        }

        private void SeedPayments()
        {
            PaymentsList = new List<Payment>()
            {
                new Payment
                {
                    UserId = new Guid("D7E52D14-7FB7-4EF9-A29C-199B455D8DA7"),
                    Name = "Анна",
                    Surname = "Овчинников",
                    ContractNumber = "33D987419",
                    WriteOffAmount = 65464,
                    DocumentId = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4")
                },
                new Payment
                {
                    UserId = new Guid("3FF97A5A-3ABC-4227-A2C8-2047E5FE68A6"),
                    Name = "Петр",
                    Surname = "Васильков",
                    ContractNumber = "23A653157",
                    WriteOffAmount = 2123,
                    DocumentId = new Guid("D414CC1A-CF0D-4E58-BB91-669D42B75F17")
                },
                new Payment
                {
                    UserId = new Guid("FA962CC1-FF17-4ED1-8259-2E7073B425A1"),
                    Name = "Сергей",
                    Surname = "Иванов",
                    ContractNumber = "13F579254",
                    WriteOffAmount = 75988,
                    DocumentId = new Guid("D414CC1A-CF0D-4E58-BB91-669D42B75F17")
                },
                new Payment
                {
                    UserId = new Guid("DFD80241-4376-4634-B97A-398E165EBE1F"),
                    Name = "Максим",
                    Surname = "Соболев",
                    ContractNumber = "33Q45665",
                    WriteOffAmount = 87895,
                    DocumentId = new Guid("D414CC1A-CF0D-4E58-BB91-669D42B75F17")
                },
                new Payment
                {
                    UserId = new Guid("2E9230DA-BB67-47AE-B823-441EB97C775C"),
                    Name = "Петр",
                    Surname = "Васильков",
                    ContractNumber = "23A653157",
                    WriteOffAmount = 13321,
                    DocumentId = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4")
                },
                new Payment
                {
                    UserId = new Guid("8C59BC66-5B87-4A3E-A884-6F2CBD7635E0"),
                    Name = "Ольга",
                    Surname = "Молотова",
                    ContractNumber = "78C746935",
                    WriteOffAmount = 5846,
                    DocumentId = new Guid("D414CC1A-CF0D-4E58-BB91-669D42B75F17")
                },
                new Payment
                {
                    UserId = new Guid("5B91CEAB-7D7A-4DBA-9782-76BA924DEF81"),
                    Name = "Иполит",
                    Surname = "Бобылёв",
                    ContractNumber = "15R653157",
                    WriteOffAmount = 56746,
                    DocumentId = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4")
                },
                new Payment
                {
                    UserId = new Guid("12CD289C-3DD1-4E75-9B51-79830BC8E686"),
                    Name = "Петр",
                    Surname = "Филатов",
                    ContractNumber = "23L653157",
                    WriteOffAmount = 7899,
                    DocumentId = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4")
                },
                new Payment
                {
                    UserId = new Guid("96583909-3901-4586-AFD8-8A84D6B1D50A"),
                    Name = "Игорь",
                    Surname = "Осипов",
                    ContractNumber = "12S21233",
                    WriteOffAmount = 12356,
                    DocumentId = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4")
                },
                new Payment
                {
                    UserId = new Guid("69553757-5D65-461C-8951-92525E50D474"),
                    Name = "Иван",
                    Surname = "Мотогромов",
                    ContractNumber = "18F56446",
                    WriteOffAmount = 549422,
                    DocumentId = new Guid("D414CC1A-CF0D-4E58-BB91-669D42B75F17")
                },
                new Payment
                {
                    UserId = new Guid("C73C6638-AC8B-4E2F-89D9-B7A06F4D0161"),
                    Name = "Игорь",
                    Surname = "Чернов",
                    ContractNumber = "13F579254",
                    WriteOffAmount = 75988,
                    DocumentId = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4")
                },
                new Payment
                {
                    UserId = new Guid("2D4C305C-8A0B-4720-B1A0-E5E557339333"),
                    Name = "Анна",
                    Surname = "Куликова",
                    ContractNumber = "33D987419",
                    WriteOffAmount = 846222,
                    DocumentId = new Guid("D414CC1A-CF0D-4E58-BB91-669D42B75F17")
                },
                new Payment
                {
                    UserId = new Guid("20B7D1DA-A8E8-4665-9E4A-EA29E94C4349"),
                    Name = "Егор",
                    Surname = "Муравьёв",
                    ContractNumber = "76A653157",
                    WriteOffAmount = 456,
                    DocumentId = new Guid("C55B2087-A689-4581-A582-2E5D7AC162D4")
                }
            };
        }
    }
}
