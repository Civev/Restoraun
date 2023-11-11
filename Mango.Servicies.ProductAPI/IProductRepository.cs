using Mango.Servicies.ProductAPI.Models;

namespace Mango.Servicies.ProductAPI
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int productId);
        Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO);
        Task<bool> DeletProduct(int productDTO);
    }
}
