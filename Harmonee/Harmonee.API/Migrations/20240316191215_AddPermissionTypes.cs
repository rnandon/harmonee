using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harmonee.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionType",
                table: "GroupMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionType",
                table: "GroupMembers");
        }
    }
}
