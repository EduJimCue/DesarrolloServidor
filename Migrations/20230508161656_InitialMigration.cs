using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prueba.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymLesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GimnasioId = table.Column<int>(type: "int", nullable: false),
                    LeccionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymLesson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthPrice = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    Minute = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<bool>(type: "bit", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioLesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeccionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioLesson", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GymLesson",
                columns: new[] { "Id", "GimnasioId", "LeccionId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Address", "Description", "MonthPrice", "Name", "SignUpDate" },
                values: new object[,]
                {
                    { 1, "Calle Julian Sanz Ibañez", "Gimnasio especializado en karate", 40, "Sankukai", new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9353) },
                    { 2, "Paseo Calanda", "Gimnasio especializado en artes marciales mixtas", 30, "Strong Fist", new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9358) },
                    { 3, "Avenida Navarra", "Gimnasio con multiples clases y salas de pesas", 50, "Gimnasio Delicias", new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9360) }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Capacity", "Description", "Hour", "Minute", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, 35, "Clase de karate para gente sin experiencia", 20, 30, "Karate principiantes", 2 },
                    { 2, 35, "Clase de karate para gente que lleva un tiempo practicando karate", 21, 30, "Karate avanzado", 2 },
                    { 3, 20, "Arte marcial tailandesa que se especializa en codos y rodillas", 17, 30, "Muay Thai", 2 },
                    { 4, 50, "Clase de zumba para todos los niveles", 20, 0, "Zumba", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Admin", "Name", "Password", "Role", "SignUpDate", "Username" },
                values: new object[,]
                {
                    { 1, true, "admin", "admin", true, new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9161), "admin" },
                    { 2, true, "teacher", "1111", true, new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9194), "teacher" }
                });

            migrationBuilder.InsertData(
                table: "UsuarioLesson",
                columns: new[] { "Id", "LeccionId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 2 },
                    { 3, 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymLesson");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsuarioLesson");
        }
    }
}
