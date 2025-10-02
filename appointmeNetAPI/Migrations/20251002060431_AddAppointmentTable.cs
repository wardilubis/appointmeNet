using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace appointmeNetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaPemohon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmailPemohon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NomorHpPemohon = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NamaProfesor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Hari = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Waktu = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
