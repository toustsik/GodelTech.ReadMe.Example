using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GodelTech.ReadMe.Example.Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrecipitationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecipitationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Precipitations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Town = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    PrecipitationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precipitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Precipitations_PrecipitationTypes_PrecipitationTypeId",
                        column: x => x.PrecipitationTypeId,
                        principalTable: "PrecipitationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PrecipitationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Rain" });

            migrationBuilder.InsertData(
                table: "PrecipitationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Snow" });

            migrationBuilder.InsertData(
                table: "PrecipitationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Hail" });

            migrationBuilder.InsertData(
                table: "Precipitations",
                columns: new[] { "Id", "DateTime", "PrecipitationTypeId", "Summary", "Temperature", "Town" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hot", 32, "Grodno" },
                    { 2, new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ok", 28, "London" },
                    { 3, new DateTime(2020, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Where is summer?", 20, "Venezia" },
                    { 4, new DateTime(2019, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cold", 15, "Barselona" },
                    { 5, new DateTime(2018, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Not bad", 26, "Minsk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Precipitations_PrecipitationTypeId",
                table: "Precipitations",
                column: "PrecipitationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Precipitations");

            migrationBuilder.DropTable(
                name: "PrecipitationTypes");
        }
    }
}
