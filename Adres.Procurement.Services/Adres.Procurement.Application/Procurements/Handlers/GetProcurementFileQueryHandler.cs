using Adres.Procurement.Application.Excepctions;
using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Queries;

public class GetProcurementFileQueryHandler(
    IProcurementFileRepository repository) : IRequestHandler<GetProcurementFileQuery, ProcurementFileEntity?>
{
    private readonly IProcurementFileRepository _repository = repository;

    public async Task<ProcurementFileEntity?> Handle(GetProcurementFileQuery query, CancellationToken cancellationToken)
    {
        return await _repository.GetFile(query.ProcurementId, query.FileId)
            ?? throw new NotFoundException("ProcurementFile", query.FileId.ToString());
    }
}
