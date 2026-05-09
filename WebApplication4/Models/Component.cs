using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("Components")]
public class Component
{
    [Key]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }
    
    [ForeignKey("ComponentManufacturersId")]
    public ComponentManufactures ComponentManufacturers { get; set; } = null!;
    [ForeignKey("ComponentTypesId")] 
    public ComponentTypes ComponentTypes { get; set; } = null!;
    
    public IEnumerable<PcComponent> PcComponents { get; set; } = [];
}