﻿using PRISSafari.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PRISSafari.Repositories.Configurators
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(p => p.FirstName).HasMaxLength(60);
            Property(p => p.LastName).HasMaxLength(60);
            Property(p => p.Email).HasMaxLength(200);
        }
    }
}