using AutoMapper;
using D_Fitness_Gym.Models.DTO.TrainerDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class TrainerService : BaseService<Trainer, CreateTrainerDto, UpdateTrainerDto, RetrieveTrainerDto>, ITrainerService
    {
        private readonly IImageService _imageService;
        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper, ILogger<TrainerService> logger, IImageService imageService) : base(trainerRepository, mapper, logger)
        {
            _imageService = imageService;
        }
        public override async Task<RetrieveTrainerDto> CreateAsync(CreateTrainerDto dto)
        {
            // Map DTO to Entity
            var trainer = _mapper.Map<Trainer>(dto);

            // Handle Image Upload: Pass the file from the DTO to the service 
            if (dto.ProfileImageFile != null)
            {
                trainer.ProfileImageUrl = await _imageService.UploadImageAsync(dto.ProfileImageFile, "trainers");
            }

            // Save to DB via Repository
            var createdTrainer = await _baseRepository.CreateAsync(trainer);
            return _mapper.Map<RetrieveTrainerDto>(createdTrainer);
        }

        public override async Task<RetrieveTrainerDto?> UpdateAsync(Guid id, UpdateTrainerDto dto)
        {
            var existingTrainer = await CheckIfRecordExistsAsync(id);
            if (existingTrainer == null) return null;

            // Handle Image Update logic: If a new file is provided in the DTO
            if (dto.ProfileImageFile != null)
            {
                // Delete the current file
                _imageService.DeleteImage(existingTrainer.ProfileImageUrl);

                // Upload new image and update the string property in the Entity
                existingTrainer.ProfileImageUrl = await _imageService.UploadImageAsync(dto.ProfileImageFile, "trainers");
            }

            // Map other fields from DTO to the existing entity
            _mapper.Map(dto, existingTrainer);

            // Save to DB via Repository
            var updatedTrainer = await _baseRepository.UpdateAsync(existingTrainer);
            return _mapper.Map<RetrieveTrainerDto>(updatedTrainer);
        }
        public override async Task<bool> DeleteAsync(Guid id)
        {
            var existingTrainer = await CheckIfRecordExistsAsync(id);
            if (existingTrainer != null && !string.IsNullOrEmpty(existingTrainer.ProfileImageUrl))
            {
                // Clean up the image file when the record is deleted
                _imageService.DeleteImage(existingTrainer.ProfileImageUrl);
            }

            return await base.DeleteAsync(id);
        }
    }
}
