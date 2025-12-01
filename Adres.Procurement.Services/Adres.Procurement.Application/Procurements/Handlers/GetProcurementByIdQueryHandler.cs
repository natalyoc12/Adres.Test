using Adres.Procurement.Application.Procurements.Queries;
using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using Adres.Procurement.Application.Excepctions;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Handlers;

public class GetProcurementByIdQueryHandler(
    IProcurementRepository repository) : IRequestHandler<GetProcurementByIdQuery, ProcurementEntity>
{
    private readonly IProcurementRepository _repository = repository;

    public async Task<ProcurementEntity> Handle(GetProcurementByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Procurement", request.Id);
    }
}
