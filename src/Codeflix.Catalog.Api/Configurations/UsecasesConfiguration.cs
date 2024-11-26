using CodeFlix.Catalog.Application.Interfaces;
using Codeflix.Catalog.Domain.Repository;
using Codeflix.Catalog.Infra.Data.EF.Repositories;
using Codeflix.Catalog.Infra.Data.EF;
using CodeFlix.Catalog.Application.UseCases.Category.CreateCategory;
using MediatR;

namespace Codeflix.Catalog.Api.Configurations;

public static class UsecasesConfiguration
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateCategory));
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(
           this IServiceCollection services
       )
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
