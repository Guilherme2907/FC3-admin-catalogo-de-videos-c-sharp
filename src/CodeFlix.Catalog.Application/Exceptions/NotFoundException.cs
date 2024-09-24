namespace CodeFlix.Catalog.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string? message) : base(message)
    { }

    public static void ThrowIfNull(object? value, string message)
    {
        if (value is null)
        {
           throw new NotFoundException(message);
        }
    }
}
