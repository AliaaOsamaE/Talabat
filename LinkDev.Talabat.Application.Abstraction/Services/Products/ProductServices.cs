using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Domain.Contracts.Persistence;
using LinkDev.Talabat.Domain.Entities.Products;
using LinkDev.Talabat.Domain.Specifications;
using LinkDev.Talabat.Domain.Specifications.Products;

namespace LinkDev.Talabat.Application.Abstraction.Services.Products
{
    internal class ProductServices : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync(string sort)
        {
             
            var specs = new ProductWithBrandAndCategorySpecifications(sort);

            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(specs);

            var productsToReturn = mapper.Map<IEnumerable<ProductToReturnDto>>(products);

            return productsToReturn;
        }
        public async Task<ProductToReturnDto> GetProductAsync(int id)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetWithSpecAsync(specs);
            if(product is null)  return null;

            var productToReturn = mapper.Map<ProductToReturnDto>(product);

            return productToReturn;
        }
        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            var brandsToReturn = mapper.Map<IEnumerable<BrandDto>> (brands);

            return brandsToReturn;
        }
        public async  Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

            var categoriesToReturn = mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesToReturn;
        }

    }
}
