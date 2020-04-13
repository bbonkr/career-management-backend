using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerManagement.Data.SqlServer.Migrations
{
    public partial class AddNameOnSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredAt",
                table: "UserLogin",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 7, 13, 6, 6, 26, 558, DateTimeKind.Unspecified).AddTicks(5269), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "만료시각",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 7, 13, 6, 0, 48, 312, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 0, 0, 0, 0)),
                oldComment: "만료시각");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Skill",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "명칭");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Skill");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredAt",
                table: "UserLogin",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 7, 13, 6, 0, 48, 312, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "만료시각",
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 7, 13, 6, 6, 26, 558, DateTimeKind.Unspecified).AddTicks(5269), new TimeSpan(0, 0, 0, 0, 0)),
                oldComment: "만료시각");
        }
    }
}
