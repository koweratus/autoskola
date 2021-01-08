using Microsoft.EntityFrameworkCore.Migrations;

namespace CoksaProject.Data.Migrations
{
    public partial class dodaniOstaliZadaci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Candidates",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Candidates",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Taskses",
                columns: new[] { "ID", "CodeName", "Description", "Hours", "HoursCompleted", "IsCompleted" },
                values: new object[,]
                {
                    { 3, "A3", "Okretanje vozila zbog promjene smjera", 1, 0, false },
                    { 4, "A4", "Parkiranje vozila", 1, 0, false },
                    { 5, "A5", "Kocenje i zaustavljanje", 1, 0, false },
                    { 6, "B1", "Ukljucivanje u promet i iskljucivanje iz prometa", 2, 0, false },
                    { 7, "B2", "Polukruzno okretanje, okretanje vozila s vise postupaka, okretanje vozila zbog promjene smjera, parkiranje vozila", 2, 0, false },
                    { 8, "B3", "Postupanje prema znakovima u prometu", 4, 0, false },
                    { 9, "B4", "Voznja", 4, 0, false },
                    { 10, "B5", "Voznja zavojima, prilagodba brzine voznje, kocenje", 2, 0, false },
                    { 11, "B6", "Voznja raskrizjem", 2, 0, false },
                    { 12, "B7", "Pretjecanje i  obilaznje", 2, 0, false },
                    { 13, "B8", "Ukljucivanje na autocestu ili brzu cestu ili cestu namijenjenu za promet motornih vozila i iskljucivanje s tih cesta", 3, 0, false },
                    { 14, "B9", "Voznja u naselju (gradu) i izvan naselja (grada)", 2, 0, false },
                    { 15, "B10", "Voznja prometnicama s posebnim karakteristikama", 2, 0, false },
                    { 16, "B11", "Samostalna voznja", 1, 0, false },
                    { 17, "B12", "Sigurna i energetski ucinkovita voznja", 2, 0, false },
                    { 18, "B13", "Ponasanje prema drugim sudionicima u prometu sukladno prometnim propisima i pravilima", 2, 0, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Taskses",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
