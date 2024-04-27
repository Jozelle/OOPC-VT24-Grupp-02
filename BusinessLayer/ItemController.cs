using CarService.Entities;
using DataLayer;

namespace CarService.BusinessLayer
{
    public class ItemController
    {
        public ItemController() { }
        public Item GetItem(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Items.Get(id);
            }
        }
    }
}
