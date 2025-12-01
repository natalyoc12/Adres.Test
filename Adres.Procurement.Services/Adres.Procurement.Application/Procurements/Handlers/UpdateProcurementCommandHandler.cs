using Adres.Procurement.Application.Procurements.Commands;
using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using Adres.Procurement.Application.Procurements.Queries;
using MediatR;
using Adres.Procurement.Application.Excepctions;

namespace Adres.Procurement.Application.Procurements.Handlers;

public class UpdateProcurementCommandHandler(
    IMediator mediator,
    IProcurementRepository repository) : IRequestHandler<UpdateProcurementCommand>
{
    private readonly IProcurementRepository _repository = repository;
    private readonly IMediator _mediator = mediator;

    public async Task Handle(UpdateProcurementCommand request, CancellationToken cancellationToken)
    {
        ProcurementEntity procurement = await _mediator.Send(
            new GetProcurementByIdQuery(request.Id),
            cancellationToken
        );

        if (!procurement.IsActive)
        {
            throw new ConflictException("Cannot update an inactive procurement.");
        }

        procurement.Budget = request.Budget;
        procurement.Entity = request.Entity;
        procurement.Item = request.Item;
        procurement.Quantity = request.Quantity;
        procurement.UnitPrice = request.UnitPrice;
        procurement.TotalPrice = request.UnitPrice * (decimal)request.Quantity;
        procurement.Date = request.Date;
        procurement.Supplier = request.Supplier;

        await _repository.UpdateAsync(procurement);
    }
}
