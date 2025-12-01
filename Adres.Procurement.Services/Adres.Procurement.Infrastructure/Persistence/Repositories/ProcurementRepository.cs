namespace Adres.Procurement.Infrastructure.Persistence.Repositories;

using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using Adres.Procurement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class ProcurementRepository(AppDbContext db) : IProcurementRepository
{
    private readonly AppDbContext _db = db;

    public async Task<ProcurementEntity> SaveAsync(ProcurementEntity procurement)
    {
        _db.Procurements.Add(procurement);
        await _db.SaveChangesAsync();
        return procurement;
    }

    public async Task<ProcurementEntity?> GetByIdAsync(Guid id)
    {
        return await _db.Procurements.Include(p => p.Files).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<ProcurementEntity>> GetAsync()
    {
        return await _db.Procurements.ToListAsync();
    }

    public async Task<IEnumerable<ProcurementEntity>> GetFilteredAsync(
        string? entity,
        string? supplier,
        string? item,
        bool includeInactive,
        DateTime? dateFrom,
        DateTime? dateTo,
        string? search)
    {
        var query = _db.Procurements.AsQueryable();

        if (!string.IsNullOrWhiteSpace(entity))
            query = query.Where(p => p.Entity.Contains(entity));

        if (!string.IsNullOrWhiteSpace(supplier))
            query = query.Where(p => p.Supplier.Contains(supplier));

        if (!string.IsNullOrWhiteSpace(item))
            query = query.Where(p => p.Item.Contains(item));

        if (!includeInactive)
            query = query.Where(p => p.IsActive);

        if (dateFrom.HasValue)
            query = query.Where(p => p.Date >= dateFrom.Value);

        if (dateTo.HasValue)
            query = query.Where(p => p.Date <= dateTo.Value);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p =>
                p.Supplier.Contains(search) ||
                p.Item.Contains(search) ||
                p.Entity.Contains(search) ||
                p.Budget.ToString().Contains(search)
            );
        }

        return await query.ToListAsync();
    }

    public async Task<PagedResult<ProcurementEntity>> GetFilteredPagedAsync(
        ProcurementFilter filter,
        int page,
        int pageSize)
    {
        var query = _db.Procurements.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Entity))
            query = query.Where(p => p.Entity.Contains(filter.Entity));

        if (!string.IsNullOrWhiteSpace(filter.Supplier))
            query = query.Where(p => p.Supplier.Contains(filter.Supplier));
        if (!string.IsNullOrWhiteSpace(filter.Item))
            query = query.Where(p => p.Item.Contains(filter.Item));

        if (!filter.IncludeInactive)
            query = query.Where(p => p.IsActive);

        if (filter.DateFrom.HasValue)
            query = query.Where(p => p.Date >= filter.DateFrom.Value);

        if (filter.DateTo.HasValue)
            query = query.Where(p => p.Date <= filter.DateTo.Value);
        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            query = query.Where(p =>
                p.Supplier.Contains(filter.Search) ||
                p.Item.Contains(filter.Search) ||
                p.Entity.Contains(filter.Search) ||
                p.Budget.ToString().Contains(filter.Search)
            );
        }

        int totalRecords = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        var records = await query
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<ProcurementEntity>
        {
            Records = records,
            Page = page,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            TotalPages = totalPages
        };
    }

    public async Task UpdateAsync(ProcurementEntity procurement)
    {
        _db.Procurements.Update(procurement);
        await _db.SaveChangesAsync();
    }
}
