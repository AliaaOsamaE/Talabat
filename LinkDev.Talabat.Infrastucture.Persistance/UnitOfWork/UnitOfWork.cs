using LinkDev.Talabat.Infrastructure.Persistence.Data;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories;
using System.Collections.Concurrent;

namespace LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly StoreContext _storeContext;
        //private readonly Lazy<IGenericRepository<Product, int>> _productRepository;
        //private readonly Lazy<IGenericRepository<ProductBrand, int>> _brandRepository;
        //private readonly Lazy<IGenericRepository<ProductCategory, int>> _categoryRepository;

        private readonly ConcurrentDictionary<string, object> _repositories;
        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;

            //_productRepository = new Lazy<IGenericRepository<Product, int>>(() => new GenericRepository<Product, int>(_storeContext));

            //_brandRepository = new Lazy<IGenericRepository<ProductBrand, int>>(() => new GenericRepository<ProductBrand, int>(_storeContext));

            //_categoryRepository = new Lazy<IGenericRepository<ProductCategory, int>>(() => new GenericRepository<ProductCategory, int>(_storeContext));

            _repositories = new ConcurrentDictionary<string, object>();
        } 
        //IGenericRepository<Product, int> IUnitOfWork.ProductRepository => _productRepository.Value;
        //IGenericRepository<ProductBrand, int> IUnitOfWork.BrandRepository => _brandRepository.Value;
        //IGenericRepository<ProductCategory, int> IUnitOfWork.CateoryRepository => _categoryRepository.Value;

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            // return new GenericRepository<TEntity, TKey>(_storeContext);


            //var typeNAme = typeof(TEntity).Name;
            //if(_repositories.ContainsKey(typeNAme)) return (IGenericRepository<TEntity, TKey>)_repositories[typeNAme];
            //var repository = new GenericRepository<TEntity, TKey>(_storeContext);
            //_repositories.Add(typeNAme, repository);

            //return repository;

            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(
                                   typeof(TEntity).Name,
                                   _ => new GenericRepository<TEntity, TKey>(_storeContext)
                               );
        }

        async Task<int> IUnitOfWork.CompleteAsync()
        {
            return await _storeContext.SaveChangesAsync();
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
             await _storeContext.DisposeAsync();
        }
    }

       
}
