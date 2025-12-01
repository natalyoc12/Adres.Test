using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Adres.Procurement.Application.Procurements.Handlers;
using Adres.Procurement.Application.Procurements.Validators;

namespace Adres.Procurement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Handlers
        services.AddScoped<CreateProcurementCommandHandler>();
        services.AddScoped<GetProcurementByIdQueryHandler>();
        services.AddScoped<GetProcurementsQueryHandler>();
        services.AddScoped<UpdateProcurementStatusCommandHandler>();

        // Validators
        services.AddValidatorsFromAssemblyContaining<CreateProcurementCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateProcurementCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateProcurementStatusCommandValidator>();

        return services;
    }
}
