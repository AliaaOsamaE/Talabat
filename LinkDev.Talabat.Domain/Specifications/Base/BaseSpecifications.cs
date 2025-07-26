using LinkDev.Talabat.Domain.Contracts;
using System.Linq.Expressions;

namespace LinkDev.Talabat.Domain.Specifications.Base
{
    public class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity, object>>>;

        public BaseSpecifications()
        {
            Criteria = null;
        }

        public BaseSpecifications(TKey id)
        {
            Criteria = Entity => Entity.Id.Equals(id);
        }

        #region Helper Methods
        private protected virtual void AddIncludes()
        {
        }
        #endregion

    }
}
