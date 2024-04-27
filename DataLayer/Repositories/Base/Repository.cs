using Microsoft.EntityFrameworkCore;

namespace CarService.DataLayer.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get; }
        protected DbSet<TEntity> Table { get; }

        public Repository(DbContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        //CRUD operations

        //Create
        public void Add(TEntity entity)
        {
            Table.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Table.AddRange(entities);
        }

        //Read
        public TEntity Get(int id)
        {
            return Table.Find(id);
        }
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return Table.Where(predicate);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Table;
        }
        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        //Update
        public virtual void Update(TEntity entity) => Table.Update(entity);
        public virtual TEntity Update(TEntity oldEntity, TEntity newEntity)
        {
            Context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            Table.Update(oldEntity);
            return oldEntity;
        }
        public virtual void UpdateRange(IEnumerable<TEntity> entities) => Table.UpdateRange(entities);


        //Delete
        public void Remove(TEntity entity)
        {
            Table.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
        }
    }
}
