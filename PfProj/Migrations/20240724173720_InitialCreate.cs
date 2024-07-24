using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PfProj.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestingColName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetColName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservationLimit = table.Column<int>(type: "int", nullable: true),
                    NumObservations = table.Column<int>(type: "int", nullable: true),
                    Covar = table.Column<double>(type: "float", nullable: true),
                    Cor = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataModels");
        }
    }
}
