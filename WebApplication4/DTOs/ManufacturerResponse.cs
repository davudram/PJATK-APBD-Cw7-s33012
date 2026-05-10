namespace WebApplication4.DTOs;

public record ManufacturerResponse(
    int Id,
    string Abbreviation,
    string FullName,
    DateTime FoundationDate
);    