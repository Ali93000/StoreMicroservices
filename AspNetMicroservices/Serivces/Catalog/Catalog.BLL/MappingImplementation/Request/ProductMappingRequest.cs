using Catalog.Entities.ApiEntities.Product.Request;
using Catalog.Entities.DBEntities;
using Catalog.Entities.Mapping.MappingConfiguration;
using Catalog.Entities.Mapping.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.MappingImplementation.Request
{
    public class ProductMappingRequest : IProductMappingRequest
    {
        private readonly IProductMappingConfiguration _productMappingConfiguration;
        public ProductMappingRequest(IProductMappingConfiguration productMappingConfiguration)
        {
            this._productMappingConfiguration = productMappingConfiguration;
        }
        public DB_Product MapFromCreateProductRequestToDB(CreateProductRequest createProductRequest)
        {
            return _productMappingConfiguration.GetMapper().Map<DB_Product>(createProductRequest);
        }
    }
}
