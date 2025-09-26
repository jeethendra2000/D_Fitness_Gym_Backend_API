using AutoMapper;
using D_Fitness_Gym.Models.DTO.TransactionDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile() 
        {
            CreateMap<CreateTransactionDto, Transaction>().ReverseMap();
            CreateMap<UpdateTransactionDto, Transaction>().ReverseMap();
            CreateMap<Transaction, RetrieveTransactionDto>().ReverseMap();
        }
    }
}
