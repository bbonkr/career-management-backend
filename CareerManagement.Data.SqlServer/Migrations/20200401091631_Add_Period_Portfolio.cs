using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerManagement.Data.SqlServer.Migrations
{
    public partial class Add_Period_Portfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredAt",
                table: "UserLogin",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 9, 16, 31, 79, DateTimeKind.Unspecified).AddTicks(8848), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "만료시각",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 7, 21, 27, 100, DateTimeKind.Unspecified).AddTicks(3138), new TimeSpan(0, 0, 0, 0, 0)),
                oldComment: "만료시각");

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "Portfolio",
                maxLength: 200,
                nullable: true,
                comment: "기간");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "Portfolio");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredAt",
                table: "UserLogin",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 7, 21, 27, 100, DateTimeKind.Unspecified).AddTicks(3138), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "만료시각",
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 9, 16, 31, 79, DateTimeKind.Unspecified).AddTicks(8848), new TimeSpan(0, 0, 0, 0, 0)),
                oldComment: "만료시각");
        }
    }
}
