using AutoMapper;
using D_Fitness_Gym.Models.DTO.GymDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class GymProfile : Profile
    {
        public GymProfile()
        {
            // ✅ Create Mapping (bidirectional)
            // Usually used for creating and returning confirmation responses.
            CreateMap<CreateGymDto, Gym>().ReverseMap();

            // ✅ Update Mapping (one-way, ignores nulls)
            // Ensures that only provided fields update; missing fields don’t overwrite with null.
            CreateMap<UpdateGymDto, Gym>().ForAllMembers(opts =>opts.Condition((src, dest, srcMember) => srcMember != null));

            // ✅ Retrieve Mapping (bidirectional if you reuse it for updates)
            CreateMap<Gym, RetrieveGymDto>().ReverseMap();
        }
    }
}
