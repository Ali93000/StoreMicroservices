using Catalog.Api.ExtenstionManager;
using Catalog.Api.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCatalogContextConfigurations(builder.Configuration);
builder.Services.AddMappingConfigurations();
builder.Services.AddRepositoryConfigurations();
builder.Services.AddBLLConfigurations();


builder.Services.AddControllers(opt=> {
    opt.Filters.Add(new ValidationFilter());
}).AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<Program>();
})
    .ConfigureApiBehaviorOptions(options =>
{
    options.SuppressConsumesConstraintForFormFileParameters = true;
    options.SuppressInferBindingSourcesForParameters = true;
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressMapClientErrors = true;
}); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfigurations();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog Swagger Api Documentation");
    });

}

app.UseAuthorization();

app.MapControllers();

app.Run();
