namespace IRS.Infrastructure.EF
{
    using EntityConfigurations;
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using Domain.Entities;
    using YuSpin.Fw.EntityFramework;
    using System.Collections.Generic;
    using YuSpin.Fw.EntityFramework.StoredProcedures;
    using Domain.Interfaces.QC;
    using System.Data.Entity.Validation;
    using System.Text;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            ID = Guid.NewGuid().ToString();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new UserRoleEntityConfiguration());

        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        public string ID { get; set; }

        public int SaveChangesWithErrors()
        {
            try
            {
                return SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    ); // Add the original exception as the innerException
            }
        }

        #region Implementations of IDataContext
        public List<T> ExecuteQuery<T>(IQuery sp) where T : class
        {
            return Database.ExecuteQuery<T>(sp);
        }

        public ResultSets ExecuteQuery(IQuery query)
        {
            return Database.ExecuteQuery(query);
        }

        public void ExecuteCommand(ICommand command)
        {
            Database.ExecuteNonQuery(command);
        }

        public T ExecuteScalar<T>(StoredProcedure storedProc) where T : class
        {
            return Database.ExecuteScalar<T>(storedProc);
        }
        #endregion
    }
}