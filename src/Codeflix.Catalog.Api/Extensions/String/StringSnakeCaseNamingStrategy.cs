using Newtonsoft.Json.Serialization;

namespace Codeflix.Catalog.Api;

public static class StringSnakeCaseNamingStrategy
{
    private readonly static NamingStrategy _snakeCaseNamingStrategy
        = new SnakeCaseNamingStrategy();

    public static string ToSnakeCase(this string stringToConvert)
    {
        ArgumentNullException.ThrowIfNull(stringToConvert, nameof(stringToConvert));

        return _snakeCaseNamingStrategy.GetPropertyName(stringToConvert, false);
    }
}
