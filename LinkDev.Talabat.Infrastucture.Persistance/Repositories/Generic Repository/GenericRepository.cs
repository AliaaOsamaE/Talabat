using LinkDev.Talabat.Domain.Contracts.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence.Data;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories.Generic_Repository;

namespace LinkDev.Talabat.Infrastructure.Persistence.Repositories
{
    internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly StoreContext _storeContext;
        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
        {
            if(typeof(TEntity) == typeof(Product))
            {
                return withTracking ?
                    (IEnumerable<TEntity>)await _storeContext.Set<Product>().Include(P => P.Brand).Include(P => P.Category).ToListAsync() :
                    (IEnumerable<TEntity>)await _storeContext.Set<Product>().Include(P => P.Brand).Include(P => P.Category).AsNoTracking().ToListAsync();
            }

            return  withTracking?
            await _storeContext.Set<TEntity>().ToListAsync() : 
            await _storeContext.Set<TEntity>().AsNoTracking().ToListAsync();

            /*
            {
               if (withTracking) return await _storeContext.Set<TEntity>().ToListAsync();
               return await _storeContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
           */
        }


        public async Task<TEntity?> GetAsync(TKey id)
              =>  await _storeContext.Set<TEntity>().FindAsync(id);
        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> spec, bool withTracking = false)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<TEntity?> GetWithSpecAsync(ISpecifications<TEntity, TKey> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();

        }
        public async Task AddAsync(TEntity entity)
             => await _storeContext.Set<TEntity>().AddAsync(entity);

        public void  Update(TEntity entity)
             =>  _storeContext.Set<TEntity>().Update(entity);

        public void  Delete(TEntity entity)
              =>  _storeContext.Set<TEntity>().Remove(entity);

   


        #region Helpers
        private IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity, TKey> spec)
        {
            return SpecificationsEvaluator<TEntity, TKey>.GetQuery(_storeContext.Set<TEntity>(), spec);
        }
        #endregion
    }
}
