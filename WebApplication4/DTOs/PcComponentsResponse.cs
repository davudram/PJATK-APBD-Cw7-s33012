using WebApplication4.Models;

namespace WebApplication4.DTOs;

public record PcComponentsResponse(
    string ComponentCode,
    string Name,
    string Description,
    int Amount,
    string Manufacturer,
    string ComponentType
);