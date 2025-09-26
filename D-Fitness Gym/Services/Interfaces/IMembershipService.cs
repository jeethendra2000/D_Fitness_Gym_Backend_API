using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IMembershipService : IBaseService<Membership, CreateMembershipDto, UpdateMembershipDto, RetrieveMembershipDto>
    {
    // Membership-specific methods can be added here
    }
}
