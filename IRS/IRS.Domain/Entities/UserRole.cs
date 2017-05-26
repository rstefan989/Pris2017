using System;
using System.Collections.Generic;

namespace IRS.Domain.Entities
{
    public class UserRole
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
