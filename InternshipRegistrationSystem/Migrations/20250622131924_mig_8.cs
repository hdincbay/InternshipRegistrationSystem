using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipRegistrationSystem.Migrations
{
    /// <inheritdoc />
    public partial class mig_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_Category_CategoryId",
                table: "RegistrationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_Status_StatusId",
                table: "RegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationForm_CandidateId",
                table: "RegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationForm_ProfessorId",
                table: "RegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationForm_ResearchAssistantId",
                table: "RegistrationForm");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "RegistrationForm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResearchAssistantId",
                table: "RegistrationForm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "RegistrationForm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "RegistrationForm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "RegistrationForm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForm_CandidateId",
                table: "RegistrationForm",
                column: "CandidateId",
                unique: true,
                filter: "[CandidateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForm_ProfessorId",
                table: "RegistrationForm",
                column: "ProfessorId",
                unique: true,
                filter: "[ProfessorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForm_ResearchAssistantId",
                table: "RegistrationForm",
                column: "ResearchAssistantId",
                unique: true,
                filter: "[ResearchAssistantId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_Category_CategoryId",
                table: "RegistrationForm",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_Status_StatusId",
                table: "RegistrationForm",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_Category_CategoryId",
                table: "RegistrationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_Status_StatusId",
                table: "RegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationForm_CandidateId",
                table: "RegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationForm_ProfessorId",
                table: "RegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationForm_ResearchAssistantId",
                table: "RegistrationForm");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "RegistrationForm",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResearchAssistantId",
                table: "RegistrationForm",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "RegistrationForm",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "RegistrationForm",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "RegistrationForm",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForm_CandidateId",
                table: "RegistrationForm",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForm_ProfessorId",
                table: "RegistrationForm",
                column: "ProfessorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForm_ResearchAssistantId",
                table: "RegistrationForm",
                column: "ResearchAssistantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_Category_CategoryId",
                table: "RegistrationForm",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_Status_StatusId",
                table: "RegistrationForm",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
