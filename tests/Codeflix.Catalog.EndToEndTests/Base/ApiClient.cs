using Codeflix.Catalog.Api;
using Codeflix.Catalog.Api.ApiModels.Category;
using Codeflix.Catalog.Api.Configurations.Policies;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Json;

namespace Codeflix.Catalog.EndToEndTests.Base;

public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _defaultSerializeOptions;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _defaultSerializeOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = new JsonSnakeCasePolicy()
        };
    }

    public async Task<(HttpResponseMessage?, TOutput?)> Post<TOutput>(
        string route,
        object payload
    ) where TOutput : class
    {
        var serializedPayload = new StringContent(
            JsonSerializer.Serialize(payload, _defaultSerializeOptions),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync(route, serializedPayload);

        TOutput? output = await GetOutput<TOutput>(response);

        return (response, output);
    }

    public async Task<(HttpResponseMessage?, TOutput?)> Get<TOutput>(
        string route,
        object? queryStringParametersObject = null
    ) where TOutput : class
    {
        var url = PrepareGetRoute(route, queryStringParametersObject);
        var response = await _httpClient.GetAsync(url);
        TOutput? output = await GetOutput<TOutput>(response);

        return (response, output);
    }

    public async Task<(HttpResponseMessage?, TOutput?)> Delete<TOutput>(
       string route
    ) where TOutput : class
    {
        var response = await _httpClient.DeleteAsync(route);

        TOutput? output = await GetOutput<TOutput>(response);

        return (response, output);
    }

    public async Task<(HttpResponseMessage?, TOutput?)> Put<TOutput>(
    string route,
    UpdateCategoryApiInput payload
 ) where TOutput : class
    {
        var serializedPayload = new StringContent(
           JsonSerializer.Serialize(payload, _defaultSerializeOptions),
           Encoding.UTF8,
           "application/json"
       );

        var response = await _httpClient.PutAsync(route, serializedPayload);

        TOutput? output = await GetOutput<TOutput>(response);

        return (response, output);
    }

    private async Task<TOutput?> GetOutput<TOutput>(HttpResponseMessage response)
        where TOutput : class
    {
        var outputString = await response.Content.ReadAsStringAsync();

        TOutput? output = null;

        if (!string.IsNullOrWhiteSpace(outputString))
        {
            output = JsonSerializer.Deserialize<TOutput>(
                outputString,
                _defaultSerializeOptions
            );
        }

        return output;
    }

    private string PrepareGetRoute(
        string route,
        object? queryStringParametersObject
    )
    {
        if (queryStringParametersObject is null)
            return route;

        var parametersJson = JsonSerializer.Serialize(
            queryStringParametersObject,
            _defaultSerializeOptions
        );

        var parametersDictionary = Newtonsoft.Json.JsonConvert
            .DeserializeObject<Dictionary<string, string>>(parametersJson);
        return QueryHelpers.AddQueryString(route, parametersDictionary!);
    }
}
