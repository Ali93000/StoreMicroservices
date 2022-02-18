using Catalog.Entities.ApiEntities.Product.Response;
using Catalog.Entities.DBEntities;
using Catalog.Entities.DtoEntities;
using Catalog.Entities.GenericModels;
using Catalog.Entities.Interfaces.ProductServices;
using Catalog.Entities.Interfaces.Repository;
using Catalog.Entities.Mapping.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.ProductServices.Enquiry
{
    public class ProductEnquiryService : IProductEnquiryService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductIMappingResponse _productIMappingResponse;
        public ProductEnquiryService(IProductRepository productRepository, IProductIMappingResponse productIMappingResponse)
        {
            this._productRepository = productRepository;
            this._productIMappingResponse = productIMappingResponse;    
        }

        public async Task<ProductsResponse> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            if (products.Count() == 0)
            {
                return new ProductsResponse
                {
                    IsSuccessful = false,
                    Products = new List<ProductDto>(),
                    ResponseCode = CustomStatusCodes.Product_Not_Avaliable,
                    ResponseMessages = new List<string> { ValidationMessages.NotAvaliableProducts }
                };
            }
            var mappedProducts = _productIMappingResponse.MapFromDBProductsToResponse(products);
            return mappedProducts;
        }

        public async Task<ProductResponse> GetProductByCode(string code)
        {
            var product = await _productRepository.GetFirstOrDefaultAsync(c=>c.Code == code);
            if (product == null)
            {
                return new ProductResponse
                {
                    IsSuccessful = false,
                    Product = null,
                    ResponseCode = CustomStatusCodes.Product_Not_Avaliable,
                    ResponseMessages = new List<string> { ValidationMessages.NotAvaliableProducts }
                };
            }
            var mappedProducts = _productIMappingResponse.MapFromDBProductToResponse(product);
            return mappedProducts;
        }
    }
}
