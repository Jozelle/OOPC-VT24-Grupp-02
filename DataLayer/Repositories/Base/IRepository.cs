namespace CarService.DataLayer.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Create
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Read
        TEntity Get(int id);
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();

        //Update??? 
        void Update(TEntity entity);
        TEntity Update(TEntity oldEntity, TEntity newEntity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //Delete
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
