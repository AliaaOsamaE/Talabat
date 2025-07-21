using LinkDev.Talabat.Domain.Contracts;

namespace LinkDev.Talabat.Application.Abstraction.Services.Products
{
    internal class ProductServices : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
