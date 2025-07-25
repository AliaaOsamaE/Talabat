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
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
        {
            var products = await serviceManager.ProductService.GetProductsAsync();
            return Ok(products);
        }
        #endregion






    }
}
