namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; } = null!;
    public bool Active { get; set; } = true;
}