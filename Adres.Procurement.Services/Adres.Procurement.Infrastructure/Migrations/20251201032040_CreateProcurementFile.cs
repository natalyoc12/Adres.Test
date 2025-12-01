using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adres.Procurement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateProcurementFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Files",
                table: "Procurements");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Procurements",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.CreateTable(
                name: "ProcurementFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcurementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcurementFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcurementFiles_Procurements_ProcurementId",
                        column: x => x.ProcurementId,
                        principalTable: "Procurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcurementFiles_ProcurementId",
                table: "ProcurementFiles",
                column: "ProcurementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcurementFiles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Procurements");

            migrationBuilder.AddColumn<string>(
                name: "Files",
                table: "Procurements",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }
    }
}
