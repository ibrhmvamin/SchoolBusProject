﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolBusDataAccess.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Parents_UserName",
                table: "Parents",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parents_UserName",
                table: "Parents");
        }
    }
}
