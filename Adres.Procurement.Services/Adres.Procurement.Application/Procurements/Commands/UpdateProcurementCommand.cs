using MediatR;

namespace Adres.Procurement.Application.Procurements.Commands;

public record UpdateProcurementCommand(
    Guid Id,
    decimal Budget,
    string Entity,
    string Item,
    float Quantity,
    decimal UnitPrice,
    DateTime Date,
    string Supplier
) : IRequest;