namespace Adres.Procurement.Api.Dtos;

public record ProcurementDto(
    Guid Id,
    decimal Budget,
    string Entity,
    string Item,
    float Quantity,
    decimal UnitPrice,
    decimal TotalPrice,
    DateTime Date,
    string Supplier,
    IEnumerable<ProcurementFileDto> Files,
    bool IsActive,
    DateTime CreatedAt
);
