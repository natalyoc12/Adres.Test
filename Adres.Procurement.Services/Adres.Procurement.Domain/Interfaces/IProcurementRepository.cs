using Adres.Procurement.Domain.Entities;

namespace Adres.Procurement.Domain.Interfaces;

public interface IProcurementRepository
{
    Task<ProcurementEntity> SaveAsync(ProcurementEntity procurement);
    Task<ProcurementEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProcurementEntity>> GetAsync();
    Task<IEnumerable<ProcurementEntity>> GetFilteredAsync(
        string? entity,
        string? supplier,
        string? item,
        bool includeInactive,
        DateTime? dateFrom,
        DateTime? dateTo,
        string? search);

    Task<PagedResult<ProcurementEntity>> GetFilteredPagedAsync(ProcurementFilter filter, int page, int pageSize);
    Task UpdateAsync(ProcurementEntity procurement);
}
