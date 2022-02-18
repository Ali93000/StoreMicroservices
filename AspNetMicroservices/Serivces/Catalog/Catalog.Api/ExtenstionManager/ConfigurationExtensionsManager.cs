using Catalog.BLL.MappingImplementation.MappingConfigurations;
using Catalog.BLL.MappingImplementation.Response;
using Catalog.BLL.ProductServices.Enquiry;
using Catalog.DAL.Domain;
using Catalog.DAL.Repository;
using Catalog.DAL.UnitOfWork;
using Catalog.Entities.Interfaces.ProductServices;
using Catalog.Entities.Interfaces.Repository;
using Catalog.Entities.Interfaces.UnitOfWork;
using Catalog.Entities.Mapping.MappingConfiguration;
using Catalog.Entities.Mapping.Response;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.ExtenstionManager
{
    public static class ConfigurationExtensionsManager
    {
        public static void AddCatalogContextConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(Program).Assembly.GetName().Name;
            services.AddDbContextPool<CatalogDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CatalogDBConnection"),
                optionsAction => optionsAction.MigrationsAssembly("Catalog.Migrations")));
        }

        public static void AddMappingConfigurations(this IServiceCollection services)
        {
            // Product
            services.AddScoped<IProductMappingConfiguration, ProductMappingConfiguration>();
            services.AddScoped<IProductIMappingResponse, ProductIMappingResponse>();
        }

        public static void AddRepositoryConfigurations(this IServiceCollection services)
        {          
            // Generic Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, CatalogDBContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // Product
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void AddBLLConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IProductEnquiryService, ProductEnquiryService>();
        }
    }
}
