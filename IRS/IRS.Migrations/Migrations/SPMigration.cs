using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace IRS.Migrations.Migrations
{
    public abstract class SPMigration : DbMigration
    {
        public void ExecuteScriptFile(string fileName, string path)
        {
            var file = Directory.GetFiles(path, fileName).First();
            SqlFile(file);
        }

        public void ExecuteStoredProcedureSQLFile(string fileName, string storedProcedureName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Migrations\SPMigrations");
            var file = Directory.GetFiles(path, fileName).First();
            DropStoredProcedureSQL(storedProcedureName);
            SqlFile(file);
        }

        public void DropStoredProcedureSQL(string storedProcedureName)
        {
            var sqlQuery = string.Format("DROP PROCEDURE IF EXISTS {0};", storedProcedureName);
            Sql(sqlQuery);
        }
    }
}
