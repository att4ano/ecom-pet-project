using FluentMigrator;

namespace DataAccess.Migrations;

[Migration(20240513203100, TransactionBehavior.None)]
public class InitialProductTableMigration : Migration
{
    public override void Up()
    {
        const string query = @"
                             CREATE TABLE IF NOT EXISTS ""Product"" (
                                 ""Id"" UUID PRIMARY KEY,
                                 ""ProductName"" VARCHAR(256) NOT NULL,
                                 ""CategoryId"" UUID NOT NULL,
                                 ""Price"" DECIMAL(18, 2) NOT NULL,
                                 ""Description"" VARCHAR(256),
                                 FOREIGN KEY (""CategoryId"") REFERENCES ""ProductCategory""(""Id"")
                             );
                             ";
        Execute.Sql(query);
    }

    public override void Down()
    {
        const string query = @"
                             DROP TABLE ""Product"";
                             ";
        Execute.Sql(query);
    }
}