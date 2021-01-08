using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoksaProject.Data.Migrations
{
    public partial class migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DrivingSchoolID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    FirstAidPassed = table.Column<bool>(nullable: false),
                    HoursDriven = table.Column<bool>(nullable: false),
                    DriverTestPassed = table.Column<bool>(nullable: false),
                    InstructorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidates_AspNetUsers_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ManufactureYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DrivingSchools",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Established = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingSchools", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hourses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoursN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hourses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Taskses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    HoursCompleted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taskses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DrivingSchoolCarz",
                columns: table => new
                {
                    DrivingSchoolID = table.Column<int>(nullable: false),
                    CarID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingSchoolCarz", x => new { x.CarID, x.DrivingSchoolID });
                    table.ForeignKey(
                        name: "FK_DrivingSchoolCarz_Car_CarID",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrivingSchoolCarz_DrivingSchools_DrivingSchoolID",
                        column: x => x.DrivingSchoolID,
                        principalTable: "DrivingSchools",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateTaskses",
                columns: table => new
                {
                    CandidateID = table.Column<int>(nullable: false),
                    TasksID = table.Column<int>(nullable: false),
                    HoursID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTaskses", x => new { x.CandidateID, x.TasksID, x.HoursID });
                    table.ForeignKey(
                        name: "FK_CandidateTaskses_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateTaskses_Hourses_HoursID",
                        column: x => x.HoursID,
                        principalTable: "Hourses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateTaskses_Taskses_TasksID",
                        column: x => x.TasksID,
                        principalTable: "Taskses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "ID", "Brand", "ManufactureYear", "Type" },
                values: new object[,]
                {
                    { 1, "BMW M4", 2016, null },
                    { 2, "Audi A4", 2019, null },
                    { 3, "Ford Focus RS", 2016, null }
                });

            migrationBuilder.InsertData(
                table: "DrivingSchools",
                columns: new[] { "ID", "City", "Country", "Established", "Name" },
                values: new object[,]
                {
                    { 1, "Sibenik", "Hrvatska", 1990, "Autoskola Neno" },
                    { 2, "Sibenik", "Hrvatska", 1995, "Autoskola Zeleni Val" }
                });

            migrationBuilder.InsertData(
                table: "Taskses",
                columns: new[] { "ID", "CodeName", "Description", "Hours", "HoursCompleted", "IsCompleted" },
                values: new object[,]
                {
                    { 1, "A1", "Upoznavanje vozila, Voznja po pravcu, mijenjanje brzina i zaustavljanje", 1, 0, false },
                    { 2, "A2", "Voznja unaprijed-unatrag po pravcu s promjenom smjera", 2, 0, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarID",
                table: "AspNetUsers",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DrivingSchoolID",
                table: "AspNetUsers",
                column: "DrivingSchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_InstructorId",
                table: "Candidates",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTaskses_HoursID",
                table: "CandidateTaskses",
                column: "HoursID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTaskses_TasksID",
                table: "CandidateTaskses",
                column: "TasksID");

            migrationBuilder.CreateIndex(
                name: "IX_DrivingSchoolCarz_DrivingSchoolID",
                table: "DrivingSchoolCarz",
                column: "DrivingSchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Car_CarID",
                table: "AspNetUsers",
                column: "CarID",
                principalTable: "Car",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DrivingSchools_DrivingSchoolID",
                table: "AspNetUsers",
                column: "DrivingSchoolID",
                principalTable: "DrivingSchools",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Car_CarID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DrivingSchools_DrivingSchoolID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CandidateTaskses");

            migrationBuilder.DropTable(
                name: "DrivingSchoolCarz");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Hourses");

            migrationBuilder.DropTable(
                name: "Taskses");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "DrivingSchools");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DrivingSchoolID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DrivingSchoolID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
