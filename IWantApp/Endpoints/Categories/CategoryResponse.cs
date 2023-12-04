namespace IWantApp.Endpoints.Categories;

public record CategoryResponse()
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool Active { get; set; }
}