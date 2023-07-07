using Domain.Dtos;
using Domain.Entities;

namespace Aplication.Services.interfaces
{
    public interface IProductService
    {
        List<Product> getProducts();
        Product getProductById(int id);
        void updateProduct(int id, ProductDto productDto);
        void deleteProduct(int id);
        void createProduct(ProductDto product);
    }
}