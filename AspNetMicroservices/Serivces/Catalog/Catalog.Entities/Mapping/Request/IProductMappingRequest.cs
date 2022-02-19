using Catalog.Entities.ApiEntities.Product.Request;
using Catalog.Entities.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.Mapping.Request
{
    public interface IProductMappingRequest
    {
        DB_Product MapFromCreateProductRequestToDB(CreateProductRequest createProductRequest);
    }
}
