using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("PCComponents"), PrimaryKey(nameof(PcId), nameof(ComponentCode))]
public class PcComponent
{
    public int PcId { get; set; }
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;
    public int Amount { get; set; }
    
    [ForeignKey("PcId")]
    public Pc Pc { get; set; } = null!;
    [ForeignKey("ComponentCode")] 
    public Component Component { get; set; } = null!;
}