
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistence.Configurations
{
    public class CatalogTypeConfigurations : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogTypes");
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Id)
                .ValueGeneratedNever();

            builder.Property(ct => ct.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}