using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chillify.Dal.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pseudo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PswdHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricMember_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pseudo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PswdHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricMemberAddress",
                columns: table => new
                {
                    HistoricMemberId = table.Column<int>(type: "int", nullable: false),
                    HistoricAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricMemberAddress", x => new { x.HistoricMemberId, x.HistoricAddressId });
                    table.ForeignKey(
                        name: "FK_HistoricMemberAddress_HistoricAddress_HistoricAddressId",
                        column: x => x.HistoricAddressId,
                        principalTable: "HistoricAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricMemberAddress_HistoricMember_HistoricMemberId",
                        column: x => x.HistoricMemberId,
                        principalTable: "HistoricMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberAddress",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAddress", x => new { x.MemberId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_MemberAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberAddress_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "Number", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Brussels", "Belgium", "1", "1160", "Chaussée de Wavre" },
                    { 2, "Brussels", "Belgium", "2", "1160", "Chaussée de Wavre" },
                    { 3, "Brussels", "Belgium", "3", "1160", "Chaussée de Wavre" },
                    { 4, "Brussels", "Belgium", "4", "1160", "Chaussée de Wavre" },
                    { 5, "Brussels", "Belgium", "5", "1160", "Chaussée de Wavre" },
                    { 6, "Brussels", "Belgium", "6", "1160", "Chaussée de Wavre" },
                    { 7, "Brussels", "Belgium", "7", "1160", "Chaussée de Wavre" },
                    { 8, "Brussels", "Belgium", "8", "1160", "Chaussée de Wavre" },
                    { 9, "Brussels", "Belgium", "9", "1160", "Chaussée de Wavre" },
                    { 10, "Brussels", "Belgium", "10", "1160", "Chaussée de Wavre" },
                    { 11, "Brussels", "Belgium", "11", "1160", "Chaussée de Wavre" },
                    { 12, "Brussels", "Belgium", "12", "1160", "Chaussée de Wavre" },
                    { 13, "Brussels", "Belgium", "13", "1160", "Chaussée de Wavre" },
                    { 14, "Brussels", "Belgium", "14", "1160", "Chaussée de Wavre" },
                    { 15, "Brussels", "Belgium", "15", "1160", "Chaussée de Wavre" },
                    { 16, "Brussels", "Belgium", "16", "1160", "Chaussée de Wavre" },
                    { 17, "Brussels", "Belgium", "17", "1160", "Chaussée de Wavre" },
                    { 18, "Brussels", "Belgium", "18", "1160", "Chaussée de Wavre" },
                    { 19, "Brussels", "Belgium", "19", "1160", "Chaussée de Wavre" },
                    { 20, "Brussels", "Belgium", "20", "1160", "Chaussée de Wavre" },
                    { 21, "Brussels", "Belgium", "21", "1160", "Chaussée de Wavre" },
                    { 22, "Brussels", "Belgium", "22", "1160", "Chaussée de Wavre" },
                    { 23, "Brussels", "Belgium", "23", "1160", "Chaussée de Wavre" },
                    { 24, "Brussels", "Belgium", "24", "1160", "Chaussée de Wavre" },
                    { 25, "Brussels", "Belgium", "25", "1160", "Chaussée de Wavre" },
                    { 26, "Brussels", "Belgium", "26", "1160", "Chaussée de Wavre" },
                    { 27, "Brussels", "Belgium", "27", "1160", "Chaussée de Wavre" },
                    { 28, "Brussels", "Belgium", "28", "1160", "Chaussée de Wavre" },
                    { 29, "Brussels", "Belgium", "29", "1160", "Chaussée de Wavre" },
                    { 30, "Brussels", "Belgium", "30", "1160", "Chaussée de Wavre" },
                    { 31, "Brussels", "Belgium", "31", "1160", "Chaussée de Wavre" },
                    { 32, "Brussels", "Belgium", "32", "1160", "Chaussée de Wavre" },
                    { 33, "Brussels", "Belgium", "33", "1160", "Chaussée de Wavre" },
                    { 34, "Brussels", "Belgium", "34", "1160", "Chaussée de Wavre" },
                    { 35, "Brussels", "Belgium", "35", "1160", "Chaussée de Wavre" },
                    { 36, "Brussels", "Belgium", "36", "1160", "Chaussée de Wavre" },
                    { 37, "Brussels", "Belgium", "37", "1160", "Chaussée de Wavre" },
                    { 38, "Brussels", "Belgium", "38", "1160", "Chaussée de Wavre" },
                    { 39, "Brussels", "Belgium", "39", "1160", "Chaussée de Wavre" },
                    { 40, "Brussels", "Belgium", "40", "1160", "Chaussée de Wavre" },
                    { 41, "Brussels", "Belgium", "41", "1160", "Chaussée de Wavre" },
                    { 42, "Brussels", "Belgium", "42", "1160", "Chaussée de Wavre" },
                    { 43, "Brussels", "Belgium", "43", "1160", "Chaussée de Wavre" },
                    { 44, "Brussels", "Belgium", "44", "1160", "Chaussée de Wavre" },
                    { 45, "Brussels", "Belgium", "45", "1160", "Chaussée de Wavre" },
                    { 46, "Brussels", "Belgium", "46", "1160", "Chaussée de Wavre" },
                    { 47, "Brussels", "Belgium", "47", "1160", "Chaussée de Wavre" },
                    { 48, "Brussels", "Belgium", "48", "1160", "Chaussée de Wavre" },
                    { 49, "Brussels", "Belgium", "49", "1160", "Chaussée de Wavre" },
                    { 50, "Brussels", "Belgium", "50", "1160", "Chaussée de Wavre" },
                    { 51, "Brussels", "Belgium", "51", "1160", "Chaussée de Wavre" },
                    { 52, "Brussels", "Belgium", "52", "1160", "Chaussée de Wavre" },
                    { 53, "Brussels", "Belgium", "53", "1160", "Chaussée de Wavre" },
                    { 54, "Brussels", "Belgium", "54", "1160", "Chaussée de Wavre" },
                    { 55, "Brussels", "Belgium", "55", "1160", "Chaussée de Wavre" },
                    { 56, "Brussels", "Belgium", "56", "1160", "Chaussée de Wavre" },
                    { 57, "Brussels", "Belgium", "57", "1160", "Chaussée de Wavre" },
                    { 58, "Brussels", "Belgium", "58", "1160", "Chaussée de Wavre" },
                    { 59, "Brussels", "Belgium", "59", "1160", "Chaussée de Wavre" },
                    { 60, "Brussels", "Belgium", "60", "1160", "Chaussée de Wavre" },
                    { 61, "Brussels", "Belgium", "61", "1160", "Chaussée de Wavre" },
                    { 62, "Brussels", "Belgium", "62", "1160", "Chaussée de Wavre" },
                    { 63, "Brussels", "Belgium", "63", "1160", "Chaussée de Wavre" },
                    { 64, "Brussels", "Belgium", "64", "1160", "Chaussée de Wavre" },
                    { 65, "Brussels", "Belgium", "65", "1160", "Chaussée de Wavre" },
                    { 66, "Brussels", "Belgium", "66", "1160", "Chaussée de Wavre" },
                    { 67, "Brussels", "Belgium", "67", "1160", "Chaussée de Wavre" },
                    { 68, "Brussels", "Belgium", "68", "1160", "Chaussée de Wavre" },
                    { 69, "Brussels", "Belgium", "69", "1160", "Chaussée de Wavre" },
                    { 70, "Brussels", "Belgium", "70", "1160", "Chaussée de Wavre" },
                    { 71, "Brussels", "Belgium", "71", "1160", "Chaussée de Wavre" },
                    { 72, "Brussels", "Belgium", "72", "1160", "Chaussée de Wavre" },
                    { 73, "Brussels", "Belgium", "73", "1160", "Chaussée de Wavre" },
                    { 74, "Brussels", "Belgium", "74", "1160", "Chaussée de Wavre" },
                    { 75, "Brussels", "Belgium", "75", "1160", "Chaussée de Wavre" },
                    { 76, "Brussels", "Belgium", "76", "1160", "Chaussée de Wavre" },
                    { 77, "Brussels", "Belgium", "77", "1160", "Chaussée de Wavre" },
                    { 78, "Brussels", "Belgium", "78", "1160", "Chaussée de Wavre" },
                    { 79, "Brussels", "Belgium", "79", "1160", "Chaussée de Wavre" },
                    { 80, "Brussels", "Belgium", "80", "1160", "Chaussée de Wavre" },
                    { 81, "Brussels", "Belgium", "81", "1160", "Chaussée de Wavre" },
                    { 82, "Brussels", "Belgium", "82", "1160", "Chaussée de Wavre" },
                    { 83, "Brussels", "Belgium", "83", "1160", "Chaussée de Wavre" },
                    { 84, "Brussels", "Belgium", "84", "1160", "Chaussée de Wavre" },
                    { 85, "Brussels", "Belgium", "85", "1160", "Chaussée de Wavre" },
                    { 86, "Brussels", "Belgium", "86", "1160", "Chaussée de Wavre" },
                    { 87, "Brussels", "Belgium", "87", "1160", "Chaussée de Wavre" },
                    { 88, "Brussels", "Belgium", "88", "1160", "Chaussée de Wavre" },
                    { 89, "Brussels", "Belgium", "89", "1160", "Chaussée de Wavre" },
                    { 90, "Brussels", "Belgium", "90", "1160", "Chaussée de Wavre" },
                    { 91, "Brussels", "Belgium", "91", "1160", "Chaussée de Wavre" },
                    { 92, "Brussels", "Belgium", "92", "1160", "Chaussée de Wavre" },
                    { 93, "Brussels", "Belgium", "93", "1160", "Chaussée de Wavre" },
                    { 94, "Brussels", "Belgium", "94", "1160", "Chaussée de Wavre" },
                    { 95, "Brussels", "Belgium", "95", "1160", "Chaussée de Wavre" },
                    { 96, "Brussels", "Belgium", "96", "1160", "Chaussée de Wavre" },
                    { 97, "Brussels", "Belgium", "97", "1160", "Chaussée de Wavre" },
                    { 98, "Brussels", "Belgium", "98", "1160", "Chaussée de Wavre" },
                    { 99, "Brussels", "Belgium", "99", "1160", "Chaussée de Wavre" },
                    { 100, "Brussels", "Belgium", "100", "1160", "Chaussée de Wavre" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "No Role", "None" },
                    { 2, "Basic role for newcomers", "Visitor" },
                    { 3, "Classic role for contributing members", "Member" },
                    { 4, "Advanced role to manage the website", "Manager" },
                    { 5, "Most advanced role to administrate the website", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "BirthDate", "EmailAddress", "FirstName", "LastName", "Pseudo", "PswdHash", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(1993, 2, 11, 1, 52, 26, 0, DateTimeKind.Unspecified), "member1@gmail.com", "Gertrude", "Maes", "Member1", "Ch1llify", 2 },
                    { 2, new DateTime(2022, 4, 4, 1, 58, 54, 0, DateTimeKind.Unspecified), "member2@gmail.com", "Martin", "Peeters", "Member2", "Ch1llify", 2 },
                    { 3, new DateTime(2002, 4, 6, 4, 3, 19, 0, DateTimeKind.Unspecified), "member3@gmail.com", "Marie", "Jacobs", "Member3", "Ch1llify", 2 },
                    { 4, new DateTime(2003, 5, 30, 1, 6, 26, 0, DateTimeKind.Unspecified), "member4@gmail.com", "Julien", "Goossens", "Member4", "Ch1llify", 5 },
                    { 5, new DateTime(2008, 4, 28, 10, 10, 57, 0, DateTimeKind.Unspecified), "member5@gmail.com", "Simon", "Janssens", "Member5", "Ch1llify", 4 },
                    { 6, new DateTime(2004, 5, 21, 18, 51, 20, 0, DateTimeKind.Unspecified), "member6@gmail.com", "Arnaud", "Janssens", "Member6", "Ch1llify", 2 },
                    { 7, new DateTime(2002, 5, 1, 8, 58, 16, 0, DateTimeKind.Unspecified), "member7@gmail.com", "Simon", "Mertens", "Member7", "Ch1llify", 1 },
                    { 8, new DateTime(2011, 10, 6, 23, 17, 43, 0, DateTimeKind.Unspecified), "member8@gmail.com", "Julien", "Maes", "Member8", "Ch1llify", 3 },
                    { 9, new DateTime(2007, 6, 29, 20, 44, 33, 0, DateTimeKind.Unspecified), "member9@gmail.com", "Elisabeth", "Moreau", "Member9", "Ch1llify", 1 },
                    { 10, new DateTime(2001, 9, 11, 10, 4, 44, 0, DateTimeKind.Unspecified), "member10@gmail.com", "Albert", "Mertens", "Member10", "Ch1llify", 3 },
                    { 11, new DateTime(2019, 3, 5, 19, 9, 32, 0, DateTimeKind.Unspecified), "member11@gmail.com", "Julien", "Janssens", "Member11", "Ch1llify", 5 },
                    { 12, new DateTime(1996, 2, 14, 12, 53, 56, 0, DateTimeKind.Unspecified), "member12@gmail.com", "Martine", "Claes", "Member12", "Ch1llify", 1 },
                    { 13, new DateTime(1994, 6, 15, 1, 37, 50, 0, DateTimeKind.Unspecified), "member13@gmail.com", "Albert", "Maes", "Member13", "Ch1llify", 3 },
                    { 14, new DateTime(2006, 12, 15, 8, 0, 18, 0, DateTimeKind.Unspecified), "member14@gmail.com", "Justine", "De Smet", "Member14", "Ch1llify", 3 },
                    { 15, new DateTime(1999, 3, 18, 17, 0, 36, 0, DateTimeKind.Unspecified), "member15@gmail.com", "Marie", "Willems", "Member15", "Ch1llify", 3 },
                    { 16, new DateTime(2005, 9, 23, 0, 11, 16, 0, DateTimeKind.Unspecified), "member16@gmail.com", "Bernard", "Dubois", "Member16", "Ch1llify", 1 },
                    { 17, new DateTime(2006, 11, 15, 10, 29, 38, 0, DateTimeKind.Unspecified), "member17@gmail.com", "Albert", "Wouters", "Member17", "Ch1llify", 2 },
                    { 18, new DateTime(2011, 1, 24, 9, 21, 13, 0, DateTimeKind.Unspecified), "member18@gmail.com", "Catherine", "Willems", "Member18", "Ch1llify", 5 },
                    { 19, new DateTime(2022, 3, 11, 22, 33, 58, 0, DateTimeKind.Unspecified), "member19@gmail.com", "Martine", "Mertens", "Member19", "Ch1llify", 4 },
                    { 20, new DateTime(1997, 3, 5, 13, 33, 34, 0, DateTimeKind.Unspecified), "member20@gmail.com", "Arnaud", "Maes", "Member20", "Ch1llify", 3 },
                    { 21, new DateTime(2021, 5, 17, 6, 14, 7, 0, DateTimeKind.Unspecified), "member21@gmail.com", "Justine", "Durand", "Member21", "Ch1llify", 1 },
                    { 22, new DateTime(2016, 7, 27, 21, 31, 2, 0, DateTimeKind.Unspecified), "member22@gmail.com", "Michel", "Goossens", "Member22", "Ch1llify", 5 },
                    { 23, new DateTime(2016, 5, 6, 4, 39, 43, 0, DateTimeKind.Unspecified), "member23@gmail.com", "Elisabeth", "Willems", "Member23", "Ch1llify", 3 },
                    { 24, new DateTime(1999, 10, 10, 16, 47, 34, 0, DateTimeKind.Unspecified), "member24@gmail.com", "Catherine", "Willems", "Member24", "Ch1llify", 3 },
                    { 25, new DateTime(2003, 3, 31, 5, 30, 58, 0, DateTimeKind.Unspecified), "member25@gmail.com", "Martin", "Wouters", "Member25", "Ch1llify", 3 },
                    { 26, new DateTime(2006, 4, 2, 19, 16, 28, 0, DateTimeKind.Unspecified), "member26@gmail.com", "Justine", "Maes", "Member26", "Ch1llify", 5 },
                    { 27, new DateTime(2001, 10, 5, 17, 1, 55, 0, DateTimeKind.Unspecified), "member27@gmail.com", "Michel", "Peeters", "Member27", "Ch1llify", 2 },
                    { 28, new DateTime(2004, 7, 7, 6, 38, 40, 0, DateTimeKind.Unspecified), "member28@gmail.com", "Gertrude", "Willems", "Member28", "Ch1llify", 2 },
                    { 29, new DateTime(2004, 11, 15, 18, 41, 25, 0, DateTimeKind.Unspecified), "member29@gmail.com", "Albert", "Goossens", "Member29", "Ch1llify", 1 },
                    { 30, new DateTime(2015, 10, 14, 0, 10, 3, 0, DateTimeKind.Unspecified), "member30@gmail.com", "Bernard", "Wouters", "Member30", "Ch1llify", 3 },
                    { 31, new DateTime(2014, 9, 5, 0, 51, 2, 0, DateTimeKind.Unspecified), "member31@gmail.com", "Julien", "Petit", "Member31", "Ch1llify", 4 },
                    { 32, new DateTime(2009, 7, 4, 3, 26, 39, 0, DateTimeKind.Unspecified), "member32@gmail.com", "Elisabeth", "Goossens", "Member32", "Ch1llify", 3 },
                    { 33, new DateTime(2013, 9, 1, 2, 24, 48, 0, DateTimeKind.Unspecified), "member33@gmail.com", "Elisabeth", "Durand", "Member33", "Ch1llify", 4 },
                    { 34, new DateTime(2019, 11, 1, 6, 18, 29, 0, DateTimeKind.Unspecified), "member34@gmail.com", "Simon", "Durand", "Member34", "Ch1llify", 5 },
                    { 35, new DateTime(1993, 10, 11, 23, 54, 16, 0, DateTimeKind.Unspecified), "member35@gmail.com", "Gertrude", "Jacobs", "Member35", "Ch1llify", 4 },
                    { 36, new DateTime(2021, 1, 4, 0, 13, 56, 0, DateTimeKind.Unspecified), "member36@gmail.com", "Elisabeth", "Jacobs", "Member36", "Ch1llify", 1 },
                    { 37, new DateTime(2022, 4, 12, 22, 12, 26, 0, DateTimeKind.Unspecified), "member37@gmail.com", "Michel", "Moreau", "Member37", "Ch1llify", 2 },
                    { 38, new DateTime(2004, 6, 17, 21, 16, 7, 0, DateTimeKind.Unspecified), "member38@gmail.com", "Arnaud", "Peeters", "Member38", "Ch1llify", 5 },
                    { 39, new DateTime(2022, 3, 12, 18, 12, 10, 0, DateTimeKind.Unspecified), "member39@gmail.com", "Martin", "Willems", "Member39", "Ch1llify", 5 },
                    { 40, new DateTime(2016, 7, 12, 9, 30, 27, 0, DateTimeKind.Unspecified), "member40@gmail.com", "Julie", "Moreau", "Member40", "Ch1llify", 3 },
                    { 41, new DateTime(2014, 8, 18, 7, 2, 53, 0, DateTimeKind.Unspecified), "member41@gmail.com", "Martine", "Janssens", "Member41", "Ch1llify", 2 },
                    { 42, new DateTime(2019, 4, 23, 20, 37, 45, 0, DateTimeKind.Unspecified), "member42@gmail.com", "Marie", "Dubois", "Member42", "Ch1llify", 3 },
                    { 43, new DateTime(2005, 2, 25, 7, 30, 0, 0, DateTimeKind.Unspecified), "member43@gmail.com", "Bernard", "Dubois", "Member43", "Ch1llify", 2 },
                    { 44, new DateTime(1995, 1, 21, 11, 54, 25, 0, DateTimeKind.Unspecified), "member44@gmail.com", "Catherine", "Durand", "Member44", "Ch1llify", 5 },
                    { 45, new DateTime(1995, 5, 22, 8, 36, 19, 0, DateTimeKind.Unspecified), "member45@gmail.com", "Julie", "De Smet", "Member45", "Ch1llify", 4 },
                    { 46, new DateTime(1995, 12, 4, 15, 52, 46, 0, DateTimeKind.Unspecified), "member46@gmail.com", "Elisabeth", "De Smet", "Member46", "Ch1llify", 4 },
                    { 47, new DateTime(1991, 7, 27, 11, 38, 33, 0, DateTimeKind.Unspecified), "member47@gmail.com", "Robin", "Jacobs", "Member47", "Ch1llify", 2 },
                    { 48, new DateTime(2022, 1, 5, 4, 49, 4, 0, DateTimeKind.Unspecified), "member48@gmail.com", "Arnaud", "Goossens", "Member48", "Ch1llify", 3 },
                    { 49, new DateTime(2001, 6, 28, 21, 37, 18, 0, DateTimeKind.Unspecified), "member49@gmail.com", "Elisabeth", "De Smet", "Member49", "Ch1llify", 5 },
                    { 50, new DateTime(1993, 6, 13, 9, 3, 54, 0, DateTimeKind.Unspecified), "member50@gmail.com", "Robin", "Claes", "Member50", "Ch1llify", 5 },
                    { 51, new DateTime(2010, 4, 21, 7, 38, 45, 0, DateTimeKind.Unspecified), "member51@gmail.com", "Martine", "Durand", "Member51", "Ch1llify", 1 },
                    { 52, new DateTime(2012, 8, 10, 6, 35, 56, 0, DateTimeKind.Unspecified), "member52@gmail.com", "Justine", "Peeters", "Member52", "Ch1llify", 3 },
                    { 53, new DateTime(2009, 9, 4, 6, 3, 59, 0, DateTimeKind.Unspecified), "member53@gmail.com", "Marie", "Peeters", "Member53", "Ch1llify", 3 },
                    { 54, new DateTime(2001, 6, 24, 7, 7, 38, 0, DateTimeKind.Unspecified), "member54@gmail.com", "Justine", "Goossens", "Member54", "Ch1llify", 5 },
                    { 55, new DateTime(1996, 4, 2, 1, 41, 15, 0, DateTimeKind.Unspecified), "member55@gmail.com", "Robin", "Janssens", "Member55", "Ch1llify", 1 },
                    { 56, new DateTime(1995, 12, 2, 21, 27, 51, 0, DateTimeKind.Unspecified), "member56@gmail.com", "Julie", "Leroy", "Member56", "Ch1llify", 3 },
                    { 57, new DateTime(1996, 7, 2, 4, 37, 47, 0, DateTimeKind.Unspecified), "member57@gmail.com", "Michel", "Jacobs", "Member57", "Ch1llify", 3 },
                    { 58, new DateTime(2015, 2, 27, 12, 50, 45, 0, DateTimeKind.Unspecified), "member58@gmail.com", "Martin", "Maes", "Member58", "Ch1llify", 4 },
                    { 59, new DateTime(1995, 2, 23, 2, 36, 15, 0, DateTimeKind.Unspecified), "member59@gmail.com", "Gertrude", "Leroy", "Member59", "Ch1llify", 3 },
                    { 60, new DateTime(1995, 1, 14, 3, 17, 2, 0, DateTimeKind.Unspecified), "member60@gmail.com", "Julie", "Durand", "Member60", "Ch1llify", 5 },
                    { 61, new DateTime(2012, 4, 24, 17, 50, 16, 0, DateTimeKind.Unspecified), "member61@gmail.com", "Martin", "Janssens", "Member61", "Ch1llify", 5 },
                    { 62, new DateTime(2006, 8, 16, 3, 45, 23, 0, DateTimeKind.Unspecified), "member62@gmail.com", "Justine", "Maes", "Member62", "Ch1llify", 5 },
                    { 63, new DateTime(2012, 3, 23, 10, 24, 47, 0, DateTimeKind.Unspecified), "member63@gmail.com", "Martin", "Dubois", "Member63", "Ch1llify", 3 },
                    { 64, new DateTime(1995, 11, 13, 2, 47, 15, 0, DateTimeKind.Unspecified), "member64@gmail.com", "Martine", "Dubois", "Member64", "Ch1llify", 2 },
                    { 65, new DateTime(2013, 12, 13, 10, 33, 58, 0, DateTimeKind.Unspecified), "member65@gmail.com", "Justine", "De Smet", "Member65", "Ch1llify", 3 },
                    { 66, new DateTime(2009, 9, 18, 10, 4, 11, 0, DateTimeKind.Unspecified), "member66@gmail.com", "Gertrude", "Jacobs", "Member66", "Ch1llify", 4 },
                    { 67, new DateTime(2022, 9, 9, 2, 51, 16, 0, DateTimeKind.Unspecified), "member67@gmail.com", "Gertrude", "Petit", "Member67", "Ch1llify", 5 },
                    { 68, new DateTime(1996, 6, 15, 4, 10, 36, 0, DateTimeKind.Unspecified), "member68@gmail.com", "Catherine", "Maes", "Member68", "Ch1llify", 5 },
                    { 69, new DateTime(2022, 3, 8, 4, 25, 54, 0, DateTimeKind.Unspecified), "member69@gmail.com", "Martin", "Wouters", "Member69", "Ch1llify", 2 },
                    { 70, new DateTime(1995, 8, 13, 3, 44, 44, 0, DateTimeKind.Unspecified), "member70@gmail.com", "Justine", "Dubois", "Member70", "Ch1llify", 5 },
                    { 71, new DateTime(1997, 7, 9, 23, 1, 2, 0, DateTimeKind.Unspecified), "member71@gmail.com", "Marie", "Wouters", "Member71", "Ch1llify", 4 },
                    { 72, new DateTime(2015, 2, 24, 12, 9, 58, 0, DateTimeKind.Unspecified), "member72@gmail.com", "Marie", "Maes", "Member72", "Ch1llify", 2 },
                    { 73, new DateTime(2015, 12, 13, 13, 49, 31, 0, DateTimeKind.Unspecified), "member73@gmail.com", "Martine", "De Smet", "Member73", "Ch1llify", 2 },
                    { 74, new DateTime(2011, 7, 15, 8, 9, 38, 0, DateTimeKind.Unspecified), "member74@gmail.com", "Elisabeth", "Wouters", "Member74", "Ch1llify", 5 },
                    { 75, new DateTime(2012, 8, 10, 19, 59, 20, 0, DateTimeKind.Unspecified), "member75@gmail.com", "Gertrude", "Mertens", "Member75", "Ch1llify", 4 },
                    { 76, new DateTime(1997, 7, 22, 5, 47, 49, 0, DateTimeKind.Unspecified), "member76@gmail.com", "Julien", "Dubois", "Member76", "Ch1llify", 3 },
                    { 77, new DateTime(2001, 3, 31, 7, 59, 36, 0, DateTimeKind.Unspecified), "member77@gmail.com", "Julien", "Claes", "Member77", "Ch1llify", 5 },
                    { 78, new DateTime(1997, 12, 20, 15, 49, 20, 0, DateTimeKind.Unspecified), "member78@gmail.com", "Marie", "Moreau", "Member78", "Ch1llify", 2 },
                    { 79, new DateTime(2007, 6, 3, 16, 1, 41, 0, DateTimeKind.Unspecified), "member79@gmail.com", "Arnaud", "Petit", "Member79", "Ch1llify", 2 },
                    { 80, new DateTime(1994, 4, 17, 15, 45, 38, 0, DateTimeKind.Unspecified), "member80@gmail.com", "Albert", "Leroy", "Member80", "Ch1llify", 3 },
                    { 81, new DateTime(1995, 3, 9, 14, 41, 47, 0, DateTimeKind.Unspecified), "member81@gmail.com", "Justine", "Wouters", "Member81", "Ch1llify", 2 },
                    { 82, new DateTime(1998, 10, 24, 1, 53, 30, 0, DateTimeKind.Unspecified), "member82@gmail.com", "Bernard", "Claes", "Member82", "Ch1llify", 2 },
                    { 83, new DateTime(2000, 1, 20, 17, 26, 37, 0, DateTimeKind.Unspecified), "member83@gmail.com", "Robin", "Moreau", "Member83", "Ch1llify", 5 },
                    { 84, new DateTime(2014, 9, 24, 6, 1, 5, 0, DateTimeKind.Unspecified), "member84@gmail.com", "Bernard", "Mertens", "Member84", "Ch1llify", 2 },
                    { 85, new DateTime(2021, 8, 19, 3, 31, 9, 0, DateTimeKind.Unspecified), "member85@gmail.com", "Robin", "Claes", "Member85", "Ch1llify", 3 },
                    { 86, new DateTime(2021, 5, 10, 0, 44, 2, 0, DateTimeKind.Unspecified), "member86@gmail.com", "Martin", "Moreau", "Member86", "Ch1llify", 1 },
                    { 87, new DateTime(2006, 9, 22, 19, 17, 15, 0, DateTimeKind.Unspecified), "member87@gmail.com", "Arnaud", "Claes", "Member87", "Ch1llify", 4 },
                    { 88, new DateTime(1998, 1, 7, 7, 39, 30, 0, DateTimeKind.Unspecified), "member88@gmail.com", "Julien", "Willems", "Member88", "Ch1llify", 4 },
                    { 89, new DateTime(1992, 3, 27, 1, 33, 54, 0, DateTimeKind.Unspecified), "member89@gmail.com", "Catherine", "Wouters", "Member89", "Ch1llify", 1 },
                    { 90, new DateTime(2005, 5, 7, 13, 41, 59, 0, DateTimeKind.Unspecified), "member90@gmail.com", "Simon", "Dubois", "Member90", "Ch1llify", 3 },
                    { 91, new DateTime(2001, 6, 13, 18, 7, 5, 0, DateTimeKind.Unspecified), "member91@gmail.com", "Marie", "Willems", "Member91", "Ch1llify", 5 },
                    { 92, new DateTime(1991, 9, 13, 7, 54, 12, 0, DateTimeKind.Unspecified), "member92@gmail.com", "Simon", "Peeters", "Member92", "Ch1llify", 1 },
                    { 93, new DateTime(1998, 7, 30, 19, 58, 35, 0, DateTimeKind.Unspecified), "member93@gmail.com", "Robin", "Petit", "Member93", "Ch1llify", 4 },
                    { 94, new DateTime(2003, 10, 12, 1, 35, 38, 0, DateTimeKind.Unspecified), "member94@gmail.com", "Martin", "De Smet", "Member94", "Ch1llify", 1 },
                    { 95, new DateTime(2004, 3, 28, 12, 42, 12, 0, DateTimeKind.Unspecified), "member95@gmail.com", "Simon", "Janssens", "Member95", "Ch1llify", 2 },
                    { 96, new DateTime(1998, 4, 2, 23, 2, 2, 0, DateTimeKind.Unspecified), "member96@gmail.com", "Martin", "Moreau", "Member96", "Ch1llify", 2 },
                    { 97, new DateTime(2010, 7, 26, 7, 49, 9, 0, DateTimeKind.Unspecified), "member97@gmail.com", "Arnaud", "Peeters", "Member97", "Ch1llify", 3 },
                    { 98, new DateTime(2022, 2, 24, 18, 20, 38, 0, DateTimeKind.Unspecified), "member98@gmail.com", "Robin", "Goossens", "Member98", "Ch1llify", 1 },
                    { 99, new DateTime(2019, 5, 25, 11, 27, 35, 0, DateTimeKind.Unspecified), "member99@gmail.com", "Julie", "Leroy", "Member99", "Ch1llify", 2 },
                    { 100, new DateTime(1992, 8, 2, 19, 5, 58, 0, DateTimeKind.Unspecified), "member100@gmail.com", "Elisabeth", "Willems", "Member100", "Ch1llify", 5 }
                });

            migrationBuilder.InsertData(
                table: "MemberAddress",
                columns: new[] { "AddressId", "MemberId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 26 },
                    { 27, 27 },
                    { 28, 28 },
                    { 29, 29 },
                    { 30, 30 },
                    { 31, 31 },
                    { 32, 32 },
                    { 33, 33 },
                    { 34, 34 },
                    { 35, 35 },
                    { 36, 36 },
                    { 37, 37 },
                    { 38, 38 },
                    { 39, 39 },
                    { 40, 40 },
                    { 41, 41 },
                    { 42, 42 },
                    { 43, 43 },
                    { 44, 44 },
                    { 45, 45 },
                    { 46, 46 },
                    { 47, 47 },
                    { 48, 48 },
                    { 49, 49 },
                    { 50, 50 },
                    { 51, 51 },
                    { 52, 52 },
                    { 53, 53 },
                    { 54, 54 },
                    { 55, 55 },
                    { 56, 56 },
                    { 57, 57 },
                    { 58, 58 },
                    { 59, 59 },
                    { 60, 60 },
                    { 61, 61 },
                    { 62, 62 },
                    { 63, 63 },
                    { 64, 64 },
                    { 65, 65 },
                    { 66, 66 },
                    { 67, 67 },
                    { 68, 68 },
                    { 69, 69 },
                    { 70, 70 },
                    { 71, 71 },
                    { 72, 72 },
                    { 73, 73 },
                    { 74, 74 },
                    { 75, 75 },
                    { 76, 76 },
                    { 77, 77 },
                    { 78, 78 },
                    { 79, 79 },
                    { 80, 80 },
                    { 81, 81 },
                    { 82, 82 },
                    { 83, 83 },
                    { 84, 84 },
                    { 85, 85 },
                    { 86, 86 },
                    { 87, 87 },
                    { 88, 88 },
                    { 89, 89 },
                    { 90, 90 },
                    { 91, 91 },
                    { 92, 92 },
                    { 93, 93 },
                    { 94, 94 },
                    { 95, 95 },
                    { 96, 96 },
                    { 97, 97 },
                    { 98, 98 },
                    { 99, 99 },
                    { 100, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricMember_EmailAddress",
                table: "HistoricMember",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricMember_Pseudo",
                table: "HistoricMember",
                column: "Pseudo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricMember_RoleId",
                table: "HistoricMember",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricMemberAddress_HistoricAddressId",
                table: "HistoricMemberAddress",
                column: "HistoricAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_EmailAddress",
                table: "Member",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_Pseudo",
                table: "Member",
                column: "Pseudo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_RoleId",
                table: "Member",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_AddressId",
                table: "MemberAddress",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricMemberAddress");

            migrationBuilder.DropTable(
                name: "HistoricRole");

            migrationBuilder.DropTable(
                name: "MemberAddress");

            migrationBuilder.DropTable(
                name: "HistoricAddress");

            migrationBuilder.DropTable(
                name: "HistoricMember");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
