using Domain.Models;
using FluentMigrator;

namespace DataAccess.Migrations;

[Migration(20240514214500, TransactionBehavior.None)]
public class FakeProductCategoryMigration : Migration
{
    public override void Up()
    {
        for (var i = 0; i < 10; ++i)
        {
            Insert.IntoTable("ProductCategory")
                .Row(new
                {
                    Id = Guid.NewGuid(),
                    CategoryName = Faker.Company.Name()
                });
        }
    }

    public override void Down()
    {
        Delete.FromTable("ProductCategory").AllRows();
    }
}