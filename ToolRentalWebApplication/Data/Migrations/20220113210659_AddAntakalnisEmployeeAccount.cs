using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace ToolRentalWebApplication.Data.Migrations
{
    public partial class AddAntakalnisEmployeeAccount : Migration
    {
        const string EMPLOYEE_USER_GUID = "6e2d2ed4-fb40-4f65-b4a1-a3dad57be05f";
        const string EMPLOYEE_ROLE_GUID = "39640fa2-aa65-4b7c-bd91-efb63c72b404";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, "Antakalnis999+");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp,FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{EMPLOYEE_USER_GUID}'");
            sb.AppendLine(",'antakalnis@gmail.com'");
            sb.AppendLine(",'ANTAKALNIS@GMAIL.COM'");
            sb.AppendLine(",'antakalnis@gmail.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'ANTAKALNIS@GMAIL.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(",'Employee'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{EMPLOYEE_ROLE_GUID}','Employee','EMPLOYEEANTAKALNIS')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{EMPLOYEE_USER_GUID}','{EMPLOYEE_ROLE_GUID}')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{EMPLOYEE_USER_GUID}' AND RoleId = '{EMPLOYEE_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{EMPLOYEE_USER_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{EMPLOYEE_ROLE_GUID}'");

        }
    }
}
