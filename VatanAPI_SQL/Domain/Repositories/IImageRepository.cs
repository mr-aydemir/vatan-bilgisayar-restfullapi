using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;

namespace VatanAPI.Domain.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> ListAsync();
        Task AddAsync(Image image);
        Task<Image> FindByIdAsync(int id);
        void Update(Image image);
        void Remove(Image image);
    }
}
