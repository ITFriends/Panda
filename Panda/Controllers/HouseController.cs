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

        [HttpGet]
        public async Task<List<House>> Get()
        {
            return await _houseRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task Post()
        {
            var rand = new Random();
            for (var i = 0; i < 5; i++)
            {
                var house = new House
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = rand.Next(20),
                    Price = rand.Next(15),
                    Family = Family.Cat,
                    SizeHeight = 1,
                    SizeLength = 1,
                    SizeWidth = 0.5,
                    Status = HouseStatus.Free,
                    Picture = "CatBestHouse.jpg"
                };

                await _houseRepository.CreateAsync(house);
            }
        }

    }
}
