using LinkDev.Talabat.Application.Abstraction.Services.Products;
using LinkDev.Talabat.Domain.Contracts;

namespace LinkDev.Talabat.Application.Abstraction.Services
{
    internal class ServiceManager:IServiceManager
    {
        private readonly Lazy<ProductServices> _productService;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productService = new Lazy<ProductServices>(() => new ProductServices(_unitOfWork);
        }
        IProductService IServiceManager.ProductService => _productService.Value;
    }
}
