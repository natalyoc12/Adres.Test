using Adres.Procurement.Domain.Entities;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Queries;

public record GetProcurementFileQuery(Guid ProcurementId, Guid FileId) : IRequest<ProcurementFileEntity>;
