using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Chevrolet'), ('Mitsubishi'), ('Toyota')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Cavalier', (SELECT ID FROM Makes WHERE Name = 'Chevrolet'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Camaro', (SELECT ID FROM Makes WHERE Name = 'Chevrolet'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Outlander', (SELECT ID FROM Makes WHERE Name = 'Mitsubishi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Montero', (SELECT ID FROM Makes WHERE Name = 'Mitsubishi'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Corolla', (SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Prius', (SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Yaris', (SELECT ID FROM Makes WHERE Name = 'Toyota'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Chevrolet', 'Mitsubishi', 'Toyota')");
        }
    }
}
