namespace LifeRoutineV0.Domain.Requests;

public abstract class PagedRequest : Request
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}