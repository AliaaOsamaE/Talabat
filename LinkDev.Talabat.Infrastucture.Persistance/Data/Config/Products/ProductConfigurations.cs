using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Products
{
    internal class ProductConfigurations : BaseAuditableEntityConfigurations<Product, int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(product => product.Description) 
               .IsRequired();

            builder.Property(product => product.Price)
                .HasColumnType("decimal(9,2)");

            builder.HasOne(Product => Product.Brand)
                .WithMany()
                .HasForeignKey(product => product.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(Product => Product.Category)
             .WithMany()
             .HasForeignKey(product => product.CategoryId)
             .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
