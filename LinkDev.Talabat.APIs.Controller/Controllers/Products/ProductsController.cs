using LinkDev.Talabat.APIs.Controllers.Base;
using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs.Controller.Controllers.Products
{
    public class ProductsController : BaseApiController
    {
        private readonly IServiceManager serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }


        #region GetProducts
        [HttpGet] //Get: /api/products
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts(string? sort,int?brandId,int?categoryId)
        {
            var products = await serviceManager.ProductService.GetProductsAsync(sort,brandId,categoryId);
            return Ok(products);
        }
        #endregion

        #region GetProductById
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await serviceManager.ProductService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound(new { statusCode = 404, message = "not found" });
            }
            return Ok(product);
        }
        #endregion

        #region GetBrands

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
        {
            var brands = await serviceManager.ProductService.GetBrandsAsync();

            return Ok(brands);
        }
        #endregion

        #region GetCategories

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await serviceManager.ProductService.GetCategoriesAsync();

            return Ok(categories);
        }

        #endregion



    }
}
