namespace CodexMVCProject.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Quantity { get; set; } 
    public int Amount { get; set; }
    public DateTime Date { get; set; }

}
