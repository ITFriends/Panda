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
        public async Task CreateHouse()
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                var house = new House
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = rand.Next(20),
                    Price = rand.Next(15),
                    Family = Family.Dog,
                    SizeHeight = 2,
                    SizeLength = 2,
                    SizeWidth = 1,
                    Status = HouseStatus.Free,
                    Picture = "House.jpg"
                };

                await _houseRepository.CreateAsync(house);
            }
        }
    }
}
