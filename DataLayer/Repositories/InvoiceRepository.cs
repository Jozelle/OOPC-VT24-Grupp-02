using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;

namespace CarService.DataLayer.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(CarServiceContext context) : base(context)
        {
        }
    }
}
