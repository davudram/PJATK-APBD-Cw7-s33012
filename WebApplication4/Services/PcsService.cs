using Microsoft.EntityFrameworkCore;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Infrastructure;
using WebApplication4.Models;

namespace WebApplication4.Services;

public class PcsService(AppDbContext db) : IPcsService
{
    public async Task<IEnumerable<PcsResponse>> GetPcs(CancellationToken ct)
    {
        return await db.Pc.Select(opt => new PcsResponse(
                opt.Id,
                opt.Name,
                opt.Weight,
                opt.Warranty,
                opt.CreatedAt,
                opt.Stock
            )).ToListAsync(ct);
    }

    public async Task<IEnumerable<PcComponentsResponse>> GetPcComponents(int id, CancellationToken ct)
    {
        var comp = db.Pc.FirstOrDefaultAsync(x => x.Id == id, ct);
        
        if (comp is null)
            throw new NotFoundException($"Pcs with {id} id not found");
        
        return await db.PcComponent.Where(x => x.PcId == id)
            .Select(opt => new PcComponentsResponse(
                opt.ComponentCode,
                opt.Component.Name,
                opt.Component.Description,
                opt.Amount,
                opt.Component.ComponentManufacturers.FullName,
                opt.Component.ComponentTypes.Name
            )).ToListAsync(ct);
    }

    public async Task<PcsResponse> CreatePcs(CreatePcsRequest request, CancellationToken ct)
    {
        var pc = new Pc
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };
        
        db.Add(pc);
        await db.SaveChangesAsync(ct);
        
        return new PcsResponse(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdatePcs(int id, UpdatePcsRequest request, CancellationToken ct)
    {
        var affectedRows = await db.Pc.Where(x => x.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(x => x.Name, request.Name)
                .SetProperty(x => x.Weight, request.Weight)
                .SetProperty(x => x.Warranty, request.Warranty)
                .SetProperty(x => x.CreatedAt, request.CreatedAt)
                .SetProperty(x => x.Stock, request.Stock),
                ct
            );
        
        if (affectedRows == 0)
            throw new NotFoundException($"Pcs with {id} id not found");
    }

    public async Task DeletePcs(int id, CancellationToken ct)
    {
        int affectedRows = await db.Pc.Where(x => x.Id == id)
            .ExecuteDeleteAsync(ct);
        
        if (affectedRows == 0)
            throw new NotFoundException($"Pcs with {id} id not found");
    }
}