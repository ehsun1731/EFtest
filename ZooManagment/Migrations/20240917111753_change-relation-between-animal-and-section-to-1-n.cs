using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagment.Migrations
{
    /// <inheritdoc />
    public partial class changerelationbetweenanimalandsectionto1n : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Sections_SectionId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_SectionId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_AnimalId",
                table: "Sections",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Animals_AnimalId",
                table: "Sections",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Animals_AnimalId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_AnimalId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SectionId",
                table: "Animals",
                column: "SectionId",
                unique: true,
                filter: "[SectionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Sections_SectionId",
                table: "Animals",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");
        }
    }
}
