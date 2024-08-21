using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BADProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animes_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watchlists_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "84b2fd03-216d-4ade-add6-ad358d253337", 0, "a93150f3-acec-445d-b86a-a26543215a52", new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@admin.com", true, "John", "Doe", false, null, "USER@ADMIN.COM", "USER@ADMIN.COM", "AQAAAAIAAYagAAAAEMkYpE8a3BCdbCaVx26PL9pySz4IWD559NHIzxVcdMVJi4PwCddNcPmRQFgi294cKg==", null, false, "e2ccec64-d7d8-49d9-bef4-6ab4bc123995", false, "user@admin.com" },
                    { "f1ff6ef6-ee4e-4b5b-a9ba-81e6575673ce", 0, "b2f302b7-c628-4ef1-8540-8b5b0d9dadfc", new DateTime(1990, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", true, "John", "Wick", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEP9YlpBYUfQjHGNhCxDF+2C7EXdRsSyzPibAEZml+PS4Dkkt7XMrpKHYfz9RWy31Og==", null, false, "14f20fa9-81fc-49b4-a0c9-bdc92f65a0cf", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Comedy" },
                    { 4, "Drama" },
                    { 5, "Fantasy" },
                    { 6, "Horror" },
                    { 7, "Mystery" },
                    { 8, "Romance" },
                    { 9, "Sci-Fi" },
                    { 10, "Thriller" },
                    { 11, "Animation" },
                    { 12, "Crime" },
                    { 13, "Documentary" },
                    { 14, "Family" },
                    { 15, "Historical" }
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Description", "GenreId", "ImageURL", "Release_date", "Title" },
                values: new object[,]
                {
                    { 1, "Humans retreat behind enormous walls from the monstrous Titans, but a young man vows revenge after a personal loss.", 1, "/AttackOnTitan.jpg", new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attack on Titan" },
                    { 2, "An energetic ninja who is shunned by his village for housing a fearsome beast works hard to earn his village's respect.", 1, "/Naruto.jpg", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naruto" },
                    { 3, "A young girl stumbles into a mystical world where she must work in a bathhouse for the gods to free herself and her transformed parents.", 5, "/SpiritedAway.jpg", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spirited Away" },
                    { 4, "A brilliant teen finds a notebook with which he can kill anyone by writing their name, initiating a cat-and-mouse game with authorities.", 6, "/DeathNote.jpg", new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Death Note" },
                    { 5, "In a world where nearly everyone has superpowers, a powerless boy enrolls in an academy for heroes, aiming to become the greatest.", 1, "/MyHeroAcademia.jpg", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Hero Academia" },
                    { 6, "A young pirate and his crew embark on a quest to find the greatest treasure ever left by the legendary Pirate, Gold Roger.", 2, "/OnePiece.jpg", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Piece" },
                    { 7, "A college student gains supernatural abilities after a ghoul organ transplant, finding himself torn between two worlds.", 6, "/TokyoGhoul.jpg", new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokyo Ghoul" },
                    { 8, "Two teenagers share a profound, magical connection upon discovering they are swapping bodies with each other.", 8, "/YourName.jpg", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your Name" },
                    { 9, "Two brothers use alchemy to try to resurrect their mother, but instead they unleash a series of tragic events.", 1, "/FullMetalAlchemist.jpg", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fullmetal Alchemist: Brotherhood" },
                    { 10, "A ragtag crew of bounty hunters chase down the galaxy's most dangerous criminals; they'll save the world for the right price.", 9, "/CowboyBebop.jpg", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cowboy Bebop" },
                    { 11, "Teens pilot giant mechs to protect Earth from mysterious beings, but the pilots' own traumas might pose a greater danger.", 9, "/NeonGenesisEvangelion.jpg", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neon Genesis Evangelion" },
                    { 12, "A group of friends discovers a way to send messages to the past, but their tampering with time leads to unforeseen, dark consequences.", 9, "/SteinsGate.jpg", new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steins;Gate" },
                    { 13, "A young boy follows in his missing father’s footsteps to become a Hunter, facing perilous tasks and dangerous creatures along the way.", 2, "/HunterXHunter.jpg", new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunter x Hunter" },
                    { 14, "An unlikely trio of adventurers in a hip-hop infused version of Edo-era Japan search for a samurai who smells of sunflowers.", 12, "/SamuraiChamploo.jpg", new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samurai Champloo" },
                    { 15, "In a future Japan, the Sibyl System assesses everyone’s threat level, but what happens when the system itself is flawed?", 10, "/PsychoPass.jpg", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psycho-Pass" },
                    { 16, "A passionate high school student with dreams of volleyball glory faces challenges and builds friendships on his journey to the top.", 14, "/Haikyuu.jpg", new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haikyuu!!" },
                    { 17, "Continuing from Clannad, the story follows the challenges and heartwarming moments of life after high school.", 4, "/Clanned.jpg", new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clannad: After Story" },
                    { 18, "A girl and her mysterious robot friend descend into the Abyss, a terrifyingly deep chasm, to uncover the truth about her mother.", 5, "/MadeInAbyss.jpg", new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Made in Abyss" },
                    { 19, "In an Edo-era Japan conquered by aliens, the samurai Gintoki navigates the oddities of life with humor and heart.", 3, "/Gintama.jpg", new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gintama" },
                    { 20, "A kind-hearted boy becomes a demon slayer to avenge his family slaughtered by demons and to cure his demon-turned sister.", 1, "/DemonSlayer.jpg", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demon Slayer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "CanManageCatalog", "true", "84b2fd03-216d-4ade-add6-ad358d253337" });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_GenreId",
                table: "Animes",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AnimeId",
                table: "Reviews",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_AnimeId",
                table: "Watchlists",
                column: "AnimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Watchlists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
