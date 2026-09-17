using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistence.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PictureFileName)
                .HasMaxLength(500);

            builder.Property(p => p.CatalogTypeId)
            .IsRequired();
            builder.Property(p => p.CatalogBrandId)
            .IsRequired();

            builder.HasIndex(p => p.CatalogTypeId);
            builder.HasIndex(p => p.CatalogBrandId);
        }
    }
}