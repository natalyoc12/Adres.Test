using Adres.Procurement.Domain.Entities;

namespace Adres.Procurement.Domain.Interfaces;

public interface IProcurementFileRepository
{
    Task<ProcurementFileEntity?> GetFile(Guid procurementId, Guid fileId);
}
