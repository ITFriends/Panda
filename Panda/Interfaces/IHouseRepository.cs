using Panda.Models;

namespace Panda.Interfaces
{
    public interface IHouseRepository
    {
        Task CreateAsync(House house);

        Task<List<House>> GetAllAsync();

        Task<House> GetByIdAsync(string id);

        Task UpdateAsync(House house);

        Task DeleteAsync(House house);
    }
}
