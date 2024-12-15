using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Women_Empowerment.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnsInNGO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationId",
                table: "NGOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "NGOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationId",
                table: "NGOs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "NGOs");
        }
    }
}
