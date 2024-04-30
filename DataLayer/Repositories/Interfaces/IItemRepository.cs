using CarService.DataLayer.Repositories.Base;
using CarService.Entities;

namespace CarService.DataLayer.Repositories.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        IList<Item> GetNamesThatContains(string input);
    }
}
