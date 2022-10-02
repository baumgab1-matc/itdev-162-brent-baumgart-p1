namespace Domain;

public class Grad 
{
    public int Id { get; set; }
    
    public string UserName { get; set; } = string.Empty;
    public virtual IList<Item> ?Items { get; set; }

}