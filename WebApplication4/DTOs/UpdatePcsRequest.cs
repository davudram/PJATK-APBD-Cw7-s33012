namespace WebApplication4.DTOs;

public record UpdatePcsRequest(
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);    

    
