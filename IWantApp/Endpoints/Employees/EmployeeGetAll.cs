using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    public const string Query = @"SELECT Email, ClaimValue as Name
                                    FROM AspNetUsers u INNER JOIN AspNetUserClaims c ON u.Id = c.UserId
                                    AND ClaimType = 'Name'
                                    ORDER BY Name
                                    OFFSET ((@page - 1) * @rows) ROWS FETCH NEXT @rows ROWS ONLY";

    public static IResult Action(int page, int rows, IConfiguration configuration)
    {
        var db = new SqlConnection(configuration["ConnectionStrings:SqlServer"]);
        var employees = db.Query<EmployeeResponse>(
            Query,
            new { page, rows });

        return Results.Ok(employees);
    }
}