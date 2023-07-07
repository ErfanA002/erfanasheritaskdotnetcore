using Aplication.Services.interfaces;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {

            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> getListProduct()
        {
            var products = _productService.getProducts();
            return Ok(products);
        }

        [HttpPost("createProduct")]
        public void CreateProduct(ProductDto productDto)
        {
            _productService.createProduct(productDto);
        }

        [HttpPut("update/{id}")]
        public void PutProduct(int id,ProductDto productDto)
        {
            _productService.updateProduct(id, productDto);
        }

        [HttpDelete("deleteproduct/{id}")]
        public void delProduct(int id)
        {
            _productService.deleteProduct(id);
        }

        [HttpGet("getbyid/{id}")]
        public Product GetProductById(int id)
        {
            return _productService.getProductById(id);
        }
    }
}