using Adres.Procurement.Application.Procurements.Commands;
using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using Adres.Procurement.Application.Procurements.Queries;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Handlers;

public class UpdateProcurementStatusCommandHandler(
    IMediator mediator,
    IProcurementRepository repository) : IRequestHandler<UpdateProcurementStatusCommand>
{
    private readonly IProcurementRepository _repository = repository;
    private readonly IMediator _mediator = mediator;

    public async Task Handle(UpdateProcurementStatusCommand request, CancellationToken cancellationToken)
    {
        ProcurementEntity procurement = await _mediator.Send(
            new GetProcurementByIdQuery(request.Id),
            cancellationToken
        );

        procurement.IsActive = request.Status.Equals(
            ProcurementStatus.Activate.ToString(),
            StringComparison.CurrentCultureIgnoreCase
        );

        await _repository.UpdateAsync(procurement);
    }
}
