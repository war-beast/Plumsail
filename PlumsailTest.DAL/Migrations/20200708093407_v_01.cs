using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlumsailTest.DAL.Migrations
{
    public partial class v_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Submissions");

            migrationBuilder.CreateTable(
                name: "FieldParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    SubmissionId = table.Column<Guid>(nullable: false),
                    SubmissionId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldParameters_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldParameters_Submissions_SubmissionId1",
                        column: x => x.SubmissionId1,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldParameters_SubmissionId",
                table: "FieldParameters",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldParameters_SubmissionId1",
                table: "FieldParameters",
                column: "SubmissionId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldParameters");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
