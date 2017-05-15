using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using PRISSafari.Domain.Entities;

namespace PRISSafari.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            RegisterEntities(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        private void RegisterEntities(DbModelBuilder modelBuilder)
        {
            MethodInfo entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
            var a = Assembly.GetAssembly(typeof(Entity)).GetTypes();

            IEnumerable<Type> entityTypes = Assembly.GetAssembly(typeof(Entity)).GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Entity)) && !x.IsAbstract);
            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
            }
        }
    }
}
