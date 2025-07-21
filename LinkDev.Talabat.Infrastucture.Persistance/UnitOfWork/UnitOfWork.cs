using LinkDev.Talabat.Infrastructure.Persistence.Data;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories;

namespace LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly StoreContext _storeContext;
        private readonly Lazy<IGenericRepository<Product, int>> _productRepository;
        private readonly Lazy<IGenericRepository<ProductBrand, int>> _brandRepository;
        private readonly Lazy<IGenericRepository<ProductCategory, int>> _categoryRepository;
        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;

            _productRepository = new Lazy<IGenericRepository<Product, int>>(() => new GenericRepository<Product, int>(_storeContext));

            _brandRepository = new Lazy<IGenericRepository<ProductBrand, int>>(() => new GenericRepository<ProductBrand, int>(_storeContext));

            _categoryRepository = new Lazy<IGenericRepository<ProductCategory, int>>(() => new GenericRepository<ProductCategory, int>(_storeContext));
        } 
        IGenericRepository<Product, int> IUnitOfWork.ProductRepository => _productRepository.Value;
        IGenericRepository<ProductBrand, int> IUnitOfWork.BrandRepository => _brandRepository.Value;
        IGenericRepository<ProductCategory, int> IUnitOfWork.CateoryRepository => _categoryRepository.Value;

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
