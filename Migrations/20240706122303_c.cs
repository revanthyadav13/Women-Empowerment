using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Women_Empowerment.Migrations
{
    /// <inheritdoc />
    public partial class c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_NGOs_NGOId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_NGOId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "NGOId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Trainees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NGOId",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Trainees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_NGOId",
                table: "Trainees",
                column: "NGOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_NGOs_NGOId",
                table: "Trainees",
                column: "NGOId",
                principalTable: "NGOs",
                principalColumn: "NGOId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
