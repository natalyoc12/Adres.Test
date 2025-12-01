namespace Adres.Procurement.Domain.Entities;

public record ProcurementFilter(
    string? Entity,
    string? Supplier,
    string? Item,
    bool IncludeInactive,
    DateTime? DateFrom,
    DateTime? DateTo,
    string? Search
);
