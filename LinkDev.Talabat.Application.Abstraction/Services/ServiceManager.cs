using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Services.Products;
using LinkDev.Talabat.Domain.Contracts;

namespace LinkDev.Talabat.Application.Abstraction.Services
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<ProductServices> _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productService = new Lazy<ProductServices>(() => new ProductServices(_unitOfWork,_mapper));
        }
        IProductService IServiceManager.ProductService => _productService.Value;
    }
}
