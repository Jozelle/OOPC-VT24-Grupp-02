using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataLayer.Repositories
{
    public class MechanicCommentRepository : Repository<Comment>, IMechanicCommentRepository
    {
        public MechanicCommentRepository(CarServiceContext context) : base(context)
        {
        }
    }
}
