using Catalog.Application.Products.CreateProduct;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Persistence.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CatalogDb")
    ?? "Server=(localdb)\\mssqllocaldb;Database=CatalogDb;Trusted_Connection=True;";

builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registro dos contratos do domínio e da aplicação.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICreateProductService, CreateProductService>();
builder.Services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
builder.Services.AddScoped<CreateProductCommandHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.MapGet("/", () => "Catalog API is running!");

app.MapPost("/products", (CreateProductCommand command, CreateProductCommandHandler handler, CancellationToken cancellationToken) =>
{
    try
    {
        var response = handler.Handle(command, cancellationToken);
        return Results.Created($"/products/{response.Id}", response);
    }
    catch (ValidationException ex)
    {
        var errors = ex.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray());

        return Results.ValidationProblem(errors);
    }
});

app.Run();
