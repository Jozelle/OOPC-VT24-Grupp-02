using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;

namespace CarService.DataLayer.Repositories
{
    public class UsedItemRepository : Repository<UsedItem>, IUsedItemRepository
    {
        public UsedItemRepository(CarServiceContext context) : base(context)
        {
        }

    }
}
