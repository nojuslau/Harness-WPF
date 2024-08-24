using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harness_WPF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Harness_drawing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Harness = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Harness_version = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Drawing = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Drawing_version = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harness_drawing", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Harness_wires",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Harness_ID = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Housing_1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Housing_2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harness_wires", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Harness_drawing_ID",
                table: "Harness_drawing",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Harness_wires_ID",
                table: "Harness_wires",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harness_drawing");

            migrationBuilder.DropTable(
                name: "Harness_wires");
        }
    }
}
