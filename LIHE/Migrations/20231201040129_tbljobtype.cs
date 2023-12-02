using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIHE.Migrations
{
    /// <inheritdoc />
    public partial class tbljobtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "academic",
                table: "tbldeptmast",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "department_email",
                schema: "academic",
                table: "tbldeptmast",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "tbljobtype",
                schema: "academic",
                columns: table => new
                {
                    transid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    jobtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jobsname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbljobtype", x => x.transid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbljobtype",
                schema: "academic");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "academic",
                table: "tbldeptmast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "department_email",
                schema: "academic",
                table: "tbldeptmast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
