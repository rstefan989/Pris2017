namespace PRISSafari.Domain.Entities
{
    public class Comment : Entity
    {
        public string Description { get; set; }
        public int UserRating { get; set; } //Prodavac i kupac mogu da ocenjuju jedan drugog po zavrsenoj primopredaji 
        public int UserId { get; set; }
        public int CreatedByUserId { get; set; }

        public virtual User User { get; set; }
        public virtual User CreatedByUser { get; set; }
    }
}
