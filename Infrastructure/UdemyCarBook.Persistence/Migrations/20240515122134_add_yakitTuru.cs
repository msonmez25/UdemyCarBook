using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_yakitTuru : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YakitTuruID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "YakitTurus",
                columns: table => new
                {
                    YakitTuruID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YakitTurus", x => x.YakitTuruID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_YakitTuruID",
                table: "Cars",
                column: "YakitTuruID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_YakitTurus_YakitTuruID",
                table: "Cars",
                column: "YakitTuruID",
                principalTable: "YakitTurus",
                principalColumn: "YakitTuruID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_YakitTurus_YakitTuruID",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "YakitTurus");

            migrationBuilder.DropIndex(
                name: "IX_Cars_YakitTuruID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "YakitTuruID",
                table: "Cars");
        }
    }
}
