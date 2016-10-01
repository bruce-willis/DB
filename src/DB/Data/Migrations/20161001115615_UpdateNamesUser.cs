using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Data.Migrations
{
    public partial class UpdateNamesUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DealerId",
                table: "AspNetUsers",
                newName: "DealerID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "AspNetUsers",
                newName: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DealerID",
                table: "AspNetUsers",
                newName: "DealerId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "AspNetUsers",
                newName: "CustomerId");
        }
    }
}
