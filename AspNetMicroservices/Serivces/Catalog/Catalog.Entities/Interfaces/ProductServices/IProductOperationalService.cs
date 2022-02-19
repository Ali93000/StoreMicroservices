using Catalog.Entities.ApiEntities.Product.Request;
using Catalog.Entities.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.Interfaces.ProductServices
{
    public interface IProductOperationalService
    {
        Task<GenericResponse> CreateProduct(CreateProductRequest createProductRequest);
        Task<GenericResponse> DeleteProduct(string code);
    }
}
