using LinkDev.Talabat.Domain.Entities.Products;
using LinkDev.Talabat.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace LinkDev.Talabat.Domain.Specifications.Products
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product,int>
    {

        public ProductWithBrandAndCategorySpecifications(string sort)
            : base()
        {
            AddIncludes();
            AddSorting(sort);
           
        }

        public ProductWithBrandAndCategorySpecifications(int id)
          : base(id)
        {
            AddIncludes();
        }

        #region Helper Methods

        private protected override void AddSorting(string sort)
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(P => P.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(P => P.Price);
                    break;
                default:
                    AddOrderBy(P => P.Name);
                    break;

            }
        }

        private protected override void AddIncludes()
        {
            base.AddIncludes();
            Includes.Add(P => P.Brand!);
            Includes.Add(P => P.Category!);
        }


        private protected override void AddOrderBy(Expression<Func<Product, object>> orderBy)
        {
           OrderBy = orderBy;
        }

        private protected override void AddOrderByDesc(Expression<Func<Product, object>> orderByDesc)
        {
            OrderByDesc = orderByDesc;
        }
        #endregion
    }
}
