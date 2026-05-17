using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DTOs;

public record UpdatePcsRequest(
    [MaxLength(50)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);    

    
