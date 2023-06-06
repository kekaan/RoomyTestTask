using AutoMapper;
using RoomyTestTask.Dtos;
using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Interfaces.Services;
using RoomyTestTask.Models;
using RoomyTestTask.Services;
using RoomyTestTaskTests.FakeRepositories;

namespace RoomyTestTaskTests.Helpers
{
    public class PaymentServiceTestsFixture
    {
        public IPaymentService PaymentService { get; private set; }
        public IPaymentRepository PaymentRepository { get; private set; } 

        public PaymentServiceTestsFixture()
        {
            MapperConfiguration config = new(config =>
            {
                config.CreateMap<Payment, PaymentDto>();
            });
            IMapper mapper = config.CreateMapper();

            PaymentRepository = new FakePaymentRepositoryForPaymentServiceTests();
            PaymentService = new PaymentService(PaymentRepository, mapper);
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
        }
    }
}
