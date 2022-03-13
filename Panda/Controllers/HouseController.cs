using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panda.Interfaces;
using Panda.Models;
using Panda.Models.Enums;

namespace Panda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private IHouseRepository _houseRepository;

        public HouseController(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        [HttpGet] //api/house
        public async Task<List<House>> Index()
        {
            return await _houseRepository.GetAllAsync();
        }

        [HttpGet("{id}")] //api/house/id
        public async Task<House> GetHouse(string id)
        
        {
            return await _houseRepository.GetByIdAsync(id);
        }
    }
}
