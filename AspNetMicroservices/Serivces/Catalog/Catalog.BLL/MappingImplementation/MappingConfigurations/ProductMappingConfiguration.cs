using AutoMapper;
using Catalog.Entities.ApiEntities.Product.Response;
using Catalog.Entities.DBEntities;
using Catalog.Entities.DtoEntities;
using Catalog.Entities.Mapping.MappingConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.MappingImplementation.MappingConfigurations
{
    public class ProductMappingConfiguration : IProductMappingConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DB_Product, ProductDto>();
                cfg.CreateMap<DB_Product, ProductResponse>()
                .ForMember(des => des.Product, map => map.MapFrom(src => src));

                cfg.CreateMap<List<DB_Product>, ProductsResponse>()
                .ForMember(des => des.Products, map => map.MapFrom(src => src));
            });
            return config.CreateMapper();
        }
    }
}
