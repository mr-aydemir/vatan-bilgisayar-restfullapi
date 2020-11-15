using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Services.Communication;

namespace VatanAPI.Domain.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> ListAsync();
        Task<ImageResponse> SaveAsync(Image image);
        Task<ImageResponse> UpdateAsync(int id, Image image);
        Task<ImageResponse> DeleteAsync(int id);
    }
}
