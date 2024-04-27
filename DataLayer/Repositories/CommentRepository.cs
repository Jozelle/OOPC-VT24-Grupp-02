using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;

namespace CarService.DataLayer.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(CarServiceContext context) : base(context)
        {
        }
    }
}
