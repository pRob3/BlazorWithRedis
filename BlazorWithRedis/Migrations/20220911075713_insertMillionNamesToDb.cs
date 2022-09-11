using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWithRedis.Migrations
{
    public partial class insertMillionNamesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int i = 0; i < 1000000; i++)
            {
                migrationBuilder.Sql($"INSERT INTO Users (FirstName, LastName) VALUES ('John {i}', 'Smith {i}');");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users;");
        }
    }
}
