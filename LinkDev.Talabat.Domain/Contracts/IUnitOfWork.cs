using LinkDev.Talabat.Domain.Entities.Products;

namespace LinkDev.Talabat.Domain.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<Product ,int>  ProductRepository { get; }
        public IGenericRepository<ProductBrand, int> BrandRepository { get;}
        public IGenericRepository<ProductCategory, int> CateoryRepository { get; }

        Task<int> CompleteAsync(); 
    }
}
