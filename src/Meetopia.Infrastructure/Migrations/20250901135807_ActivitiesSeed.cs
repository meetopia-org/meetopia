using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meetopia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActivitiesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "IsCancelled", "Latitude", "Longitude", "Title", "Venue" },
                values: new object[,]
                {
                    { "activity-1", "drinks", "London", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 2 months ago", false, 51.511716649999997, -0.1256611057818921, "Past Activity 1", "The Lamb and Flag, 33, Rose Street, Seven Dials, Covent Garden, London, Greater London, England, WC2E 9EB, United Kingdom" },
                    { "activity-10", "film", "London", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 8 months in future", false, 51.5575525, -0.78140399999999999, "Future Activity 8", "River Thames, England, United Kingdom" },
                    { "activity-2", "culture", "Paris", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 1 month ago", false, 48.861147299999999, 2.3380276870466599, "Past Activity 2", "Louvre Museum, Rue Saint-Honoré, Quartier du Palais Royal, 1st Arrondissement, Paris, Ile-de-France, Metropolitan France, 75001, France" },
                    { "activity-3", "culture", "London", new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 1 month in future", false, 51.496510900000004, -0.17600190725447445, "Future Activity 1", "Natural History Museum" },
                    { "activity-4", "music", "London", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 2 months in future", false, 51.502936649999995, 0.0032029278126681844, "Future Activity 2", "The O2" },
                    { "activity-5", "drinks", "London", new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 3 months in future", false, 51.501778000000002, -0.053577, "Future Activity 3", "The Mayflower" },
                    { "activity-6", "drinks", "London", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 4 months in future", false, 51.512146650000005, -0.10364680647106028, "Future Activity 4", "The Blackfriar" },
                    { "activity-7", "culture", "London", new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 5 months in future", false, 51.523762900000001, -0.15847430000000001, "Future Activity 5", "Sherlock Holmes Museum, 221b, Baker Street, Marylebone, London, Greater London, England, NW1 6XE, United Kingdom" },
                    { "activity-8", "music", "London", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 6 months in future", false, 51.543250499999999, -0.15197608174931165, "Future Activity 6", "Roundhouse, Chalk Farm Road, Maitland Park, Chalk Farm, London Borough of Camden, London, Greater London, England, NW1 8EH, United Kingdom" },
                    { "activity-9", "travel", "London", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Activity 2 months ago", false, 51.5575525, -0.78140399999999999, "Future Activity 7", "River Thames, England, United Kingdom" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-1");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-10");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-2");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-3");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-4");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-5");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-6");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-7");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-8");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: "activity-9");
        }
    }
}
