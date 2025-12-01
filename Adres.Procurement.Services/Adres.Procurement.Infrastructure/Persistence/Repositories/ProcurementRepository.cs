namespace Adres.Procurement.Infrastructure.Persistence.Repositories;

using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using Adres.Procurement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    public async Task UpdateAsync(ProcurementEntity procurement)
    {
        _db.Procurements.Update(procurement);
        await _db.SaveChangesAsync();
    }
}
