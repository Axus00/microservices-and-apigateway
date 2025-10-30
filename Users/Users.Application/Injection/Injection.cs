using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Abstractions.Messaging;
using Users.Application.Products.commands;
using Users.Application.Products.Queries;
using Users.Application.Users.Commands;
using Users.Application.Users.Queries;
using Users.Domain.Dtos;
using Users.Domain.Entities;

namespace Users.Application.Injection;
public static class Injection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //Command
        services.AddScoped<ICommandHandler<CreateUserCommand, User>, CreateUserCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateUserCommand, UserDto>, UpdatedUserCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteUserCommand, User>, DeleteUserCommandHandler>();

        services.AddScoped<ICommandHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();

        //Query
        services.AddScoped<IQueryHandler<GetUsersQuery, List<User>>, GetUsersQueryHandler>();
        services.AddScoped<IQueryHandler<GetUserQuery, UserDto>, GetUserQueryHandler>();

        services.AddScoped<IQueryHandler<GetProductsQuery, List<Product>>, GetProductsQueryHandler>();
        services.AddScoped<IQueryHandler<GetProductQuery, ProductDto>, GetProductQueryHandler>();
        return services;
    }
}
