namespace IWantApp.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool HasStock { get; set; }
    public bool Active { get; set; } = true;
}