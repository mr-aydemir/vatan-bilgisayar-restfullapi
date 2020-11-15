using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Services;
using VatanAPI.Domain.Repositories;
using VatanAPI.Persistence.Repositories;
using VatanAPI.Domain.Services.Communication;
using VatanAPI.Core.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace VatanAPI.Domain.Services
{
	public class SepetService : ISepetService
	{
		private readonly IUserRepository _usersRepository;
		private readonly ISepetRepository _sepetRepository;
		private readonly IProductRepository _productRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMemoryCache _cache;

		public SepetService(ISepetRepository sepetRepository, IUserRepository usersRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
		{
			_usersRepository = usersRepository;
			_productRepository = productRepository;
			_sepetRepository = sepetRepository;
			_unitOfWork = unitOfWork;
			_cache = cache;
		}

		public async Task<SepetResponse> DeleteAsync(int id)
		{
			var existingSepet = await _sepetRepository.FindByIdAsync(id);

			if (existingSepet == null)
				return new SepetResponse("Sepet not found.");

			try
			{
				await _unitOfWork.CompleteAsync();

				return new SepetResponse(existingSepet);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SepetResponse($"An error occurred when deleting the sepet: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Sepet>> ListAsync()
		{
			return await _sepetRepository.ListAsync();
		}

		public async Task<SepetResponse> SaveAsync(Sepet sepet)
		{
			try
			{
				await _sepetRepository.AddAsync(sepet);
				await _unitOfWork.CompleteAsync();

				return new SepetResponse(sepet);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SepetResponse($"An error occurred when saving the sepet: {ex.Message}");
			}
		}

		public async Task<SepetResponse> UpdateAsync(int id, Sepet sepet)
		{

			var existingSepet = await _sepetRepository.FindByIdAsync(id);

			if (existingSepet == null)
				return new SepetResponse("Sepet not found.");

			existingSepet.SepetId = sepet.SepetId;

			try
			{
				_sepetRepository.Update(existingSepet);
				await _unitOfWork.CompleteAsync();

				return new SepetResponse(existingSepet);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SepetResponse($"An error occurred when updating the sepet: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Sepet>> FindByEmailAsync(string email)
		{
			return await _sepetRepository.FindByEmailAsync(email);
		}

	}
}

