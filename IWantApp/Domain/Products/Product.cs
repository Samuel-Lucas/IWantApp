namespace IWantApp.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; private set; }
    public bool HasStock { get; set; }
    public bool Active { get; set; } = true;

    private Product() { }

    public Product(string name, Category category, string description, decimal price, bool hasStock, string createdBy)
    {
        Name = name;
        Category = category;
        Description = description;
        Price = price;
        HasStock = hasStock;

        CreatedBy = createdBy;
        EditedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Flunt.Validations.Contract<Product>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name")
            .IsNotNull(Category, "Category", "Category not found")
            .IsNotNullOrEmpty(Description, "Description")
            .IsGreaterOrEqualsThan(Description, 3, "Description")
            .IsGreaterOrEqualsThan(Price, 1, "Price")
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
            .IsNotNullOrEmpty(EditedBy, "EditedBy");
        AddNotifications(contract);
    }
}