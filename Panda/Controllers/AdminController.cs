using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panda.Interfaces;
using Panda.Models;
using Panda.Models.Enums;

namespace Panda.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IHouseRepository _houseRepository;

        public AdminController(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        [HttpGet("houses")]
        public async Task<List<House>> ListHouses()
        {
            return await _houseRepository.GetAllAsync();
        }

        [HttpPost("house/create")]
        public async Task<string> CreateHouse([FromForm] IFormCollection formData)
        {

            var house = new House
            {
                Number = int.Parse(formData["number"]),
                Price = double.Parse(formData["price"])
            };

            await _houseRepository.CreateAsync(house);

            return "Ok";
        }
    }
}
