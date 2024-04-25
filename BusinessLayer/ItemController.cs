using CarService.Entities;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
