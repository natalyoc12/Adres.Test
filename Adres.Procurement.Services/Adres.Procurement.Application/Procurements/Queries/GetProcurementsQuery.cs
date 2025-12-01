using Adres.Procurement.Domain.Entities;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Queries;

public class GetProcurementsQuery() : IRequest<IEnumerable<ProcurementEntity>>
{
}
