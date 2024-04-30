using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;

namespace CarService.DataLayer.Repositories
{
    internal class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(CarServiceContext context) : base(context)
        {
        }

        public IList<Item> GetNamesThatContains(string input)
        {
            return Table.Where(x => x.Description.Contains(input)).ToList();
        }
    }
}
