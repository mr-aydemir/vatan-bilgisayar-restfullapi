using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;

namespace VatanAPI.Domain.Repositories
{
    public interface ISiparisRepository
    {
        Task<IEnumerable<Siparis>> ListAsync();
        Task AddAsync(Siparis siparis);
        Task<Siparis> FindByIdAsync(int id);
        void Update(Siparis siparis);
        void Remove(Siparis siparis);
        Task<IEnumerable<Siparis>> FindByEmailAsync(string email);
    }
}
