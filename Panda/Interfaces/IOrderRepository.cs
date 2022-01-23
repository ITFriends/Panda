using Panda.Models;

namespace Panda.Interfaces
{
    public interface IOrderRepository
    {
        //CRUD - Create, Read, Update, Delete

        Task CreateAsync(Order order);

        Task<List<Order>> GetAllAsync();

        Task UpdateAsync(Order order);

        Task DeleteAsync(Order order);
    }
}
