namespace BADProject.Domain.Entities
{
    public class Reviews
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public DateTime DateTime { get; set; }
        public string Review { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
