using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class InitialMigrationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDifficulties_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalkDifficultyId",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDifficulties_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId",
                principalTable: "WalkDifficulties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDifficulties_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalkDifficultyId",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDifficulties_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId",
                principalTable: "WalkDifficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
