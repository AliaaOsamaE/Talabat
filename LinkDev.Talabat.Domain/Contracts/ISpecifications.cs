using System.Linq.Expressions;

namespace LinkDev.Talabat.Domain.Contracts
{
    public interface ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        // Property for filtering entities
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }

        // Property for including related entities
        public List<Expression<Func<TEntity, object>>> Includes { get; set; }

        public Expression<Func<TEntity, object>>? OrderBy { get; set; }

        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; }
    }
}
