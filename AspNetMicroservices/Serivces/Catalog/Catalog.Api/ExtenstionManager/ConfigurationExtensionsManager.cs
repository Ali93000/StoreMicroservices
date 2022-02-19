using Catalog.BLL.MappingImplementation.MappingConfigurations;
using Catalog.BLL.MappingImplementation.Request;
using Catalog.BLL.MappingImplementation.Response;
using Catalog.BLL.ProductServices.Enquiry;
using Catalog.BLL.ProductServices.Operational;
using Catalog.DAL.Domain;
using Catalog.DAL.Repository;
using Catalog.DAL.UnitOfWork;
using Catalog.Entities.Interfaces.ProductServices;
using Catalog.Entities.Interfaces.Repository;
using Catalog.Entities.Interfaces.UnitOfWork;
using Catalog.Entities.Mapping.MappingConfiguration;
using Catalog.Entities.Mapping.Request;
using Catalog.Entities.Mapping.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
            services.AddScoped<IProductMappingRequest, ProductMappingRequest>();
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
            services.AddScoped<IProductOperationalService, ProductOperationalService>();
        }

        public static void AddSwaggerConfigurations(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Catalog Swagger Api Documentation",
                        Description = "This is a documentation for Catalog Api",
                        Version = "v1"
                    });

                //option.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "basic",
                //    In = ParameterLocation.Header,
                //    Description = "Basic Authorization header using the Bearer scheme."
                //});

                //option.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //          new OpenApiSecurityScheme
                //            {
                //                Reference = new OpenApiReference
                //                {
                //                    Type = ReferenceType.SecurityScheme,
                //                    Id = "basic"
                //                }
                //            },
                //            new string[] {}
                //    }
                //});
            });
        }
    }
}
