using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.BranchDTOs;
using ShippingSysem.BLL.DTOs.EmployeeDTOS;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
	public class BranchService
	{
		private readonly IGenericStatusRepository<Branch> iGenericStatusRepository;
		private readonly IGenericStatusRepository<Government> iGenericStatusRepositoryGovernment;
		public BranchService(IGenericStatusRepository<Branch> iGenericStatusRepository, IGenericStatusRepository<Government> iGenericStatusRepositoryGovernment) {
			this.iGenericStatusRepository = iGenericStatusRepository;
			this.iGenericStatusRepositoryGovernment = iGenericStatusRepositoryGovernment;
		}

		public async Task<ReadBranchDTO> GetBranchByID(int id)
		{
			var branch = await iGenericStatusRepository.GetByIdAsync(id);
			if (branch != null)
			{
				return new ReadBranchDTO()
				{
					Id = branch.Id,
					Name = branch.Name,
					CreatedDate = branch.CreatedDate,
					GovernmentID = branch.GovernmentID,
					GovernmentName = iGenericStatusRepositoryGovernment.GetByIdAsync(branch.GovernmentID).Result.Name,
					IsDeleted = branch.IsDeleted,
					Status = branch.Status
				};
			}
			else
				return null;
		}
		public async Task<List<ReadBranchDTO>> GetBranches()
		{
			var branches = iGenericStatusRepository.GetAllAsync().Result.ToList();
			if (branches != null)
			{
				var dtos = branches
				.Select(b =>
				new ReadBranchDTO
				{
					Id = b.Id,
					Name = b.Name,
					CreatedDate = b.CreatedDate,
					GovernmentID = b.GovernmentID,
					GovernmentName = iGenericStatusRepositoryGovernment.GetByIdAsync(b.GovernmentID).Result.Name,
					Status = b.Status
				}).ToList();

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
		public async Task<bool> DeleteBranch(int id)
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
		public async Task<ReadBranchDTO> UpdateBranch(int id, CreateBranchDTO branchdto)
		{
			var branch = await iGenericStatusRepository.GetByIdAsync(id);

			if (branch != null)
			{
				//mapping from CreateBranchDTO to Branch
				branch.Name = branchdto.Name;
				branch.GovernmentID = branchdto.GovernmentID;

				Branch updatedBranch = iGenericStatusRepository.Update(branch).Result;
				await iGenericStatusRepository.SaveAsync();

				//mapping from Branch to ReadBranchDTO
				return new ReadBranchDTO()
				{
					Id = updatedBranch.Id,
					Name = updatedBranch.Name,
					CreatedDate = updatedBranch.CreatedDate,
					GovernmentID = updatedBranch.GovernmentID,
					GovernmentName = iGenericStatusRepositoryGovernment.GetByIdAsync(updatedBranch.GovernmentID).Result.Name,
					IsDeleted = updatedBranch.IsDeleted,
					Status = updatedBranch.Status
				};
			}
			else
				return null;
		}

		public async Task<ReadBranchDTO> AddBranch(CreateBranchDTO branchdto)
		{
			Branch branch = new()
			{
				//mapping from CreateBranchDTO to Branch
				Name = branchdto.Name,
				GovernmentID = branchdto.GovernmentID,
				Status = branchdto.Status
			};

			Branch addedBranch = iGenericStatusRepository.AddAsync(branch).Result;
			await iGenericStatusRepository.SaveAsync();

			//mapping from Branch to ReadBranchDTO
			return new ReadBranchDTO()
			{
				Id = addedBranch.Id,
				Name = addedBranch.Name,
				CreatedDate = addedBranch.CreatedDate,
				GovernmentID = addedBranch.GovernmentID,
				GovernmentName = iGenericStatusRepositoryGovernment.GetByIdAsync(addedBranch.GovernmentID).Result.Name,
				IsDeleted = addedBranch.IsDeleted,
				Status = addedBranch.Status
			};
		}

	}
}
