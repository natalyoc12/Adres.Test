using Adres.Procurement.Domain.Entities;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Queries;

public class GetProcurementsQuery(
    ProcurementFilter filter,
    int page,
    int pageSize) : IRequest<PagedResult<ProcurementEntity>>
{
    public string? Entity { get; set; } = filter.Entity;
    public string? Supplier { get; set; } = filter.Supplier;
    public string? Item { get; set; } = filter.Item;
    public bool IncludeInactive { get; set; } = filter.IncludeInactive;
    public DateTime? DateFrom { get; set; } = filter.DateFrom;
    public DateTime? DateTo { get; set; } = filter.DateTo;
    public string? Search { get; set; } = filter.Search;
    public int Page { get; set; } = page < 1 ? 1 : page;
    public int PageSize { get; set; } = pageSize < 1 ? 10 : pageSize;
}
