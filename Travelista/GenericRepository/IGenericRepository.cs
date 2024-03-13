using System.Linq.Expressions;

namespace Travelista.GenericRepository
{
    public interface IGenericRepository<TEntity>
    {
        public IQueryable<TEntity> GetAll();
        public IQueryable<TEntity> GetAll(Func<TEntity, bool> Expression);

        public IQueryable<TEntity> GetAllWithInclude(List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includes);

        public TEntity Create(TEntity entity);
        public bool Delete(TEntity entity);
        public bool Update(TEntity entity);
        public TEntity GetById(int id);
        public bool AddRange(List<TEntity> entities);
	}
}
