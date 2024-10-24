using LifeRoutineV0.Domain.Enums;
using System.Text.Json.Serialization;

namespace LifeRoutineV0.Domain.Responses;

public class PagedResponse<TData> : Response<TData>
{
    public PagedResponse(TData? data, EStatusCode code, string? message = null) : base(data, code, message)
    {
        
    }

    [JsonConstructor]
    public PagedResponse(TData? data, int pageSize, int currentPage, int totalCount) : base(data)
    {
        Data = data;
        PageSize = pageSize;
        CurrentPage = currentPage;
        TotalCount = totalCount;
    }

    public int CurrentPage { get; set; }
    public int PageSize { get; set; } = 20;
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (decimal)PageSize);
}