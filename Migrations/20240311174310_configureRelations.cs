﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emprestimos_Livros.Migrations
{
    public partial class configureRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Usuarios_UsuarioId",
                table: "Livros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Usuarios_UsuarioId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Livros");
        }
    }
}
