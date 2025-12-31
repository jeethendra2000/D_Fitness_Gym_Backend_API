using D_Fitness_Gym.Models.DTO.AccountDto;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.CustomerDto
{
    public class UpdateCustomerDto : UpdateAccountDto
    {

        [Range(0, 300, ErrorMessage = "Height must be between 0 and 300 cm.")]
        public double? Height { get; set; }

        [Range(0, 300, ErrorMessage = "Weight must be between 0 and 300 kg.")]
        public double? Weight { get; set; }
        public DateOnly? JoinedDate { get; set; }
        public bool? TrainerRequired { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
