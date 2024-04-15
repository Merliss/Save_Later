using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaveLater.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookEventUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlidesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchFacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchYoutbeLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlreadyHappend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DisplayName", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programowanie info", null, null, "programowanie" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", null, null, "csharp" },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Android info", null, null, "android" },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Docker", null, null, "docker" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AlreadyHappend", "Date", "Description", "FacebookEventUrl", "ImageUrl", "SlidesUrl", "Title", "WatchFacebookLink", "WatchYoutbeLink" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2024, 4, 6, 15, 57, 53, 678, DateTimeKind.Local).AddTicks(9087), "Ustalenie architektury nie jest prostym zadaniem. Każda decyzja może mieć wielkie komplikacje potem.", "https://www.facebook.com/events/407358067213893/", "https://cezarywalenciuk.pl/posts/fileswebinars/17_apliacjacsharpodzeraarchitekturacqrs.jpg", "", "Aplikacja C# od Zera Architektura, CQRS, Dobre praktyki", "", "" },
                    { 2, false, new DateTime(2024, 2, 16, 15, 57, 53, 678, DateTimeKind.Local).AddTicks(9156), "Kontenery są tutaj. Kubernetes jest de facto platformą do ich uruchamiania i zarządzania.", "https://www.facebook.com/events/407358067213893/", "https://cezarywalenciuk.pl/posts/fileswebinars/17_apliacjacsharpodzeraarchitekturacqrs.jpg", "https://panniebieski.github.io/webinar-Kubernetes-Docker-Wytlumacz-mi-i-pokaz/", "Kubernetes i Docker : Wytłumacz mi i pokaż", "https://www.facebook.com/watch/live/?v=2775230679405348&ref=watch_permalink", "https://www.youtube.com/watch?v=7g00wOg9Jto" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "CategoryId", "Created", "Description", "ImageUrl", "Rate", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Damian", 1, new DateTime(2023, 9, 27, 15, 57, 53, 678, DateTimeKind.Local).AddTicks(9217), "Nasze aplikacje ASP.NET CORE coraz częściej są tylko aplikacją REST. To oczywiście wymaga Walidacji po stronie klienta i po stronie serwera\r\n                Jak taką walidację jak najszybciej zrobić.Może przecież sam napisać takie warunki,\r\n                ale przy dużej ilości klas,\r\n                które występują jako parametry mija się to z celem.\r\n\r\n                Możesz też skorzystać z atrybutów i oznaczyć reguły do każdej właściwości.", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 8, "Walidacja z FluentValidation w ASP.NET Core + Swagger", "https://cezarywalenciuk.pl/blog/programing/walidacja-z-fluentvalidation-waspnet-core--swagger" },
                    { 2, "Ewa", 1, new DateTime(2023, 11, 27, 15, 57, 53, 678, DateTimeKind.Local).AddTicks(9227), "Implementacja autoryzacji i uwierzytelniania w aplikacjach ASP.NET Core jest kluczowa dla zapewnienia bezpieczeństwa.\r\n    Często wykorzystuje się tu gotowe mechanizmy, takie jak JWT lub sesje.", "https://example.com/your-image2.png", 9, "Autoryzacja i uwierzytelnianie w ASP.NET Core", "https://example.com/your-url2" },
                    { 3, "Jan", 3, new DateTime(2024, 1, 27, 15, 57, 53, 678, DateTimeKind.Local).AddTicks(9232), "Efektywne zarządzanie bazą danych w aplikacjach ASP.NET Core to kluczowy element wydajności i skalowalności systemu.\r\n    Warto zastosować narzędzia ORM, takie jak Entity Framework Core, oraz pamiętać o optymalizacji zapytań.", "https://example.com/your-image3.png", 7, "Zarządzanie bazą danych w ASP.NET Core + Android", "https://example.com/your-url3" },
                    { 4, "Katarzyna", 4, new DateTime(2024, 2, 27, 15, 57, 53, 678, DateTimeKind.Local).AddTicks(9236), "Wytwarzanie interfejsów użytkownika w aplikacjach ASP.NET Core wymaga nie tylko znajomości HTML, CSS i JavaScript,\r\n    ale także narzędzi i bibliotek, takich jak Angular, React czy Vue.js. Docker", "https://example.com/your-image4.png", 8, "Tworzenie interfejsów użytkownika w ASP.NET Core w Docker", "https://example.com/your-url4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
