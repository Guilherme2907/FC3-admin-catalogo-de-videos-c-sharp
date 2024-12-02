using CodeFlix.Catalog.Application.Common;
using DomainEntity = Codeflix.Catalog.Domain.Entity;
using CodeFlix.Catalog.Application.UseCases.Genre.Common;
using Codeflix.Catalog.Domain.SeedWork.SearchableRepository;

namespace CodeFlix.Catalog.Application.UseCases.Genre.ListGenres;
public class ListGenresOutput
    : PaginatedListOutput<GenreModelOutput>
{
    public ListGenresOutput(
        int page,
        int perPage,
        int total,
        IReadOnlyList<GenreModelOutput> items
    )
        : base(page, perPage, total, items)
    { }

    public static ListGenresOutput FromSearchOutput(
        SearchOutput<DomainEntity.Genre> searchOutput
    ) => new(
            searchOutput.CurrentPage,
            searchOutput.PerPage,
            searchOutput.Total,
            searchOutput.Items
                .Select(GenreModelOutput.FromGenre)
                .ToList()
        );
}
