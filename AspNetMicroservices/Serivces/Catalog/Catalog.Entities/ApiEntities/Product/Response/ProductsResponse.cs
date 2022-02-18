using Catalog.Entities.DtoEntities;
using Catalog.Entities.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.ApiEntities.Product.Response
{
    public class ProductsResponse : GenericResponse
    {
        public ProductsResponse()
        {
            Products = new List<ProductDto>();
        }
        public List<ProductDto> Products { get; set; }
    }
}
