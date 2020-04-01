using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerManagement.Data.SqlServer.Migrations
{
    public partial class Add_Period : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredAt",
                table: "UserLogin",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 7, 21, 27, 100, DateTimeKind.Unspecified).AddTicks(3138), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "만료시각",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 6, 45, 56, 104, DateTimeKind.Unspecified).AddTicks(9544), new TimeSpan(0, 0, 0, 0, 0)),
                oldComment: "만료시각");

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "Education",
                maxLength: 200,
                nullable: true,
                comment: "기간");

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "Career",
                maxLength: 200,
                nullable: true,
                comment: "기간");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Career");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredAt",
                table: "UserLogin",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 6, 45, 56, 104, DateTimeKind.Unspecified).AddTicks(9544), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "만료시각",
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 7, 21, 27, 100, DateTimeKind.Unspecified).AddTicks(3138), new TimeSpan(0, 0, 0, 0, 0)),
                oldComment: "만료시각");
        }
    }
}
