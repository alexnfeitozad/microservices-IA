namespace Catalog.Application.Products.CreateProduct
{
    public interface ICreateProductService
    {
        CreateProductResponse Execute(CreateProductRequest request);
    }
}