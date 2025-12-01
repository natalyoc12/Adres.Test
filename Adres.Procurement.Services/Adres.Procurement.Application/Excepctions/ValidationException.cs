namespace Adres.Procurement.Application.Excepctions;

public class ValidationException(IDictionary<string, string[]> errors) : Exception("Validation errors occurred.")
{
    public IDictionary<string, string[]> Errors { get; } = errors;
}
