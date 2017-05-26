using System;
namespace IRS.Domain.Entities
{
    public class ConcurrentEntityBase: EntityBase
    {
        public ConcurrentEntityBase()
        {
            RowVersion = DateTime.Now;
        }
                
        public DateTime RowVersion { get; set; }
    }
}
