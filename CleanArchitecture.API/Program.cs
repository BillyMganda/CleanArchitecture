using CleanArchitecture.Application.Handlers.CommandHandlers;
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
builder.Services.AddMediatR(typeof(CreateCustomerHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient<ICommandCustomerRepository, CustomerCommandRepository>();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.API v1"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
