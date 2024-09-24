namespace Codeflix.Catalog.Domain.SeedWork.SearchableRepository;

public interface ISeachableRepository<TAggregate>
    where TAggregate : AggregateRoot
{
    Task<SearchOutput<TAggregate>> Search(
        SearchInput input, 
        CancellationToken cancellation
    );
}
