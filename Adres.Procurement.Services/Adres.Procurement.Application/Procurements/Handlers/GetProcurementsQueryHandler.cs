using Adres.Procurement.Application.Procurements.Queries;
using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Handlers;

public class GetProcurementsQueryHandler(
    IProcurementRepository repository) : IRequestHandler<GetProcurementsQuery, IEnumerable<ProcurementEntity>>
{
    private readonly IProcurementRepository _repository = repository;

    public async Task<IEnumerable<ProcurementEntity>> Handle(GetProcurementsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAsync();
    }
}
