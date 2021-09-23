using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class petOwnerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_OwnedById",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "OwnedById",
                table: "Pets",
                newName: "petOwnerid");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_OwnedById",
                table: "Pets",
                newName: "IX_Pets_petOwnerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets",
                column: "petOwnerid",
                principalTable: "PetOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "petOwnerid",
                table: "Pets",
                newName: "OwnedById");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets",
                newName: "IX_Pets_OwnedById");

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
