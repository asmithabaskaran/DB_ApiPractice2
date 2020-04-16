using Microsoft.EntityFrameworkCore.Migrations;

namespace DB_ApiPractice2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    recall_number = table.Column<string>(nullable: false),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    reason_for_recall = table.Column<string>(nullable: true),
                    address_1 = table.Column<string>(nullable: true),
                    address_2 = table.Column<string>(nullable: true),
                    code_info = table.Column<string>(nullable: true),
                    product_quantity = table.Column<string>(nullable: true),
                    center_classification_date = table.Column<string>(nullable: true),
                    distribution_pattern = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    product_description = table.Column<string>(nullable: true),
                    report_date = table.Column<string>(nullable: true),
                    classification = table.Column<string>(nullable: true),
                    recalling_firm = table.Column<string>(nullable: true),
                    initial_firm_notification = table.Column<string>(nullable: true),
                    event_id = table.Column<string>(nullable: true),
                    product_type = table.Column<string>(nullable: true),
                    termination_date = table.Column<string>(nullable: true),
                    recall_initiation_date = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(nullable: true),
                    voluntary_mandated = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.recall_number);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
