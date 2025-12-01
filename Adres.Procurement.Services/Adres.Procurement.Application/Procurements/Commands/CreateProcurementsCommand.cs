using Adres.Procurement.Domain.Entities;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Commands;

public record CreateProcurementCommand(
    decimal Budget,
    string Entity,
    string Item,
    float Quantity,
    decimal UnitPrice,
    DateTime Date,
    string Supplier,
    IEnumerable<ProcurementFileEntity> Files,
    string StoragePath
) : IRequest<ProcurementEntity>;
