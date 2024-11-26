namespace Codeflix.Catalog.Api.ApiModels.Response;

public class ApiResponseListMeta
{
    public int PerPage { get; set; }

    public int CurrentPage { get; set; }

    public int Total { get; set; }

    public ApiResponseListMeta(int perPage, int currentPage, int total)
    {
        PerPage = perPage;
        CurrentPage = currentPage;
        Total = total;
    }
}
