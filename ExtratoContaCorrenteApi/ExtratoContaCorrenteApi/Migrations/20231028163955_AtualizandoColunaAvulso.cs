using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtratoContaCorrenteApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoColunaAvulso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "avulso",
                table: "Lancamentos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "avulso",
                table: "Lancamentos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
