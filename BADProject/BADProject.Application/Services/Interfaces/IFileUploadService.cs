using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BADProject.Application.Services.Interfaces
{
    public interface IFileUploadService
    {
        Task UploadFile(Stream input, string filepath);

    }
}
