

namespace LinkDev.Talabat.Infrastucture.Persistance.Data.Config.Base
{
    internal class BaseAuditableEntityConfigurations <TEntity,TKey> 
        : BaseEntityConfigurations <TEntity,TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
           
        }
    }
}
