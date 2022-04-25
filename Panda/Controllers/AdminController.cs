using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panda.Interfaces;
using Panda.Models;
using Panda.Models.Enums;
using Panda.Utilities;

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

        [HttpPost("house/upload")]
        public async Task<object> UploadPicture([FromForm] IFormFile file)
        {
            if(file == null)
            {
                return new
                {
                    Status = "No file provided"
                };
            }

            // is not fully secure, please add additional validation of filename
            var path = Path.Combine(Settings.UploadDir, file.FileName);
            try
            {
                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }
            catch(Exception ex) 
            {
                return new { Status = ex.Message };
            }

            return new
            {
                Status = "File successfully uploaded",
                FileName = file.FileName
            };
        }
    }
}
