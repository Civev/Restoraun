using AutoMapper;
using Mango.Servicies.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Servicies.ProductAPI
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContests _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContests db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);
            if (product.ProductId > 0) 
            {
                _db.Products.Update(product);
                
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<bool> DeletProduct(int productId)
        {
            try
            {
                var products = await _db.Products.FirstOrDefaultAsync(Id => productId == Id.ProductId);
                if(products == null) { return false; }
                _db.Products.Remove(products);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
           
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            var products = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            List<Product> products = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
