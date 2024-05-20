using FluentMigrator;

namespace DataAccess.Migrations;

[Migration(20240513183800, TransactionBehavior.None)]
public class EmptyMigration : Migration
{
    public override void Up()
    {
    }

    public override void Down()
    {
    }
}