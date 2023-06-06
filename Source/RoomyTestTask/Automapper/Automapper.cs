using AutoMapper;
using RoomyTestTask.Dtos;
using RoomyTestTask.Models;

namespace RoomyTestTask.Automapper
{
    public class Automapper : Profile
    {
        public Automapper() 
        {
            CreateMap<Payment, PaymentDto>();
        }
    }
}
