using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

[Table("ComponentManufacturers")]
public class ComponentManufactures
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    [MaxLength(300)]
    public string FullName { get; set; } = string.Empty;
    [Column(TypeName = "datetime")]
    public DateTime FoundationDate { get; set; }
    
    public IEnumerable<Component> Components { get; set; } = [];
}