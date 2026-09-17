using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Catalog.IntegrationTests.Persistence
{
    public class CatalogDbContextModelTests
    {
        [Fact]
        public void Model_ShouldApplyEntityConfigurations()
        {
            var options = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseSqlServer("Server=dummy;Database=dummy;Trusted_Connection=True;")
                .Options;

            using var context = new CatalogDbContext(options);
            var model = context.Model;

            // Product Entity Configuration
            var productEntity = model.FindEntityType(typeof(Product));
            Assert.NotNull(productEntity);
            Assert.Equal("Products", productEntity.GetTableName());

            var nameProperty = productEntity.FindProperty(nameof(Product.Name));
            Assert.NotNull(nameProperty);
            Assert.Equal(100, nameProperty.GetMaxLength());
            Assert.False(nameProperty.IsNullable);

            var priceProperty = productEntity.FindProperty(nameof(Product.Price));
            Assert.NotNull(priceProperty);
            Assert.Equal("decimal(18,2)", priceProperty.GetColumnType());

            // Brand Entity Configuration
            var brandEntity = model.FindEntityType(typeof(Brand));
            Assert.NotNull(brandEntity);
            Assert.Equal("Brands", brandEntity.GetTableName());

            var brandNameProperty = brandEntity.FindProperty(nameof(Brand.Name));
            Assert.NotNull(brandNameProperty);
            Assert.Equal(100, brandNameProperty.GetMaxLength());

            // CatalogType Entity Configuration
            var typeEntity = model.FindEntityType(typeof(CatalogType));
            Assert.NotNull(typeEntity);
            Assert.Equal("CatalogTypes", typeEntity.GetTableName());

            var typeNameProperty = typeEntity.FindProperty(nameof(CatalogType.Name));
            Assert.NotNull(typeNameProperty);
            Assert.Equal(100, typeNameProperty.GetMaxLength());
        }
    }
}

