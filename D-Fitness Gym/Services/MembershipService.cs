using AutoMapper;
using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class MembershipService : BaseService<Membership, CreateMembershipDto, UpdateMembershipDto, RetrieveMembershipDto>, IMembershipService
    {

        public MembershipService(IMembershipRepository membershipRepository, IMapper mapper, ILogger<BaseService<Membership, CreateMembershipDto, UpdateMembershipDto, RetrieveMembershipDto>> logger) : base(membershipRepository, mapper, logger)
        {
        }
        // Membership-specific methods can be added here
    }
}
