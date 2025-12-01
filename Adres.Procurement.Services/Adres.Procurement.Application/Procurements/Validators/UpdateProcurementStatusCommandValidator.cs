using FluentValidation;
using Adres.Procurement.Application.Procurements.Commands;
using Adres.Procurement.Domain.Entities;

namespace Adres.Procurement.Application.Procurements.Validators;

public class UpdateProcurementStatusCommandValidator : AbstractValidator<UpdateProcurementStatusCommand>
{
    public UpdateProcurementStatusCommandValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("El estado es obligatorio.")
            .Must(value => Enum.TryParse<ProcurementStatus>(value, true, out _))
            .WithMessage("El estado no es válido. Valores permitidos: activate, deactivate.");
    }
}
