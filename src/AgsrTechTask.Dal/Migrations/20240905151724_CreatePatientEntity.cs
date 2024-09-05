using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgsrTechTask.Dal.Migrations
{
    public partial class CreatePatientEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    patronymic_name = table.Column<string>(type: "text", nullable: true),
                    formality = table.Column<byte>(type: "smallint", nullable: true),
                    gender = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)0),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
