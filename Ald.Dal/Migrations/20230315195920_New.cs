using Microsoft.EntityFrameworkCore.Migrations;

namespace Ald.Dal.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationPlanTeacher");

            migrationBuilder.CreateTable(
                name: "TeachingLoads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationPlanId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingLoads_EducationPlans_EducationPlanId",
                        column: x => x.EducationPlanId,
                        principalTable: "EducationPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingLoads_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingLoads_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeachingLoads_EducationPlanId",
                table: "TeachingLoads",
                column: "EducationPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingLoads_GroupId",
                table: "TeachingLoads",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingLoads_TeacherId",
                table: "TeachingLoads",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeachingLoads");

            migrationBuilder.CreateTable(
                name: "EducationPlanTeacher",
                columns: table => new
                {
                    EducationPlansId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationPlanTeacher", x => new { x.EducationPlansId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_EducationPlanTeacher_EducationPlans_EducationPlansId",
                        column: x => x.EducationPlansId,
                        principalTable: "EducationPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationPlanTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationPlanTeacher_TeachersId",
                table: "EducationPlanTeacher",
                column: "TeachersId");
        }
    }
}
