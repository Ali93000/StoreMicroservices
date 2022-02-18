using Catalog.Entities.ApiEntities.Product.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.Interfaces.ProductServices
{
    public interface IProductEnquiryService
    {
        Task<ProductsResponse> GetProducts();
        Task<ProductResponse> GetProductByCode(string code);
    }
}
