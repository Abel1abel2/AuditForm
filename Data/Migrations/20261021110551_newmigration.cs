using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditForm.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fraud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FraudType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousNumber = table.Column<int>(type: "int", nullable: false),
                    PreviousAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentNumber = table.Column<int>(type: "int", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecoveredNumber = table.Column<int>(type: "int", nullable: false),
                    RecoveredAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutstandingNumber = table.Column<int>(type: "int", nullable: false),
                    OutstandingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fraud", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fraud");
        }
    }
}
