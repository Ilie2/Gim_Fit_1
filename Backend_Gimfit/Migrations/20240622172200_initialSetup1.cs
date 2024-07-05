using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Gimfit.Migrations
{
    /// <inheritdoc />
    public partial class initialSetup1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Trainers_TrainerID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Clients_clientsID",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_clientsID",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "clientsID",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "TrainerID",
                table: "Clients",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_TrainerID",
                table: "Clients",
                newName: "IX_Clients_TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Trainers_TrainerId",
                table: "Clients",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Trainers_TrainerId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Clients",
                newName: "TrainerID");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_TrainerId",
                table: "Clients",
                newName: "IX_Clients_TrainerID");

            migrationBuilder.AddColumn<int>(
                name: "clientsID",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_clientsID",
                table: "Trainers",
                column: "clientsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Trainers_TrainerID",
                table: "Clients",
                column: "TrainerID",
                principalTable: "Trainers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Clients_clientsID",
                table: "Trainers",
                column: "clientsID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
