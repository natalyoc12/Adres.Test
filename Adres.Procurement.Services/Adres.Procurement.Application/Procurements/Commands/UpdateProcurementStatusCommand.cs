using Adres.Procurement.Domain.Entities;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Commands;

public record UpdateProcurementStatusCommand(
    Guid Id,
    string Status
) : IRequest;
