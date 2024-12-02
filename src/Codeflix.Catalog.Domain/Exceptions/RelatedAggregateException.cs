namespace Codeflix.Catalog.Domain.Exceptions;

public class RelatedAggregateException : Exception
{
    public RelatedAggregateException(string? message) : base(message)
    {
    }
}
