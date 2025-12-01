namespace Adres.Procurement.Api.Dtos;

public record ProcurementFileDto(
    Guid Id,
    string FileName,
    string ContentType,
    long Size,
    string Url
);
