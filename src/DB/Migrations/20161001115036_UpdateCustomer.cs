using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class UpdateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Customer",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Customer",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Customer",
                nullable: false);
        }
    }
}
