using Codeflix.Catalog.Infra.Data.EF.Repositories;
using CodeFlix.Catalog.Application.Interfaces;

namespace Codeflix.Catalog.Infra.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private readonly CodeflixCatalogDbContext _context;

    public UnitOfWork(CodeflixCatalogDbContext context)
    {
        _context = context;
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }

    public Task Rollback(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
