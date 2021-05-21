using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfileMVC.Migrations
{
    public partial class ProfileInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmployed = table.Column<bool>(type: "bit", nullable: false),
                    NoticePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentCTC = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Age", "CurrentCTC", "IsEmployed", "Name", "NoticePeriod", "Qualification" },
                values: new object[] { 1, 28, 450000f, true, "Ramu", "three months", "B.E ECE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
