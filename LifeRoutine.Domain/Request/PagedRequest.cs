namespace LifeRoutine.Domain.Request;

public abstract class PagedRequest : Request
{
    public int PageSize { get; set; }
    public int PageCount { get; set; }
}