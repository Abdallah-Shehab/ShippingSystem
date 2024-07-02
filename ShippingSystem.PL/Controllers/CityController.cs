using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.BranchDTOs;
using ShippingSysem.BLL.DTOs.CityDTOS;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService cityService;

        public CityController(CityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpPost]
        public async Task<ActionResult<CityReadDTO>> createCity(CityCreateDTO cityDto)
        {
            var city = await cityService.AddCity(cityDto);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
       
        [HttpGet]
        public async Task<ActionResult<CityReadDTO>> GetAll()
        {
            return Ok(await cityService.getAllCities());
        }

        [HttpGet("ByGovernment")]
        public async Task<ActionResult<CityReadDTO>> GetCitiesByGovernment(int id)
        {
            return Ok(await cityService.GetCitiesWithGovernment(id));
        }


        //Not Working
        //[HttpGet("withNavigation")]
        //public async Task<ActionResult<CityReadDTO>> GetCities(int id)
        //{
        //    return Ok(await cityService.GetCitiesWithGovernments(id));
        //}



        [HttpGet("changeStatus/{id}")]
        public async Task<ActionResult<CityReadDTO>> ChangeStatus(int id)
        {
            return Ok( await cityService.changeStatus(id));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CityReadDTO>> Delete(int id)
        {
            return Ok(await cityService.Delete(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityCreateDTO cityCreateDTO)
        {
            var city = await cityService.UpdateCity(id, cityCreateDTO);
            if (city != null)
            {
                return Ok(city);
            }
            else
                return NotFound();
        }
        [HttpGet("pagination")]
        public async Task<IActionResult> get_City_pagination(int page,int pageSize) {
        
        var cities = await cityService.getCityWithPagination(page,pageSize);
            return Ok(cities);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityByID(int id)
        {
            var city = await cityService.GetCityByID(id);
            if (city != null)
            {
                return Ok(city);
            }
            else
                return NotFound();
        }
    }
}
