using FluentMigrator;

namespace DataAccess.Migrations;

[Migration(20240513183900, TransactionBehavior.None)]
public class InitialProductCategoryTableMigration : Migration
{
    public override void Up()
    {
        const string query = @"
                             CREATE TABLE IF NOT EXISTS ""ProductCategory"" (
                                 ""Id"" UUID PRIMARY KEY,
                                 ""CategoryName"" VARCHAR(256) NOT NULL
                             );
                             ";

        Execute.Sql(query);
    }

    public override void Down()
    {
        const string query = @"
                             DROP TABLE ""ProductCategory"";
                             ";
        Execute.Sql(query);
    }
}