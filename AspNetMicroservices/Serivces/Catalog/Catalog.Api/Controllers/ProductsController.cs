using Catalog.Entities.ApiEntities.Product.Request;
using Catalog.Entities.ApiEntities.Product.Response;
using Catalog.Entities.GenericModels;
using Catalog.Entities.Interfaces.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductEnquiryService _productEnquiryService;
        private readonly IProductOperationalService _productOperationalService;
        public ProductsController(IProductEnquiryService productEnquiryService,
            IProductOperationalService productOperationalService)
        {
            this._productEnquiryService = productEnquiryService;
            this._productOperationalService = productOperationalService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductsResponse), 200)]
        [ProducesResponseType(typeof(GenericResponse), 404)]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productEnquiryService.GetProducts();
            if(products.Products.Count == 0)
                return NotFound(products);
            return Ok(products);
        }

        [HttpGet, Route("{code}")]
        [ProducesResponseType(typeof (ProductsResponse), 200)]
        public async Task<IActionResult> GetProduct(string code)
        {
            var products = await _productEnquiryService.GetProductByCode(code);
            if (products.Product == null)
                return NotFound(products);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse) , 201)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProductRequest)
        {
            var createProduct = await _productOperationalService.CreateProduct(createProductRequest);   
            if(createProduct.ResponseCode != CustomStatusCodes.Created)
                return BadRequest(createProduct);
            return Created("", createProduct);
        }

        [HttpDelete, Route("{code}")]
        public async Task<IActionResult> DeleteProduct(string code)
        {
            var deleteProduct = await _productOperationalService.DeleteProduct(code);
            if (deleteProduct.ResponseCode == CustomStatusCodes.Product_Not_Avaliable)
                return BadRequest(deleteProduct);
            return Ok(deleteProduct);
        }
    }
}
