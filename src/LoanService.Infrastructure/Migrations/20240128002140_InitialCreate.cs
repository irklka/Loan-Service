﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IdNumber = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    Salt = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loan_requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestedAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    LoanPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoanOfficerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loan_requests_users_LoanOfficerId",
                        column: x => x.LoanOfficerId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_loan_requests_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedById", "DateOfBirth", "Deleted", "Email", "Firstname", "IdNumber", "IsActive", "Lastname", "Password", "Salt" },
                values: new object[] { new Guid("4c7db504-dc3d-4ecd-baae-a78e4e1baad4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Vaja.Kacia@example.com", "Vaja", "01010100032", true, "Kacia", "C62D1C801386EDBDB84735BA14E873B007AF19841A5EC0BE22AD34478FD33086", "qzlxcBpNh8pJq5GP1V7OBA==" });

            migrationBuilder.CreateIndex(
                name: "IX_loan_requests_LoanOfficerId",
                table: "loan_requests",
                column: "LoanOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_loan_requests_UserId",
                table: "loan_requests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loan_requests");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
