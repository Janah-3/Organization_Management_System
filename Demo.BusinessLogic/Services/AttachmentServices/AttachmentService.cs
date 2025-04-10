using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.Services.AttachmentServices
{
    public class AttachmentService : IAttachmentService
    {
        List<string> _allowedExtensions = new List<string> { ".jpg", ".png", ".pdf", ".docx" };
       const int maxSize = 2097152; // 2MB

        public string? Upload(IFormFile file, string FloderName)
        {
            //1.check extension
            var extention = Path.GetExtension(file.Name);
            if(!_allowedExtensions.Contains(extention)) return null;

            //2.check file size
            if (file.Length > maxSize || file.Length == null) return null;

            //3. get located folder path
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FloderName);

            //4. make attachment name uniqe __GUID
            var fileNmae = $"{Guid.NewGuid()}{file.FileName}";

            //5. get file path
            string filePath = Path.Combine(folderPath, fileNmae);

            //6. create file stream to copy file (unmanaged)
            using var fileStream = new FileStream(filePath, FileMode.Create) ;

            //7. use stream to copy file

            file.CopyTo(fileStream);

            //8. return file name to store in db

            return fileNmae;

        }

        public bool Delete(string filePath)
        {
            //1. get file path

            //2. check if file exists
            if (File.Exists(filePath)) { return false; }
            else
            {
                File.Delete(filePath);
                return true;
            }

        }
    }
}
