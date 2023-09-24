using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints.Employees;

public class EmployeePost
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(EmployeeRequest employeeRequest, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser { UserName = employeeRequest.Email, Email = employeeRequest.Email };
        var result = userManager.CreateAsync(user, employeeRequest.Password).Result;

        if (!result.Succeeded)
            return Results.BadRequest(result.Errors.First());
        
        var claimResult = userManager.AddClaimAsync(user, new Claim("EmployeeCode", employeeRequest.EmployeeCode)).Result;

        if (!claimResult.Succeeded)
            return Results.BadRequest(result.Errors.First());

        claimResult = userManager.AddClaimAsync(user, new Claim("Name", employeeRequest.Name)).Result;

        if (!claimResult.Succeeded)
            return Results.BadRequest(result.Errors.First());
        
        return Results.Created($"/employee/{user.Id}", user.Id);
    }
}