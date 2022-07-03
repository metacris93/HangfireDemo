using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangfireDemo.Migrations
{
    public partial class PersonView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW person_view AS
                                   SELECT ""Id"", ""Name""
                                   FROM ""Persons"";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW person_view;");
        }
    }
}
