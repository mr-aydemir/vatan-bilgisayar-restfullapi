using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Services;
using VatanAPI.Domain.Repositories;
using VatanAPI.Persistence.Repositories;
using VatanAPI.Domain.Services.Communication;

namespace VatanAPI.Domain.Services
{
    public interface ISepetService
    {
        Task<IEnumerable<Sepet>> ListAsync();
        Task<SepetResponse> SaveAsync(Sepet sepet);
        Task<SepetResponse> UpdateAsync(int id, Sepet sepet);
        Task<SepetResponse> DeleteAsync(int id);
        Task<IEnumerable<Sepet>> FindByEmailAsync(string email);
    }
}

