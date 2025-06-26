namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Products
{
    public class ProductBrandConfigurations : BaseAuditableEntityConfigurations<ProductBrand,int>
    {
        public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            base.Configure(builder);
            builder.Property(brand => brand.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
