using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtratoContaCorrenteApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoColunaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Lancamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Lancamentos");
        }
    }
}
