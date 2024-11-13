using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAngularReact.Migrations
{
    /// <inheritdoc />
    public partial class addstatut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "statut",
                table: "Taskes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statut",
                table: "Taskes");
        }
    }
}
