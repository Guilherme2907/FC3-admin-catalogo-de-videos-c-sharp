using CodeFlix.Catalog.Application.Common;
using CodeFlix.Catalog.Application.UseCases.Category.Common;

namespace Codeflix.Catalog.Api.ApiModels.Response;

public class ApiResponseList<TItemData> : ApiResponse<IReadOnlyList<TItemData>>
{
    public ApiResponseListMeta Meta { get; set; }

    public ApiResponseList(IReadOnlyList<TItemData> data, int perPage, int currentPage, int total)
        : base(data)
    {
        Meta = new ApiResponseListMeta(perPage, currentPage, total);
    }

    public ApiResponseList(PaginatedListOutput<TItemData> paginatedListOutput)
        : base(paginatedListOutput.Items)
    {
        Meta = new ApiResponseListMeta( paginatedListOutput.PerPage,
                                        paginatedListOutput.Page,
                                        paginatedListOutput.Total
                                      );
    }
}
