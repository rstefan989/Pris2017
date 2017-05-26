using IRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Infrastructure.EF.EntityConfigurations
{
    public class UserRoleEntityConfiguration: EntityTypeConfiguration<UserRole>
    {
        public UserRoleEntityConfiguration()
        {
            HasKey(x => x.Id);
            this.Property(p => p.Name).IsRequired().HasMaxLength(50);
            this.Property(p => p.Description).HasMaxLength(100);

            HasMany(x => x.Users).WithRequired(x => x.UserRole).HasForeignKey(x => x.RoleId);
        }
    }
}
