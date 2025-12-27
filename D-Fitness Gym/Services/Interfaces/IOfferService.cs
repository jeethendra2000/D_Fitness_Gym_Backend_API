using D_Fitness_Gym.Models.DTO.OfferDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IOfferService : IBaseService<Offer, CreateOfferDto, UpdateOfferDto, RetrieveOfferDto>
    {
    }
}
