using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace D_Fitness_Gym.Services
{
    public class ImageService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor) : IImageService
    {
        public async Task<string?> UploadImageAsync(IFormFile? file, string folderName)
        {
            if (file == null || file.Length == 0) return null;

            // Ensure root path exists
            var rootPath = webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadPath = Path.Combine(rootPath, "images", folderName);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Generate unique filename to prevent overwriting
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Build full URL
            var request = httpContextAccessor.HttpContext.Request;
            return $"{request.Scheme}://{request.Host}{request.PathBase}/images/{folderName}/{fileName}";
        }
        public void DeleteImage(string? imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl)) return;

            try
            {
                // Convert URL to physical path
                var uri = new Uri(imageUrl);
                var fileName = Path.GetFileName(uri.LocalPath);

                // You may need to adjust this pathing based on your folder structure
                var rootPath = webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                // Extract the folder name from the URL path (e.g., /uploads/customers/...)
                var pathParts = uri.LocalPath.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var fullPath = Path.Combine(rootPath, string.Join(Path.DirectorySeparatorChar.ToString(), pathParts));

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            catch (Exception)
            {
                // Log error if necessary, but don't crash the app for a failed file deletion
            }
        }

    }

}