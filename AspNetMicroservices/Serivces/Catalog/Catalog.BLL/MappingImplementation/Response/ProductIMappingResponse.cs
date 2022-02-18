using Catalog.Entities.ApiEntities.Product.Response;
using Catalog.Entities.DBEntities;
using Catalog.Entities.Mapping.MappingConfiguration;
using Catalog.Entities.Mapping.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.MappingImplementation.Response
{
    public class ProductIMappingResponse : IProductIMappingResponse
    {
        private readonly IProductMappingConfiguration _productMappingConfiguration;
        public ProductIMappingResponse(IProductMappingConfiguration productMappingConfiguration)
        {
            this._productMappingConfiguration = productMappingConfiguration;
        }

        public ProductsResponse MapFromDBProductsToResponse(IEnumerable<DB_Product> products)
        {
            return _productMappingConfiguration.GetMapper().Map<ProductsResponse>(products);
        }

        public ProductResponse MapFromDBProductToResponse(DB_Product product)
        {
            return _productMappingConfiguration.GetMapper().Map<ProductResponse>(product);
        }
    }
}
