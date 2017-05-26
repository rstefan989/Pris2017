namespace IRS.Migrations.Migrations
{
    using Seed;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<IRS.Infrastructure.EF.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
            CodeGenerator = new MySql.Data.Entity.MySqlMigrationCodeGenerator();
        }

        protected override void Seed(IRS.Infrastructure.EF.DataContext context)
        {
            var userSeeding = new UserSeeding();
            userSeeding.Seed(context);

            context.SaveChangesWithErrors();
        }
    }
}
