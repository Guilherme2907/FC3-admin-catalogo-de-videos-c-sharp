using Codeflix.Catalog.UnitTests.Application.Category.Common;
using Codeflix.Catalog.UnitTests.Application.Category.CreateCategory;
using Xunit;

namespace Codeflix.Catalog.UnitTests.Application.Category.DeleteCategory;

[CollectionDefinition(nameof(DeleteCategoryTestFixture))]
public class DeleteCategoryTestFixtureCollection
    : ICollectionFixture<DeleteCategoryTestFixture>
{ }

public class DeleteCategoryTestFixture : CategoryUseCasesBaseFixture
{
}


