using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Haczykowefajtlapy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FishingCompetitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CompetitionType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishingCompetitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LicenseValidUntil = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MembershipFeePaid = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    CompetitionId = table.Column<int>(type: "integer", nullable: false),
                    FishType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Place = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_FishingCompetitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "FishingCompetitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FishingLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FishType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishingLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FishingLogs_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FishingCompetitions",
                columns: new[] { "Id", "CompetitionType", "Date", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Club", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Lake Nord", "Spring Challenge" },
                    { 2, "Open", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), "River East", "Summer Derby" },
                    { 3, "Club", new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Bay West", "Autumn Cup" },
                    { 4, "Open", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Lake South", "Winter Tournament" },
                    { 5, "Club", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Lake Nord", "New Year Bash" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 1, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member1@fishingclub.com", "Member1", true, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname1", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001001" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 2, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member2@fishingclub.com", "Member2", true, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname2", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001002" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 3, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member3@fishingclub.com", "Member3", false, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname3", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001003" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 4, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member4@fishingclub.com", "Member4", true, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname4", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001004" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 5, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member5@fishingclub.com", "Member5", true, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname5", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001005" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 6, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member6@fishingclub.com", "Member6", false, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname6", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001006" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 7, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member7@fishingclub.com", "Member7", true, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname7", new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001007" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 8, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member8@fishingclub.com", "Member8", true, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname8", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001008" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 9, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member9@fishingclub.com", "Member9", false, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname9", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001009" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 10, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member10@fishingclub.com", "Member10", true, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname10", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001010" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 11, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member11@fishingclub.com", "Member11", true, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname11", new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001011" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 12, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member12@fishingclub.com", "Member12", false, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname12", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001012" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 13, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member13@fishingclub.com", "Member13", true, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname13", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001013" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 14, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member14@fishingclub.com", "Member14", true, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname14", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001014" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 15, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member15@fishingclub.com", "Member15", false, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname15", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001015" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 16, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member16@fishingclub.com", "Member16", true, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname16", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001016" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 17, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member17@fishingclub.com", "Member17", true, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname17", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001017" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 18, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member18@fishingclub.com", "Member18", false, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname18", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001018" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "Phone" },
                values: new object[] { 19, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member19@fishingclub.com", "Member19", true, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname19", new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), "6001001019" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "IsActive", "JoinDate", "LastName", "LicenseValidUntil", "MembershipFeePaid", "Phone" },
                values: new object[] { 20, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "member20@fishingclub.com", "Member20", true, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Surname20", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, "6001001020" });

            migrationBuilder.InsertData(
                table: "CompetitionResults",
                columns: new[] { "Id", "CompetitionId", "FishType", "MemberId", "Place", "Weight" },
                values: new object[,]
                {
                    { 1, 1, "Pike", 1, 1, 1.5m },
                    { 2, 1, "Carp", 2, 2, 2.0m },
                    { 3, 1, "Pike", 3, 3, 2.5m },
                    { 4, 1, "Carp", 4, 4, 3.0m },
                    { 5, 1, "Pike", 5, 5, 3.5m },
                    { 6, 1, "Carp", 6, 6, 4.0m },
                    { 7, 1, "Pike", 7, 7, 4.5m },
                    { 8, 1, "Carp", 8, 8, 5.0m },
                    { 9, 1, "Pike", 9, 9, 5.5m },
                    { 10, 1, "Carp", 10, 10, 6.0m },
                    { 11, 2, "Pike", 1, 1, 1.5m },
                    { 12, 2, "Carp", 2, 2, 2.0m },
                    { 13, 2, "Pike", 3, 3, 2.5m },
                    { 14, 2, "Carp", 4, 4, 3.0m },
                    { 15, 2, "Pike", 5, 5, 3.5m },
                    { 16, 2, "Carp", 6, 6, 4.0m },
                    { 17, 2, "Pike", 7, 7, 4.5m },
                    { 18, 2, "Carp", 8, 8, 5.0m },
                    { 19, 2, "Pike", 9, 9, 5.5m },
                    { 20, 2, "Carp", 10, 10, 6.0m },
                    { 21, 3, "Pike", 1, 1, 1.5m },
                    { 22, 3, "Carp", 2, 2, 2.0m },
                    { 23, 3, "Pike", 3, 3, 2.5m },
                    { 24, 3, "Carp", 4, 4, 3.0m },
                    { 25, 3, "Pike", 5, 5, 3.5m },
                    { 26, 3, "Carp", 6, 6, 4.0m },
                    { 27, 3, "Pike", 7, 7, 4.5m },
                    { 28, 3, "Carp", 8, 8, 5.0m },
                    { 29, 3, "Pike", 9, 9, 5.5m },
                    { 30, 3, "Carp", 10, 10, 6.0m },
                    { 31, 4, "Pike", 1, 1, 1.5m },
                    { 32, 4, "Carp", 2, 2, 2.0m },
                    { 33, 4, "Pike", 3, 3, 2.5m },
                    { 34, 4, "Carp", 4, 4, 3.0m },
                    { 35, 4, "Pike", 5, 5, 3.5m },
                    { 36, 4, "Carp", 6, 6, 4.0m },
                    { 37, 4, "Pike", 7, 7, 4.5m },
                    { 38, 4, "Carp", 8, 8, 5.0m },
                    { 39, 4, "Pike", 9, 9, 5.5m },
                    { 40, 4, "Carp", 10, 10, 6.0m },
                    { 41, 5, "Pike", 1, 1, 1.5m },
                    { 42, 5, "Carp", 2, 2, 2.0m },
                    { 43, 5, "Pike", 3, 3, 2.5m },
                    { 44, 5, "Carp", 4, 4, 3.0m },
                    { 45, 5, "Pike", 5, 5, 3.5m },
                    { 46, 5, "Carp", 6, 6, 4.0m },
                    { 47, 5, "Pike", 7, 7, 4.5m },
                    { 48, 5, "Carp", 8, 8, 5.0m },
                    { 49, 5, "Pike", 9, 9, 5.5m },
                    { 50, 5, "Carp", 10, 10, 6.0m }
                });

            migrationBuilder.InsertData(
                table: "FishingLogs",
                columns: new[] { "Id", "Date", "FishType", "Location", "MemberId", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 1, 0.75m },
                    { 2, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 2, 1.00m },
                    { 3, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 3, 1.25m },
                    { 4, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 4, 1.50m },
                    { 5, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 5, 0.50m },
                    { 6, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 6, 0.75m },
                    { 7, new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 7, 1.00m },
                    { 8, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 8, 1.25m },
                    { 9, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 9, 1.50m },
                    { 10, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 10, 0.50m },
                    { 11, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 11, 0.75m },
                    { 12, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 12, 1.00m },
                    { 13, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 13, 1.25m },
                    { 14, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 14, 1.50m },
                    { 15, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 15, 0.50m },
                    { 16, new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 16, 0.75m },
                    { 17, new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 17, 1.00m },
                    { 18, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 18, 1.25m },
                    { 19, new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 19, 1.50m },
                    { 20, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 20, 0.50m },
                    { 21, new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 1, 0.75m },
                    { 22, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 2, 1.00m },
                    { 23, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 3, 1.25m },
                    { 24, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 4, 1.50m },
                    { 25, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 5, 0.50m },
                    { 26, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 6, 0.75m },
                    { 27, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 7, 1.00m },
                    { 28, new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 8, 1.25m },
                    { 29, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 9, 1.50m },
                    { 30, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 10, 0.50m },
                    { 31, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 11, 0.75m },
                    { 32, new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 12, 1.00m },
                    { 33, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 13, 1.25m },
                    { 34, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 14, 1.50m },
                    { 35, new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 15, 0.50m },
                    { 36, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 16, 0.75m },
                    { 37, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 17, 1.00m },
                    { 38, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 18, 1.25m },
                    { 39, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 19, 1.50m },
                    { 40, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 20, 0.50m },
                    { 41, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 1, 0.75m },
                    { 42, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 2, 1.00m },
                    { 43, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 3, 1.25m },
                    { 44, new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 4, 1.50m },
                    { 45, new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 5, 0.50m },
                    { 46, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 6, 0.75m },
                    { 47, new DateTime(2023, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 7, 1.00m },
                    { 48, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 8, 1.25m },
                    { 49, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Bream", "Lake Nord", 9, 1.50m },
                    { 50, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Roach", "River East", 10, 0.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_CompetitionId",
                table: "CompetitionResults",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_MemberId",
                table: "CompetitionResults",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FishingLogs_MemberId",
                table: "FishingLogs",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionResults");

            migrationBuilder.DropTable(
                name: "FishingLogs");

            migrationBuilder.DropTable(
                name: "FishingCompetitions");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
