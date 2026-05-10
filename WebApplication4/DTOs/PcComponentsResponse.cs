using WebApplication4.Models;

namespace WebApplication4.DTOs;

public record PcComponentsResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<ComponentsResponse> Components
);