using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class updatePetsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_OwnedById",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_OwnedById",
                table: "Pets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnedById",
                table: "Pets",
                column: "OwnedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_OwnedById",
                table: "Pets",
                column: "OwnedById",
                principalTable: "PetOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
