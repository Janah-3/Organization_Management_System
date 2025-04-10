using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.Services.AttachmentServices
{
    public interface IAttachmentService
    {
        public string? Upload(IFormFile file , string FloderName);
        bool Delete(string filePath);
    }
}
