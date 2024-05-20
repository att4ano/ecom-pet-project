using FluentMigrator;

namespace DataAccess.Migrations;

[Migration(20240513204700, TransactionBehavior.None)]
public class InitialOrderItemTableMigration : Migration
{
    public override void Up()
    {
        const string query = @"
                             CREATE TABLE IF NOT EXISTS ""OrderItem"" (
                                 ""Id"" UUID PRIMARY KEY,
                                 ""ProductId"" UUID NOT NULL,
                                 ""OrderId"" UUID NOT NULL,
                                 ""Amount"" INT NOT NULL,
                                 FOREIGN KEY (""ProductId"") REFERENCES ""Product""(""Id"")
                             );
                             ";
        Execute.Sql(query);
    }

    public override void Down()
    {
        const string query = @"
                             DROP TABLE ""OrderItem"";
                             ";
        Execute.Sql(query);
    }
}