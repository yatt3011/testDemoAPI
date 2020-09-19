using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testDemoAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dashboards",
                columns: table => new
                {
                    dashboardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    success = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashboards", x => x.dashboardId);
                });

            migrationBuilder.CreateTable(
                name: "errors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    message = table.Column<string>(nullable: true),
                    stacktrace = table.Column<string>(nullable: true),
                    innerException = table.Column<string>(nullable: true),
                    columnName = table.Column<string>(nullable: true),
                    columnValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_errors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loginRequests",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginRequests", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "platformDummies",
                columns: table => new
                {
                    platformId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    uniqueName = table.Column<string>(nullable: true),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false),
                    lastUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platformDummies", x => x.platformId);
                });

            migrationBuilder.CreateTable(
                name: "platforms",
                columns: table => new
                {
                    platformId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    uniqueName = table.Column<string>(nullable: true),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platforms", x => x.platformId);
                });

            migrationBuilder.CreateTable(
                name: "chartDashboards",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    value = table.Column<double>(nullable: false),
                    dashboardId = table.Column<int>(nullable: true),
                    dashboardId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chartDashboards", x => x.name);
                    table.ForeignKey(
                        name: "FK_chartDashboards_dashboards_dashboardId",
                        column: x => x.dashboardId,
                        principalTable: "dashboards",
                        principalColumn: "dashboardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chartDashboards_dashboards_dashboardId1",
                        column: x => x.dashboardId1,
                        principalTable: "dashboards",
                        principalColumn: "dashboardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tableUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    dashboardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tableUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_tableUsers_dashboards_dashboardId",
                        column: x => x.dashboardId,
                        principalTable: "dashboards",
                        principalColumn: "dashboardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wellDummies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    platformId = table.Column<int>(nullable: false),
                    uniqueName = table.Column<string>(nullable: true),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false),
                    lastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wellDummies", x => x.id);
                    table.ForeignKey(
                        name: "FK_wellDummies_platformDummies_platformId",
                        column: x => x.platformId,
                        principalTable: "platformDummies",
                        principalColumn: "platformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wells",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    platformId = table.Column<int>(nullable: false),
                    uniqueName = table.Column<string>(nullable: true),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wells", x => x.id);
                    table.ForeignKey(
                        name: "FK_wells_platforms_platformId",
                        column: x => x.platformId,
                        principalTable: "platforms",
                        principalColumn: "platformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chartDashboards_dashboardId",
                table: "chartDashboards",
                column: "dashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_chartDashboards_dashboardId1",
                table: "chartDashboards",
                column: "dashboardId1");

            migrationBuilder.CreateIndex(
                name: "IX_tableUsers_dashboardId",
                table: "tableUsers",
                column: "dashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_wellDummies_platformId",
                table: "wellDummies",
                column: "platformId");

            migrationBuilder.CreateIndex(
                name: "IX_wells_platformId",
                table: "wells",
                column: "platformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chartDashboards");

            migrationBuilder.DropTable(
                name: "errors");

            migrationBuilder.DropTable(
                name: "loginRequests");

            migrationBuilder.DropTable(
                name: "tableUsers");

            migrationBuilder.DropTable(
                name: "wellDummies");

            migrationBuilder.DropTable(
                name: "wells");

            migrationBuilder.DropTable(
                name: "dashboards");

            migrationBuilder.DropTable(
                name: "platformDummies");

            migrationBuilder.DropTable(
                name: "platforms");
        }
    }
}
