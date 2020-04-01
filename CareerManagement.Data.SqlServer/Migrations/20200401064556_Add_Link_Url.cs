using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerManagement.Data.SqlServer.Migrations
{
    public partial class Add_Link_Url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredAt",
                table: "UserLogin",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 6, 45, 56, 104, DateTimeKind.Unspecified).AddTicks(9544), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "만료시각",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 6, 29, 6, 44, 43, 106, DateTimeKind.Unspecified).AddTicks(4508), new TimeSpan(0, 0, 0, 0, 0)),
                oldComment: "만료시각");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Link",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "링크 URL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Link");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredAt",
                table: "UserLogin",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 6, 29, 6, 44, 43, 106, DateTimeKind.Unspecified).AddTicks(4508), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "만료시각",
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 7, 1, 6, 45, 56, 104, DateTimeKind.Unspecified).AddTicks(9544), new TimeSpan(0, 0, 0, 0, 0)),
                oldComment: "만료시각");
        }
    }
}
