using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldBestClinic.Migrations
{
    /// <inheritdoc />
    public partial class addFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLab",
                table: "Service",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLab",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Service");
        }
    }
}
