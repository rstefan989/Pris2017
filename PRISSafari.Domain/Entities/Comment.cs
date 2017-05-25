namespace PRISSafari.Domain.Entities
{
    public class Comment : Entity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CreatedByUserId { get; set; }

        public virtual User User { get; set; }
        public virtual User CreatedByUser { get; set; }
    }
}
