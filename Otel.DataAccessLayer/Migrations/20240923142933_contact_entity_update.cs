using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otel.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class contact_entity_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReplied",
                table: "Contacts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "Contacts",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseMessage",
                table: "Contacts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReplied",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ResponseMessage",
                table: "Contacts");
        }
    }
}
