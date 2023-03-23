using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Commands.Categories;
using CleanArchitecture.Application.Handlers.CommandHandlers;
using CleanArchitecture.Application.Handlers.CommandHandlers.Brands;
using CleanArchitecture.Application.Handlers.CommandHandlers.Categories;
using CleanArchitecture.Application.Handlers.QueryHandlers;
using CleanArchitecture.Application.Handlers.QueryHandlers.Brands;
using CleanArchitecture.Application.Handlers.QueryHandlers.Categories;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Queries.Brands;
using CleanArchitecture.Application.Queries.Categories;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Domain.Repositories.Query;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repository.Command;
using CleanArchitecture.Infrastructure.Repository.Query;
using CleanArchitecture.Infrastructure.Repository.Query.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


//MINE
builder.Services.AddDbContext<OrderingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLServerConnection")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitecture.API", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// customers
builder.Services.AddScoped<IRequestHandler<GetAllCustomerQuery, List<Customer>>, GetAllCustomerHandler>();
builder.Services.AddScoped<IRequestHandler<GetCustomerByEmailQuery, Customer>, GetCustomerByEmailHandler>();
builder.Services.AddScoped<IRequestHandler<GetCustomerByIdQuery, Customer>, GetCustomerByIdHandler>();
builder.Services.AddScoped<IRequestHandler<CreateCustomerCommand, CustomerResponse>, CreateCustomerHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteCustomerCommand, string>, DeleteCustomerHandler>();
builder.Services.AddScoped<IRequestHandler<EditCustomerCommand, CustomerResponse>, EditCustomerHandler>();

// brands
builder.Services.AddScoped<IRequestHandler<GetAllBrandQuery, List<Brand>>, GetAllBrandHandler>();
builder.Services.AddScoped<IRequestHandler<GetBrandByIdQuery, Brand>, GetBrandByIdHandler>();
builder.Services.AddScoped<IRequestHandler<CreateBrandCommand, BrandResponse>, CreateBrandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteBrandCommand, string>, DeleteBrandHandler>();
builder.Services.AddScoped<IRequestHandler<EditBrandCommand, BrandResponse>, EditBrandHandler>();

// categories
builder.Services.AddScoped<IRequestHandler<GetAllCategoryQuery, List<Category>>, GetAllCategoryHandler>();
builder.Services.AddScoped<IRequestHandler<GetCategoryByIdQuery, Category>, GetCategoryByIdHandler>();
builder.Services.AddScoped<IRequestHandler<CreateCategoryCommand, CategoryResponse>, CreateCategoryHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteCategoryCommand, string>, DeleteCategoryHandler>();
builder.Services.AddScoped<IRequestHandler<EditCategoryCommand, CategoryResponse>, EditCategoryHandler>();

builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));

// customers
builder.Services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddTransient<ICommandCustomerRepository, CustomerCommandRepository>();

// brands
builder.Services.AddTransient<IBrandQueryRepository, BrandQueryRepository>();
builder.Services.AddTransient<ICommandBrandRepository, BrandCommandRepository>();

// categories
builder.Services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();
builder.Services.AddTransient<ICommandCategoryRepository, CategoryCommandRepository>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.API v1"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
