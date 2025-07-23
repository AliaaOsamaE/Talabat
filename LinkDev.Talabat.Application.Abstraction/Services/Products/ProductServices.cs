using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Domain.Contracts;
using LinkDev.Talabat.Domain.Entities.Products;

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
        public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync()
        {
            
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();

            var productsToReturn = products.Select(p => new ProductToReturnDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                PictureUrl = p.PictureUrl,
                Price = p.Price,
                BrandId = p.BrandId,
                Brand = p.Brand?.Name,  
                CategoryId = p.CategoryId,
                Category = p.Category?.Name,
            });

            return productsToReturn;
        }
        public async Task<ProductToReturnDto> GetProductAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
            if(product is null)  return null;

            var productToReturn =  new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                BrandId = product.BrandId,
                Brand = product.Brand?.Name,
                CategoryId = product.CategoryId,
                Category = product.Category?.Name
            };

            return productToReturn;
        }
        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            var brandsToReturn  = brands.Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name
            });

            return brandsToReturn;
        }
        public async  Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

            var categoriesToReturn  = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });

            return categoriesToReturn;
        }

    }
}
