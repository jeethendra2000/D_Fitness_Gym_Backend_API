using AutoMapper;
using D_Fitness_Gym.Models.DTO.OfferDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<CreateOfferDto, Offer>().ReverseMap();
            CreateMap<UpdateOfferDto, Offer>().ForAllMembers(opt => opt.Condition((src, dest, srcValue) => srcValue != null)); ;
            CreateMap<Offer, RetrieveOfferDto>().ReverseMap();
        }
    }
}
