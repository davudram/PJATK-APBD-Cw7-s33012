using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

[Table("ComponentTypes")]
public class ComponentTypes
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    [MaxLength(150)]
    public string Name { get; set; } =  string.Empty;
    
    public IEnumerable<Component> Components { get; set; } = [];
}