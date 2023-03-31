using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Handlers.CommandHandlers;
using CleanArchitecture.Application.Handlers.QueryHandlers;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // customer
            services.AddScoped<IRequestHandler<GetAllCustomerQuery, List<Customer>>, GetAllCustomerHandler>();
            services.AddScoped<IRequestHandler<GetCustomerByEmailQuery, Customer>, GetCustomerByEmailHandler>();
            services.AddScoped<IRequestHandler<GetCustomerByIdQuery, Customer>, GetCustomerByIdHandler>();
            services.AddScoped<IRequestHandler<CreateCustomerCommand, CustomerResponse>, CreateCustomerHandler>();
            services.AddScoped<IRequestHandler<DeleteCustomerCommand, string>, DeleteCustomerHandler>();
            services.AddScoped<IRequestHandler<EditCustomerCommand, CustomerResponse>, EditCustomerHandler>();
            //services.AddMediatR(typeof(GetCustomerByEmailHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            // brand

            return services;
        }
    }
}
