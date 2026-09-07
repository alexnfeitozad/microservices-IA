using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string PictureFileName { get; private set; }
        public int CatalogTypeId { get; private set; }
        public int CatalogBrandId { get; private set; }


        public Product(int id, string name, decimal price, string description,
         string pictureFileName, int catalogTypeId, int catalogBrandId)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            PictureFileName = pictureFileName;
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
        }


    }
}