using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Endpoints.Products;

public class ProductGetById
{
    public static string Template = "/products/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action([FromRoute]Guid id, ApplicationDbContext context)
    {
        var product = await context.Products.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefaultAsync();
        var productResponse = new ProductResponse(product!.Name, product.Category.Name, product.Description, product.Price, product.HasStock, product.Active);
        
        return Results.Ok(productResponse);
    }
}