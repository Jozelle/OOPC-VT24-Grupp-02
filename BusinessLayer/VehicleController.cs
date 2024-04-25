using CarService.Entities;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.BusinessLayer
{
    public class VehicleController
    {
        public VehicleController() { }
        public Vehicle GetVehicle(string regNo)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return (Vehicle)uow.Vehicles.Get(x => x.RegistrationNumber == regNo);
                //return uow.Vehicles.GetByRegistrationNo(regNo);
            }
        }
    }
}
