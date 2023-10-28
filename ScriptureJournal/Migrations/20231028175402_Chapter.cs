using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptureJournal.Migrations
{
    /// <inheritdoc />
    public partial class Chapter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Chapter",
                table: "JournalEntry",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chapter",
                table: "JournalEntry");
        }
    }
}
