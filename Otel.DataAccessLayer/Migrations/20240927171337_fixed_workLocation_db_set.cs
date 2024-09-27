﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otel.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixed_workLocation_db_set : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocation_WorkLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkLocation",
                table: "WorkLocation");

            migrationBuilder.RenameTable(
                name: "WorkLocation",
                newName: "WorkLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkLocations",
                table: "WorkLocations",
                column: "WorkLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationId",
                table: "AspNetUsers",
                column: "WorkLocationId",
                principalTable: "WorkLocations",
                principalColumn: "WorkLocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkLocations",
                table: "WorkLocations");

            migrationBuilder.RenameTable(
                name: "WorkLocations",
                newName: "WorkLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkLocation",
                table: "WorkLocation",
                column: "WorkLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocation_WorkLocationId",
                table: "AspNetUsers",
                column: "WorkLocationId",
                principalTable: "WorkLocation",
                principalColumn: "WorkLocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
