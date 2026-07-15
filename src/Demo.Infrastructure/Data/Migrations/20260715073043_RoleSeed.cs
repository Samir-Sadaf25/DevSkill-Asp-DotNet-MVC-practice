using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "6E775D85-34FB-4329-9419-5F1A3BB6F306", "Admin", "ADMIN" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "50776D0D-2460-48BC-93F3-6286E18C49D2", "Member", "MEMBER" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "4D395E0A-EEC0-4CCF-B747-CAAD75FCC9FE", "Marketing", "MARKETING" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "F8E38957-32FE-46DC-8D42-9A6B3C576985", "Accounting", "ACCOUNTING" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));
        }
    }
}
