using Restoraun.Models;

namespace Restoraun.IServices
{
    public class ProductServies : BaseServiec, IProductServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public ProductServies(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDTO productDTO)
        {
           return await this.sendAsync<T>(new ApiRequest() { apiType = SD.ApiType.POST, Data = productDTO, Url = SD.ProductAPIBase + "/api/products" });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await this.sendAsync<T>(new ApiRequest() { apiType = SD.ApiType.DELETE, Url = SD.ProductAPIBase + "/api/products/" + productId });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.sendAsync<T>(new ApiRequest() { apiType = SD.ApiType.GET,  Url = SD.ProductAPIBase + "/api/products/" });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.sendAsync<T>(new ApiRequest() { apiType = SD.ApiType.GET, Url = SD.ProductAPIBase + "/api/products/" + productId });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDTO productDTO)
        {
            return await this.sendAsync<T>(new ApiRequest() { apiType = SD.ApiType.PUT, Data = productDTO, Url = SD.ProductAPIBase + "/api/products" });
        }
    }
}
