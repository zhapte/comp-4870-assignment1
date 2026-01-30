using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Headline = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "ArticleId", "Author", "Content", "DatePublished", "Headline" },
                values: new object[,]
                {
                    { 1, "Kaid Krawchuk", "A group of BCIT students are developing a modern timesheet tracking system using ASP.NET Core and SQL Server.", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "BCIT Students Build Full-Stack Timesheet System" },
                    { 2, "Project Team", "The latest sprint introduced two-factor authentication to enhance account protection and role-based access.", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "2FA Authentication Added to Improve Security" },
                    { 3, "BCIT Computing Department", "Students are learning container deployment strategies using OpenShift and enterprise infrastructure.", new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "OpenShift Deployment Becomes Key Focus for COMP4911" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
