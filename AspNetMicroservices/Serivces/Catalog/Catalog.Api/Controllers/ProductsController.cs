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
        public ProductsController(IProductEnquiryService productEnquiryService)
        {
            this._productEnquiryService = productEnquiryService;
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
    }
}
