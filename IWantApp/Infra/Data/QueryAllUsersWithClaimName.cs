using Dapper;
using IWantApp.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace IWantApp.Infra.Data;

public class QueryAllUsersWithClaimName
{
    public IConfiguration _configuration { get; }
    public const string Query = @"SELECT Email, ClaimValue as Name
                                FROM AspNetUsers u INNER JOIN AspNetUserClaims c ON u.Id = c.UserId
                                AND ClaimType = 'Name'
                                ORDER BY Name
                                OFFSET ((@page - 1) * @rows) ROWS FETCH NEXT @rows ROWS ONLY";

    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<EmployeeResponse> Execute(int? page, int? rows)
    {
        var db = new SqlConnection(_configuration["ConnectionStrings:SqlServer"]);
        return db.Query<EmployeeResponse>(
            Query,
            new { page, rows });
    }
}