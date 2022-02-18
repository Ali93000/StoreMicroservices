using Catalog.Entities.ApiEntities.Product.Response;
using Catalog.Entities.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.Mapping.Response
{
    public interface IProductIMappingResponse
    {
        ProductsResponse MapFromDBProductsToResponse(IEnumerable<DB_Product> products);
        ProductResponse MapFromDBProductToResponse(DB_Product product);
    }
}
