using FluentMigrator;

namespace RoomyTestTask.Migrations
{
    [Migration(202106280001)]
    public class InitialTables_202306010001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Document");
            Delete.Table("Payment");
        }

        public override void Up()
        {
            Create.Table("Document")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable();
            Create.Table("Payment")
                .WithColumn("UserId").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Surname").AsString(50).NotNullable()
                .WithColumn("ContractNumber").AsString(50).NotNullable()
                .WithColumn("WriteOffAmount").AsInt32().NotNullable()
                .WithColumn("DocumentId").AsGuid().NotNullable().PrimaryKey().ForeignKey("Document", "Id");
        }
    }
}
