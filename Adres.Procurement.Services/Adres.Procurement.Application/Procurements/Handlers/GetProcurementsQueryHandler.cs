using Adres.Procurement.Application.Procurements.Queries;
using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Handlers;

public class GetProcurementsQueryHandler(
    IProcurementRepository repository) : IRequestHandler<GetProcurementsQuery, PagedResult<ProcurementEntity>>
{
    private readonly IProcurementRepository _repository = repository;

    public async Task<PagedResult<ProcurementEntity>> Handle(GetProcurementsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetFilteredPagedAsync(
            new ProcurementFilter(
                request.Entity,
                request.Supplier,
                request.Item,
                request.IncludeInactive,
                request.DateFrom,
                request.DateTo,
                request.Search),
            request.Page,
            request.PageSize
        );
    }
}
