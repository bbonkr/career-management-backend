using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerManagement.Data.SqlServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    Username = table.Column<string>(maxLength: 200, nullable: false, comment: "계정이름"),
                    Name = table.Column<string>(maxLength: 200, nullable: false, comment: "사용자 이름 (출력)"),
                    Email = table.Column<string>(maxLength: 100, nullable: false, comment: "전자우편주소"),
                    ImageUri = table.Column<string>(maxLength: 500, nullable: true, comment: "사용자 이미지 URI")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Career",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    UserId = table.Column<string>(maxLength: 36, nullable: false, comment: "사용자 식별자"),
                    Title = table.Column<string>(maxLength: 2000, nullable: false, comment: "제목; 직장명"),
                    State = table.Column<string>(maxLength: 200, nullable: false, comment: "상태"),
                    Period = table.Column<string>(maxLength: 200, nullable: true, comment: "기간"),
                    Description = table.Column<string>(maxLength: 2000, nullable: true, comment: "설명")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Career", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Career_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    UserId = table.Column<string>(maxLength: 36, nullable: false, comment: "사용자 식별자"),
                    Title = table.Column<string>(maxLength: 200, nullable: false, comment: "제목"),
                    State = table.Column<string>(maxLength: 200, nullable: true, comment: "상태"),
                    Description = table.Column<string>(maxLength: 2000, nullable: true, comment: "설명"),
                    Period = table.Column<string>(maxLength: 200, nullable: true, comment: "기간")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    UserId = table.Column<string>(maxLength: 36, nullable: false, comment: "사용자 식별자"),
                    Title = table.Column<string>(maxLength: 200, nullable: false, comment: "제목"),
                    State = table.Column<string>(maxLength: 200, nullable: false, comment: "상태"),
                    Period = table.Column<string>(maxLength: 200, nullable: true, comment: "기간"),
                    Descriptoin = table.Column<string>(maxLength: 2000, nullable: true, comment: "설명")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolio_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    UserId = table.Column<string>(maxLength: 36, nullable: false, comment: "사용자 식별자"),
                    Bio = table.Column<string>(maxLength: 2000, nullable: false, comment: "상태")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    UserId = table.Column<string>(maxLength: 36, nullable: false, comment: "사용자 식별자"),
                    Icon = table.Column<string>(maxLength: 200, nullable: true, comment: "아이콘")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 36, nullable: false, comment: "사용자 식별자"),
                    Provider = table.Column<string>(maxLength: 200, nullable: false, defaultValue: "Local", comment: "사용자 로그인 제공자"),
                    Secret = table.Column<string>(maxLength: 2000, nullable: false, comment: "비밀키; 비밀번호 해시"),
                    ExpiredAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 7, 13, 4, 20, 58, 230, DateTimeKind.Unspecified).AddTicks(7648), new TimeSpan(0, 0, 0, 0, 0)), comment: "만료시각"),
                    RetryCount = table.Column<int>(nullable: false, defaultValue: 0, comment: "로그인 재시도 횟수"),
                    IsLocked = table.Column<bool>(nullable: false, defaultValue: false, comment: "로그인 잠김"),
                    LockedAt = table.Column<DateTimeOffset>(nullable: true, comment: "로그인 잠김 시각")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CareerLink",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    Title = table.Column<string>(maxLength: 200, nullable: false, comment: "링크 제목"),
                    Icon = table.Column<string>(maxLength: 200, nullable: true, comment: "아이콘"),
                    Href = table.Column<string>(maxLength: 500, nullable: false, comment: "링크 주소"),
                    Target = table.Column<string>(maxLength: 200, nullable: true, comment: "링크 대상"),
                    CareerId = table.Column<string>(maxLength: 36, nullable: false, comment: "경력 식별자")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareerLink_Career_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Career",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationLink",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    Title = table.Column<string>(maxLength: 200, nullable: false, comment: "링크 제목"),
                    Icon = table.Column<string>(maxLength: 200, nullable: true, comment: "아이콘"),
                    Href = table.Column<string>(maxLength: 500, nullable: false, comment: "링크 주소"),
                    Target = table.Column<string>(maxLength: 200, nullable: true, comment: "링크 대상"),
                    EducationId = table.Column<string>(maxLength: 36, nullable: false, comment: "교육 식별자")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationLink_Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioFeature",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    PortfolioId = table.Column<string>(maxLength: 36, nullable: false, comment: "포트폴리오 식별자"),
                    Content = table.Column<string>(maxLength: 2000, nullable: false, comment: "내용")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioFeature_Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioLink",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    Title = table.Column<string>(maxLength: 200, nullable: false, comment: "링크 제목"),
                    Icon = table.Column<string>(maxLength: 200, nullable: true, comment: "아이콘"),
                    Href = table.Column<string>(maxLength: 500, nullable: false, comment: "링크 주소"),
                    Target = table.Column<string>(maxLength: 200, nullable: true, comment: "링크 대상"),
                    PortfolioId = table.Column<string>(maxLength: 36, nullable: false, comment: "포트폴리오 식별자")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioLink_Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioTag",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    PortfolioId = table.Column<string>(maxLength: 36, nullable: false, comment: "포트폴리오 식별자"),
                    Name = table.Column<string>(maxLength: 200, nullable: false, comment: "태그")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioTag_Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileLink",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    Title = table.Column<string>(maxLength: 200, nullable: false, comment: "링크 제목"),
                    Icon = table.Column<string>(maxLength: 200, nullable: true, comment: "아이콘"),
                    Href = table.Column<string>(maxLength: 500, nullable: false, comment: "링크 주소"),
                    Target = table.Column<string>(maxLength: 200, nullable: true, comment: "링크 대상"),
                    ProfileId = table.Column<string>(maxLength: 36, nullable: false, comment: "프로필 식별자")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileLink_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillItem",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false, comment: "식별자"),
                    SkillId = table.Column<string>(maxLength: 36, nullable: false, comment: "기술 식별자"),
                    Name = table.Column<string>(maxLength: 200, nullable: false, comment: "이름"),
                    Score = table.Column<float>(nullable: false, defaultValue: 0f, comment: "점수")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillItem_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Career_UserId",
                table: "Career",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CareerLink_CareerId",
                table: "CareerLink",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_UserId",
                table: "Education",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLink_EducationId",
                table: "EducationLink",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_UserId",
                table: "Portfolio",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioFeature_PortfolioId",
                table: "PortfolioFeature",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLink_PortfolioId",
                table: "PortfolioLink",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioTag_PortfolioId",
                table: "PortfolioTag",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                table: "Profile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLink_ProfileId",
                table: "ProfileLink",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_UserId",
                table: "Skill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillItem_SkillId",
                table: "SkillItem",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerLink");

            migrationBuilder.DropTable(
                name: "EducationLink");

            migrationBuilder.DropTable(
                name: "PortfolioFeature");

            migrationBuilder.DropTable(
                name: "PortfolioLink");

            migrationBuilder.DropTable(
                name: "PortfolioTag");

            migrationBuilder.DropTable(
                name: "ProfileLink");

            migrationBuilder.DropTable(
                name: "SkillItem");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
