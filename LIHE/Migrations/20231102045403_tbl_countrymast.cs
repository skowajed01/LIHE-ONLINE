using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIHE.Migrations
{
    /// <inheritdoc />
    public partial class tbl_countrymast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_countrymast",
                columns: table => new
                {
                    transid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    countryname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationalityname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    callingcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rcm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    luo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sts = table.Column<int>(type: "int", nullable: false),
                    delstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_countrymast", x => x.transid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_countrymast");
        }
    }
}
