namespace Adres.Procurement.Application.Excepctions;

public class NotFoundException(string entity, object key) : Exception($"{entity} with key '{key}' was not found.")
{
}
