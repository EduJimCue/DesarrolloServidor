using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Users_TeacherId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLesson_LeccionId",
                table: "UsuarioLesson",
                column: "LeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLesson_UsuarioId",
                table: "UsuarioLesson",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioLesson_Lessons_LeccionId",
                table: "UsuarioLesson",
                column: "LeccionId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioLesson_Users_UsuarioId",
                table: "UsuarioLesson",
                column: "UsuarioId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioLesson_Lessons_LeccionId",
                table: "UsuarioLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioLesson_Users_UsuarioId",
                table: "UsuarioLesson");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioLesson_LeccionId",
                table: "UsuarioLesson");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioLesson_UsuarioId",
                table: "UsuarioLesson");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Users_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
