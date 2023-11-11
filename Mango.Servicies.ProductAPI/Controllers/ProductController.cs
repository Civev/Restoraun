using Mango.Servicies.ProductAPI.Models;
using Mango.Servicies.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Servicies.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ResponseDTO _responseDTO;
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _responseDTO = new ResponseDTO();
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                _responseDTO.Result = await _productRepository.GetProducts();

            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMassages = new List<string> { ex.Message };

            }
            return _responseDTO;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetById(int id)
        {
            try
            {
                _responseDTO.Result = await _productRepository.GetProductById(id);

            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMassages = new List<string> { ex.Message };

            }
            return _responseDTO;
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccessful =   await _productRepository.DeletProduct(id);
                _responseDTO.Result = isSuccessful;


            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMassages = new List<string> { ex.Message };

            }
            return _responseDTO;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDTO product)
        {
            try
            {
                _responseDTO.Result = await _productRepository.CreateUpdateProduct(product);

            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMassages = new List<string> { ex.Message };

            }
            return _responseDTO;
        }
        [HttpPut]
        public async Task<object> Put([FromBody] ProductDTO product)
        {
            try
            {
                _responseDTO.Result = await _productRepository.CreateUpdateProduct(product);

            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMassages = new List<string> { ex.Message };

            }
            return _responseDTO;
        }

    }

   



}
