using BADProject.Application.Services.Interfaces;

namespace BADProject.Application.Services
{
    public class FileUploadService : IFileUploadService
    {
        public async Task UploadFile(Stream input, string filepath)
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
            {
                input.CopyTo(fileStream);
            }
        }
    }
}
