using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldBestClinic.Migrations
{
    /// <inheritdoc />
    public partial class addOneMoreField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhenYouNeed",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhenYouNeed",
                table: "Service");
        }
    }
}
