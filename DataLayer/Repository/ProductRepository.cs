using AutoMapper;
using DataLayer.DbContext;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
namespace DataLayer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private AplicationDbContext _context;
        public IMapper _mapper;
        public ProductRepository(AplicationDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void createProduct(ProductDto product)
        {
            var newproduct = _mapper.Map<Product>(product);
            _context.Products.Add(newproduct);
        }

        public void deleteProduct(int id)
        {
            var getbyid = _context.Products.SingleOrDefault(x => x.Id == id);
            _context.Products.Remove(getbyid);
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void savechange()
        {
            _context.SaveChanges();
        }

        public void updateProduct(int id,ProductDto productDto)
        {
            var finbyid = _context.Products.SingleOrDefault(p => p.Id == id);
            finbyid.Name = productDto.Name;
            finbyid.ManufactureEmail = productDto.ManufactureEmail;
            finbyid.ManufacturePhone = productDto.ManufacturePhone;
            _context.Products.Update(finbyid);
        }
    }
}