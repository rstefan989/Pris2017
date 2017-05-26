namespace IRS.Migrations.Migrations
{

    public partial class SP_DemoMaster_list : SPMigration
    {
        public override void Up()
        {
            ExecuteStoredProcedureSQLFile("DemoMasterList_000001.sql", "DemoMasterList");
        }

        public override void Down()
        {
            DropStoredProcedureSQL("DemoMasterList");
        }
    }
}
