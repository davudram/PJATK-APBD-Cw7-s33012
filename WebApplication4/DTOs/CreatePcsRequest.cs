namespace WebApplication4.DTOs;

public record CreatePcsRequest (
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);