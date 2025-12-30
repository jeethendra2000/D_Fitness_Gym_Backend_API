namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IImageService
    {
        Task<string?> UploadImageAsync(IFormFile file, string folderName);
        void DeleteImage(string? imageUrl);
    }
}
