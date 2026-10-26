using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditForm.Migrations
{
    /// <inheritdoc />
    public partial class singleform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentAmount",
                table: "Fraud");

            migrationBuilder.DropColumn(
                name: "CurrentNumber",
                table: "Fraud");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Fraud");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Fraud",
                newName: "OccurredOn");

            migrationBuilder.RenameColumn(
                name: "RecoveredNumber",
                table: "Fraud",
                newName: "RecoveredCount");

            migrationBuilder.RenameColumn(
                name: "PreviousNumber",
                table: "Fraud",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "PreviousAmount",
                table: "Fraud",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fraud",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportedBy",
                table: "Fraud",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Fraud",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fraud");

            migrationBuilder.DropColumn(
                name: "ReportedBy",
                table: "Fraud");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Fraud");

            migrationBuilder.RenameColumn(
                name: "RecoveredCount",
                table: "Fraud",
                newName: "RecoveredNumber");

            migrationBuilder.RenameColumn(
                name: "OccurredOn",
                table: "Fraud",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Fraud",
                newName: "PreviousNumber");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Fraud",
                newName: "PreviousAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentAmount",
                table: "Fraud",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CurrentNumber",
                table: "Fraud",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Fraud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
