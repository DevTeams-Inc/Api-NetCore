using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemoveChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientCode",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Clients",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Clients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clients",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "ClientId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clients",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Clients",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Clients",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ClientCode",
                table: "Clients",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
