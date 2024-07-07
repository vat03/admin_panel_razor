using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace admin_panel_razor.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneralSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WebsiteName = table.Column<string>(type: "text", nullable: false),
                    WebsiteURL = table.Column<string>(type: "text", nullable: false),
                    WebsiteTagline = table.Column<string>(type: "text", nullable: false),
                    WebsiteKeyword = table.Column<string>(type: "text", nullable: false),
                    WebsiteDescription = table.Column<string>(type: "text", nullable: false),
                    FooterCopyright = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralSettings");
        }
    }
}
