using FluentValidation;
using Adres.Procurement.Application.Procurements.Commands;

namespace Adres.Procurement.Application.Procurements.Validators;

public class CreateProcurementCommandValidator : AbstractValidator<CreateProcurementCommand>
{
    public CreateProcurementCommandValidator()
    {
        RuleFor(x => x.Budget)
            .NotNull().WithMessage("El presupuesto es obligatorio.")
            .GreaterThan(0).WithMessage("El presupuesto debe ser mayor a 0.");

        RuleFor(x => x.Entity)
            .NotNull().WithMessage("La entidad es obligatoria.")
            .NotEmpty().WithMessage("La entidad no puede estar vacía.")
            .MaximumLength(200);

        RuleFor(x => x.Item)
            .NotNull().WithMessage("El item es obligatorio.")
            .NotEmpty().WithMessage("El item no puede estar vacío.")
            .MaximumLength(300);

        RuleFor(x => x.Quantity)
            .NotNull().WithMessage("La cantidad es obligatoria.")
            .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");

        RuleFor(x => x.UnitPrice)
            .NotNull().WithMessage("El precio unitario es obligatorio.")
            .GreaterThan(0).WithMessage("El precio unitario debe ser mayor a 0.");

        RuleFor(x => x.Date)
            .NotNull().WithMessage("La fecha es obligatoria.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("La fecha no puede ser futura.");

        RuleFor(x => x.Supplier)
            .NotNull().WithMessage("El proveedor es obligatorio.")
            .NotEmpty().WithMessage("El proveedor no puede estar vacío.")
            .MaximumLength(200);

        RuleForEach(x => x.Files).Must(f =>
            f.Content.Length <= 1 * 1024 * 1024
        ).WithMessage("Cada archivo debe ser máximo 1 MB.");

        RuleForEach(x => x.Files).Must(f =>
            f.ContentType == "application/pdf" ||
            f.ContentType == "image/jpeg" ||
            f.ContentType == "image/png"
        ).WithMessage("Solo se permiten archivos PDF, JPG o PNG.");

        RuleFor(x => x.Files.Count()).LessThanOrEqualTo(10)
            .WithMessage("No se permiten más de 10 archivos.");
    }
}
