using System.Text.Json.Serialization;

namespace LifeRoutine.Domain.Response;

public class PagedResponse<TData> : Response<TData>
{
    [JsonConstructor]
    public PagedResponse(TData? data, int pagesize, int totalcount) : base(data)
    {
        Data = data;
        PageSize = pagesize;
        TotalCount = totalcount;
    }

    public PagedResponse(TData? data, int code, string? message = null) : base(data, code, message)
    {
        
    }

    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (decimal)PageSize);
}

