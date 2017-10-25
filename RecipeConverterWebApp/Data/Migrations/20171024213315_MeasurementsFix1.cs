using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RecipeConverterWebApp.Data.Migrations
{
    public partial class MeasurementsFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Measurement_MeasurementID",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement");

            migrationBuilder.RenameTable(
                name: "Measurement",
                newName: "Measurements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Measurements_MeasurementID",
                table: "Ingredients",
                column: "MeasurementID",
                principalTable: "Measurements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Measurements_MeasurementID",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements");

            migrationBuilder.RenameTable(
                name: "Measurements",
                newName: "Measurement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Measurement_MeasurementID",
                table: "Ingredients",
                column: "MeasurementID",
                principalTable: "Measurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
