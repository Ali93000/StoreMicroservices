using Catalog.Entities.DtoEntities;
using Catalog.Entities.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.ApiEntities.Product.Response
{
    public class ProductResponse : GenericResponse
    {
        public ProductDto Product { get; set; }
    }
}
