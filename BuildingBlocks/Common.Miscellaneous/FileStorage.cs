using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Miscellaneous
{
    public static class FileStorage
    {
        public async static Task<string> SaveFileAsync(IFormFile file, string fileStoragePath, string productCode,string folderType= "images")
        {

            var folderPath = Path.Combine(fileStoragePath, folderType);
            string path = Path.Combine(folderPath, productCode);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
