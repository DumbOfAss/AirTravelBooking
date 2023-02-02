using Microsoft.EntityFrameworkCore.Migrations;

namespace AirTravelBooking.Server.Data.Migrations
{
    public partial class SwitchClassesToPriorities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplanes_Classes_ClassId",
                table: "Airplanes");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Airplanes",
                newName: "PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_Airplanes_ClassId",
                table: "Airplanes",
                newName: "IX_Airplanes_PriorityId");

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Priorities_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Priorities_FeatureId",
                table: "Priorities",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airplanes_Priorities_PriorityId",
                table: "Airplanes",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplanes_Priorities_PriorityId",
                table: "Airplanes");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "Airplanes",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Airplanes_PriorityId",
                table: "Airplanes",
                newName: "IX_Airplanes_ClassId");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FeatureId",
                table: "Classes",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airplanes_Classes_ClassId",
                table: "Airplanes",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
