using System.ComponentModel.DataAnnotations;

namespace Adres.Procurement.Api.Dtos;

public record CreateProcurementCommandDto(
    decimal Budget,
    string Entity,
    string Item,
    float Quantity,
    decimal UnitPrice,
    DateTime Date,
    string Supplier,
    IFormFileCollection? Files
);
