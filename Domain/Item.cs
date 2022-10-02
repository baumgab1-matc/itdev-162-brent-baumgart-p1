using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Item 
{
    public int Id { get; set; }

    [ForeignKey(nameof(GradId))]
    public int GradId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public double Price { get; set; } 
    
}