using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services;

public interface IPcsService
{
    public Task<IEnumerable<PcsResponse>> GetPcs(CancellationToken ct);
    public Task<IEnumerable<PcComponentsResponse>> GetPcComponents(int id, CancellationToken ct);
    public Task<PcsResponse> CreatePcs(CreatePcsRequest request, CancellationToken ct);
    public Task UpdatePcs(int id, UpdatePcsRequest request, CancellationToken ct);
    public Task DeletePcs(int id, CancellationToken ct);
}