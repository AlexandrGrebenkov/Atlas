using Microsoft.EntityFrameworkCore.Migrations;

namespace Atlas.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RacingClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacingClasses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RacingClasses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "PROD-32" });

            migrationBuilder.InsertData(
                table: "RacingClasses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, null, "PROD-24" });

            migrationBuilder.InsertData(
                table: "RacingClasses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Чайник", "ES-24U" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RacingClasses");
        }
    }
}
