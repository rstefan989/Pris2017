using IRS.Domain.Entities;

namespace IRS.Infrastructure.EF.EntityConfigurations.Base
{

    public class ConcurrentEntityConfigurationBase<TEntity> : EntityConfigurationBase<TEntity> where TEntity : ConcurrentEntityBase
    {
        public ConcurrentEntityConfigurationBase()
        {
            HasKey(x => x.Id);

            Property(x => x.RowVersion)
                .HasPrecision(6)
                .HasColumnType("timestamp")
                .IsConcurrencyToken(true);
        }
    }
}
