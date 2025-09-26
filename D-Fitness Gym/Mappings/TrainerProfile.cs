using AutoMapper;
using D_Fitness_Gym.Models.DTO.TrainerDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class TrainerProfile : Profile
    {
        public TrainerProfile()
        {
            CreateMap<CreateTrainerDto, Trainer>().ReverseMap();
            CreateMap<UpdateTrainerDto, Trainer>().ReverseMap();
            CreateMap<Trainer, RetrieveTrainerDto>().ReverseMap();
        }
    }
}
