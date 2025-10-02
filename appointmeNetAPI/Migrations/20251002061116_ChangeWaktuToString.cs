using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appointmeNetAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWaktuToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Waktu",
                table: "Appointments",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Waktu",
                table: "Appointments",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5);
        }
    }
}
