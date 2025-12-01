namespace Adres.Procurement.Infrastructure.Persistence.Repositories;

using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using Adres.Procurement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProcurementFileRepository(AppDbContext db) : IProcurementFileRepository
{
    private readonly AppDbContext _db = db;

    public async Task<ProcurementFileEntity?> GetFile(Guid procurementId, Guid fileId)
    {
        return await _db.ProcurementFiles
            .Where(f => f.ProcurementId == procurementId && f.Id == fileId)
            .FirstOrDefaultAsync();
    }
}
