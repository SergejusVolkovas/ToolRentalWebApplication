using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace ToolRentalWebApplication.Data.Migrations
{
    public partial class AddKaroliniskesEmployeeAccount : Migration
    {
        const string EMPLOYEE_USER_GUID = "4f27fe85-3c0f-4950-a1e7-34c4febee47c";
        const string EMPLOYEE_ROLE_GUID = "35f1fc5b-f898-4630-8829-b53df974c8ac";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, "Karoliniskes999+");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp,FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{EMPLOYEE_USER_GUID}'");
            sb.AppendLine(",'karoliniskes@gmail.com'");
            sb.AppendLine(",'KAROLINISKES@GMAIL.COM'");
            sb.AppendLine(",'karoliniskes@gmail.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'KAROLINISKES@GMAIL.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(",'Employee'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{EMPLOYEE_ROLE_GUID}','Employee','EMPLOYEEKAROLINISKES')");

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
