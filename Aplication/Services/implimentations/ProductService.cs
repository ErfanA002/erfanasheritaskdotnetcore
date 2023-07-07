using Aplication.Services.interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.Services.implimentations
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void createProduct(ProductDto product)
        {
            _productRepository.createProduct(product);
            _productRepository.savechange();
        }

        public void deleteProduct(int id)
        {
            _productRepository.deleteProduct(id);
            _productRepository.savechange();
        }

        public Product getProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> getProducts()
        {
            return _productRepository.GetProducts();
        }

        public void updateProduct(int id, ProductDto productDto)
        {
            _productRepository.updateProduct(id, productDto);
            _productRepository.savechange();
        }
    }
}