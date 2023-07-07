using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetById(int id);
        void updateProduct(int id, ProductDto productDto);
        void deleteProduct(int id);
        void createProduct(ProductDto product);
        void savechange();
    }
}