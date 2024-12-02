using Codeflix.Catalog.UnitTests.Application.Genre.Common;
using Xunit;

namespace CodeFlix.Catalog.UnitTests.Application.Genre.GetGenre;

[CollectionDefinition(nameof(GetGenreTestFixture))]
public class GetGenreTestFixtureCollection
    : ICollectionFixture<GetGenreTestFixture>
{ }

public class GetGenreTestFixture
    : GenreUseCasesBaseFixture
{
}
