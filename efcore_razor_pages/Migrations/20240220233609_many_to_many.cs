using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcore_razor_pages.Migrations
{
    /// <inheritdoc />
    public partial class many_to_many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Xuesheng",
                columns: table => new
                {
                    XueshengId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XueshengName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Xuesheng", x => x.XueshengId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "T_Teacher_Xuesheng",
                columns: table => new
                {
                    TeacherssTeacherId = table.Column<int>(type: "int", nullable: false),
                    XueshengsXueshengId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Teacher_Xuesheng", x => new { x.TeacherssTeacherId, x.XueshengsXueshengId });
                    table.ForeignKey(
                        name: "FK_T_Teacher_Xuesheng_T_Xuesheng_XueshengsXueshengId",
                        column: x => x.XueshengsXueshengId,
                        principalTable: "T_Xuesheng",
                        principalColumn: "XueshengId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Teacher_Xuesheng_Teacher_TeacherssTeacherId",
                        column: x => x.TeacherssTeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Teacher_Xuesheng_XueshengsXueshengId",
                table: "T_Teacher_Xuesheng",
                column: "XueshengsXueshengId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Teacher_Xuesheng");

            migrationBuilder.DropTable(
                name: "T_Xuesheng");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
