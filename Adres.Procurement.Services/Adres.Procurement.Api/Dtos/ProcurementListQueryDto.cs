namespace Adres.Procurement.Api.Dtos;

public record ProcurementListQueryDto(
    string? Entity,
    string? Supplier,
    string? Item,
    bool IncludeInactive,
    DateTime? DateFrom,
    DateTime? DateTo,
    string? Search,
    int Page,
    int PageSize);
