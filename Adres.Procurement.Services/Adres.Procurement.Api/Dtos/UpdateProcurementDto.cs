namespace Adres.Procurement.Api.Dtos;

public record UpdateProcurementDto(
    decimal Budget,
    string Entity,
    string Item,
    float Quantity,
    decimal UnitPrice,
    DateTime Date,
    string Supplier
);
