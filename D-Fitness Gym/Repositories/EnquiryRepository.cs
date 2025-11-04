using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;

namespace D_Fitness_Gym.Repositories
{
    public class EnquiryRepository : BaseRepository<Enquiry>, IEnquiryRepository
    {
        public EnquiryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
