using AutoMapper;
using D_Fitness_Gym.Models.DTO.OfferDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class OfferService : BaseService<Offer, CreateOfferDto, UpdateOfferDto, RetrieveOfferDto>, IOfferService
    {
        public OfferService(IOfferRepository offerRepository, IMapper mapper, ILogger<BaseService<Offer, CreateOfferDto, UpdateOfferDto, RetrieveOfferDto>> logger) : base(offerRepository, mapper, logger)
        {
        }
    }
}
