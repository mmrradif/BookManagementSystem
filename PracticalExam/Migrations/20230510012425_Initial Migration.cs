using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalExam.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBook", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblBook",
                columns: new[] { "Id", "Author", "BookName", "Date", "Quantity" },
                values: new object[,]
                {
                    { 1, "G B Shaw", "Man and Superman", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Franz Kalka", "The Castle", new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Guy the Manupassaul", "A Woman's Life", new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Jibanananda Das", "Bela Obela Kolbela", new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "Julian Barnes", "The Sense of an Ending", new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBook");
        }
    }
}
