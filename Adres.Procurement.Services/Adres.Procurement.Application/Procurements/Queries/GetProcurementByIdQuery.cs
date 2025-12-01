using Adres.Procurement.Domain.Entities;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Queries;

public class GetProcurementByIdQuery(Guid id) : IRequest<ProcurementEntity>
{
    public Guid Id { get; set; } = id;
}
