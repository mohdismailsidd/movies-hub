namespace EVideoPrime.API.Entities.VideoPrime
{
    public partial class Movie
    {
        public Movie()
        {
            Languages = new HashSet<Language>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Thumbnail { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string VideoUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
    }
}