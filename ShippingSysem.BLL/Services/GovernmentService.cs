using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.GovernmentDTOs;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
	public class GovernmentService
	{
		private readonly IGenericStatusRepository<Government> iGenericStatusRepository;
		public GovernmentService(IGenericStatusRepository<Government> iGenericStatusRepository)
		{
			this.iGenericStatusRepository = iGenericStatusRepository;
		}

		public async Task<ReadGovernmentDTO> GetGovernmentByID(int id)
		{
			var government = await iGenericStatusRepository.GetByIdAsync(id);
			if (government != null)
			{
				return new ReadGovernmentDTO()
				{
					Id = government.Id,
					Name = government.Name,
					IsDeleted = government.IsDeleted,
					Status = government.Status
				};
			}
			else
				return null;
		}
		public async Task<List<ReadGovernmentDTO>> GetGovernments()
		{
			var governments = await iGenericStatusRepository.GetAllAsync();
			if (governments != null)
			{
				var dtos = await governments
				.Select(b => new ReadGovernmentDTO
				{
					Id = b.Id,
					Name = b.Name,
					Status = b.Status
				}).ToListAsync();

				return dtos;
			}
			else
				return null;
		}

		public async Task<bool> ChangeStatus(int id)
		{
			var row = await iGenericStatusRepository.GetByIdAsync(id);
			var changedOrNot = false;
			if (row != null)
			{
				iGenericStatusRepository.ChangeStatus(row);
				await iGenericStatusRepository.SaveAsync();
				changedOrNot = true;
			}
			return changedOrNot;
		}
		public async Task<bool> DeleteGovernment(int id)
		{
			var row = await iGenericStatusRepository.GetByIdAsync(id);
			var deletedOrNot = false;
			if (row != null)
			{
				iGenericStatusRepository.Delete(row);
				await iGenericStatusRepository.SaveAsync();
				deletedOrNot = true;
			}
			return deletedOrNot;
		}
		public async Task<ReadGovernmentDTO> UpdateGovernment(int id, CreateGovernmentDTO governmentdto)
		{
			var government = await iGenericStatusRepository.GetByIdAsync(id);

			if (government != null)
			{
				//mapping from CreateGovernmentDTO to Government
				government.Name = governmentdto.Name;
				government.Status = governmentdto.Status;

				Government updatedGovernment = iGenericStatusRepository.Update(government).Result;
				await iGenericStatusRepository.SaveAsync();

				//mapping from Government to ReadGovernmentDTO
				return new ReadGovernmentDTO()
				{
					Id = updatedGovernment.Id,
					Name = updatedGovernment.Name,
					IsDeleted = updatedGovernment.IsDeleted,
					Status = updatedGovernment.Status
				};
			}
			else
				return null;
		}

		public async Task<ReadGovernmentDTO> AddGovernment(CreateGovernmentDTO governmentdto)
		{
			Government government = new()
			{
				//mapping from CreateGovernmentDTO to Government
				Name = governmentdto.Name,
				Status = governmentdto.Status
			};

			Government addedGovernment = iGenericStatusRepository.AddAsync(government).Result;
			await iGenericStatusRepository.SaveAsync();

			//mapping from Government to ReadGovernmentDTO
			return new ReadGovernmentDTO()
			{
				Id = addedGovernment.Id,
				Name = addedGovernment.Name,
				IsDeleted = addedGovernment.IsDeleted,
				Status = addedGovernment.Status
			};
		}

	}
}
