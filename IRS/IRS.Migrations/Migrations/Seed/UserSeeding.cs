using System.Linq;
using IRS.Infrastructure.EF;
using System.Data.Entity.Migrations;
using IRS.Domain.Entities;
using YuSpin.Fw.Cryptography;

namespace IRS.Migrations.Migrations.Seed
{
    public class UserSeeding
    {
        public void Seed(DataContext context)
        {
            context.UserRole.AddOrUpdate(x => x.Name,
                new UserRole() {Id=1,Name = "Admin" },
                new UserRole() {Id=2,Name = "User" });

            context.SaveChanges();
        }
    }
}

