namespace IWantApp.Domain.Products;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public string EditedBy { get; set; } = null!;
    public DateTime EditedOn { get; set; }
}