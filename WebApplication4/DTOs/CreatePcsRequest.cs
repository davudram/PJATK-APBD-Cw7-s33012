using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DTOs;

public record CreatePcsRequest (
    [MaxLength(50)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);