namespace IWantApp.Domain.Products;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool HasStock { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public string EditedBy { get; set; } = null!;
    public DateTime EditedOn { get; set; }
}