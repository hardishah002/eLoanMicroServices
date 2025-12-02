using Document.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Infrastructure.Repositories
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _uploadPath;

        public FileStorageService()
        {
            _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }
        }

        public async Task<string> SaveAsync(Stream fileStream, string fileName)
        {
            var filePath = Path.Combine(_uploadPath, fileName);

            using (var outputStream = new FileStream(filePath, FileMode.Create))
            { 
                await fileStream.CopyToAsync(outputStream);
            }

            return filePath;
        }
    }
}
