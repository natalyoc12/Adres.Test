namespace Adres.Procurement.Api.Dtos;

public class PagedResultDto<T>
{
    public IEnumerable<T> Records { get; set; } = new List<T>();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
}
