namespace IWantApp.Endpoints.Categories;

public class CategoryRequest
{
    public string Name { get; set; } = null!;
    public bool Active { get; set; }
}