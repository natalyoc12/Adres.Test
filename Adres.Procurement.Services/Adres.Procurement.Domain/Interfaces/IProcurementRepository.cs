using Adres.Procurement.Domain.Entities;

namespace Adres.Procurement.Domain.Interfaces;

public interface IProcurementRepository
{
    Task<ProcurementEntity> SaveAsync(ProcurementEntity procurement);
    Task<ProcurementEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProcurementEntity>> GetAsync();
    Task UpdateAsync(ProcurementEntity procurement);
}
