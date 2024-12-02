using Codeflix.Catalog.Domain.Repository;
using DomainEntity = Codeflix.Catalog.Domain.Entity;

namespace CodeFlix.Catalog.Application.UseCases.Genre.ListGenres;
public class ListGenres
    : IListGenres
{
    private readonly IGenreRepository _genreRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ListGenres(
        IGenreRepository genreRepository, 
        ICategoryRepository categoryRepository
    )
        => (_genreRepository, _categoryRepository) = (genreRepository, categoryRepository);

    public async Task<ListGenresOutput> Handle(
        ListGenresInput input, 
        CancellationToken cancellationToken
    )
    {
        var searchOutput = await _genreRepository.Search(
            input.ToSearchInput(), cancellationToken
        );

        return ListGenresOutput.FromSearchOutput(searchOutput);
    }
}
