using Bogus;
using Codeflix.Catalog.Infra.Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codeflix.Catalog.EndToEndTests.Base;

public class BaseFixture
{
    protected Faker Faker;

    public ApiClient ApiClient { get; set; }

    public CustomWebApplicationFactory<Program> WebAppFactory { get; set; }

    public HttpClient HttpClient { get; set; }

    private readonly string _dbConnectionString;

    public BaseFixture()
    {
        Faker = new Faker("pt_BR");
        WebAppFactory = new CustomWebApplicationFactory<Program>();
        HttpClient = WebAppFactory.CreateClient();
        ApiClient = new ApiClient(HttpClient);
        var configuration = WebAppFactory.Services
            .GetRequiredService<IConfiguration>();

        ArgumentNullException.ThrowIfNull(configuration);

        _dbConnectionString = configuration.GetConnectionString("CatalogDb");
    }

    public CodeflixCatalogDbContext CreateDbContext()
    {
        var context = new CodeflixCatalogDbContext(
            new DbContextOptionsBuilder<CodeflixCatalogDbContext>()
            .UseMySql(
                _dbConnectionString,
                ServerVersion.AutoDetect(_dbConnectionString)
            )
            .Options
        );

        return context;
    }

    public void CleanPersistence()
    {
        var context = CreateDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}
