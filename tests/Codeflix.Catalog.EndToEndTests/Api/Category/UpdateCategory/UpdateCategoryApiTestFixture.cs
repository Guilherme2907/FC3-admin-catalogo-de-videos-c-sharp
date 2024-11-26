using Codeflix.Catalog.Api.ApiModels.Category;
using Codeflix.Catalog.EndToEndTests.Api.Category.Common;
using CodeFlix.Catalog.Application.UseCases.Category.UpdateCategory;
using Xunit;

namespace Codeflix.Catalog.EndToEndTests.Api.Category.UpdateCategory;

[CollectionDefinition(nameof(UpdateCategoryApiTestFixture))]
public class UpdateCategoryApiTestFixtureCollection
    : ICollectionFixture<UpdateCategoryApiTestFixture>
{ }

public class UpdateCategoryApiTestFixture
    : CategoryBaseFixture
{
    public UpdateCategoryApiInput GetExampleInput()
    {
        return new(
            GetValidCategoryName(),
            GetValidCategoryDescription(),
            getRandomBoolean()
        );
    }
}
