using FluentMigrator;

namespace DataAccess.Migrations;

[Migration(20240513204900, TransactionBehavior.None)]
public class InitialOrderTableMigration : Migration
{
    public override void Up()
    {
        const string query = @"
                             CREATE TABLE IF NOT EXISTS ""Orders"" (
                                 ""Id"" UUID PRIMARY KEY,
                                 ""Address"" VARCHAR(256) NOT NULL,
                                 ""Description"" VARCHAR(256),
                                 ""CreationData"" DATE NOT NULL,
                                 ""Status"" INT NOT NULL
                             );
                             
                             ";
        Execute.Sql(query);
    }

    public override void Down()
    {
        const string query = @"
                             DROP TABLE ""Orders"";
                             ";
        Execute.Sql(query);
    }
}