using IRS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace IRS.Infrastructure.EF.EntityConfigurations.Base
{
    public class EntityConfigurationBase<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public EntityConfigurationBase()
        {
            HasKey(x => x.Id);
        }
    }
}
