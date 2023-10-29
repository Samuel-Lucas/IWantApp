using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "Employee005Policy")]
    public static async Task<IResult> Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {
        if (page is null || rows is null)
            return Results.BadRequest("Valores de pagina e/ou linhas não foram preenchidos para a requisição");
        
        if (page <= 0 || rows <= 0)
            return Results.BadRequest("Valores de pagina e/ou linhas não foram preenchidos com numeros naturais maior que zero");

        var result = await query.Execute(page!.Value, rows!.Value);
        return Results.Ok();
    }
}