using Catalog.Entities.ApiEntities.Product.Request;
using Catalog.Entities.GenericModels;
using Catalog.Entities.Interfaces.ProductServices;
using Catalog.Entities.Interfaces.Repository;
using Catalog.Entities.Interfaces.UnitOfWork;
using Catalog.Entities.Mapping.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.ProductServices.Operational
{
    public class ProductOperationalService : IProductOperationalService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductMappingRequest _productMappingRequest;
        private readonly IUnitOfWork _unitOfWork;
        public ProductOperationalService(IProductRepository productRepository,
            IProductMappingRequest productMappingRequest,
            IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._productMappingRequest = productMappingRequest;
            this._unitOfWork = unitOfWork;
        }
        public async Task<GenericResponse> CreateProduct(CreateProductRequest createProductRequest)
        {
            var createProduct = _productMappingRequest.MapFromCreateProductRequestToDB(createProductRequest);
            await _productRepository.AddAsync(createProduct);
            var res = await _unitOfWork.SaveAsync();
            return new GenericResponse
            {
                IsSuccessful = true,
                ResponseCode = CustomStatusCodes.Created,
                ResponseMessages = new List<string> { ValidationMessages.ProductCreatedSuccessfuly }
            };
        }

        public async Task<GenericResponse> DeleteProduct(string code)
        {
            var deleteProduct = await _productRepository.GetFirstOrDefaultAsync(c => c.Code == code);
            if (deleteProduct == null)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    ResponseCode = CustomStatusCodes.Product_Not_Avaliable,
                    ResponseMessages = new List<string> { ValidationMessages.ProductNotFound }
                };
            }
            _productRepository.Remove(deleteProduct);
            await _unitOfWork.SaveAsync();
            return new GenericResponse
            {
                IsSuccessful = true,
                ResponseCode = CustomStatusCodes.Success,
                ResponseMessages = new List<string> { ValidationMessages.ProductDeletedSuccessfuly }
            };
        }
    }
}
