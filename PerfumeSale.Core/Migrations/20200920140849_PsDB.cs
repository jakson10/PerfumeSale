using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfumeSale.Core.Migrations
{
    public partial class PsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PS_Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "PS_UserDetail",
                columns: table => new
                {
                    UserDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_UserDetail", x => x.UserDetailId);
                });

            migrationBuilder.CreateTable(
                name: "PS_Perfume",
                columns: table => new
                {
                    PerfumeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfumeName = table.Column<string>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_Perfume", x => x.PerfumeId);
                    table.ForeignKey(
                        name: "FK_PS_Perfume_PS_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "PS_Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PS_Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDetailId = table.Column<int>(nullable: false),
                    ShipAddress = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_PS_Order_PS_UserDetail_UserDetailId",
                        column: x => x.UserDetailId,
                        principalTable: "PS_UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PS_OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    PerfumeId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_PS_OrderDetail_PS_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "PS_Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PS_OrderDetail_PS_Perfume_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "PS_Perfume",
                        principalColumn: "PerfumeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PS_Order_UserDetailId",
                table: "PS_Order",
                column: "UserDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_OrderDetail_OrderId",
                table: "PS_OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_OrderDetail_PerfumeId",
                table: "PS_OrderDetail",
                column: "PerfumeId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_Perfume_BrandId",
                table: "PS_Perfume",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PS_OrderDetail");

            migrationBuilder.DropTable(
                name: "PS_Order");

            migrationBuilder.DropTable(
                name: "PS_Perfume");

            migrationBuilder.DropTable(
                name: "PS_UserDetail");

            migrationBuilder.DropTable(
                name: "PS_Brand");
        }
    }
}
