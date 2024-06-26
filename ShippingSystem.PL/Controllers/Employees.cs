using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.Create;
using ShippingSysem.BLL.Services;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.PL.DTOs.Read;


namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employees : ControllerBase
    {
        private readonly IGenericRepository<Account> genRepo;
        private readonly EmployeeService empService;

        public Employees(IGenericRepository<Account> genRepo, EmployeeService EmpService)
        {
            this.genRepo = genRepo;
            empService = EmpService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var account = await empService.GetAll();
            return Ok(account);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmp(CreateEmployeeDTO EmpDto)
        {
            var account = await empService.AddEmp(EmpDto);
            return Ok(account);
        }
    }
}
