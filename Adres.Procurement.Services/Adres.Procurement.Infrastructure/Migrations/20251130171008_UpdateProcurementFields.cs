using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adres.Procurement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProcurementFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Procurements",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Procurements");
        }
    }
}
