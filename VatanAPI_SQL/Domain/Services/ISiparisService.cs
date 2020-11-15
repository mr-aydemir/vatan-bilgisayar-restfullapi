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
    public interface ISiparisService
    {
        Task<IEnumerable<Siparis>> ListAsync();
        Task<SiparisResponse> SaveAsync(Siparis siparis);
        Task<SiparisResponse> UpdateAsync(int id, Siparis siparis);
        Task<SiparisResponse> DeleteAsync(int id);
        Task<IEnumerable<Siparis>> FindByEmailAsync(string email);
    }
}

