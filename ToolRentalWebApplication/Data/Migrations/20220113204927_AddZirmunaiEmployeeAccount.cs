using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace ToolRentalWebApplication.Data.Migrations
{
    public partial class AddZirmunaiEmployeeAccount : Migration
    {
        const string EMPLOYEE_USER_GUID = "9380f4cc-04a5-4009-bfb8-03ae3918cf2e";
        const string EMPLOYEE_ROLE_GUID = "3ab1cbb1-1857-45cd-9eea-46a61d921f69";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, "Zirmunai999+");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp,FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{EMPLOYEE_USER_GUID}'");
            sb.AppendLine(",'zirmunai@gmail.com'");
            sb.AppendLine(",'ZIRMUNAI@GMAIL.COM'");
            sb.AppendLine(",'zirmunai@gmail.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'ZIRMUNAI@GMAIL.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(",'Employee'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{EMPLOYEE_ROLE_GUID}','Employee','EMPLOYEE')");

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
