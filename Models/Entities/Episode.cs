namespace RickAndMorty.Api.Models.Entities;

    public class Episode
    {
        public Episode(
            int id,
            string name,
            string air_Date,
            string episode,
            IEnumerable<Uri> characters,
            Uri url, 
            DateTime? created
            )
        {
            Id = id;
            Name = name;
            AirDate = air_Date;
            EpisodeCode = episode;
            Characters = characters;
            Url = url;
            Created = created;
        }

        public int Id { get; }
        
        public string Name { get; }
        
        public string AirDate { get; }
        
        public string EpisodeCode { get; }
        
        public IEnumerable<Uri> Characters { get; }
        
        public Uri Url { get; }
        
        public DateTime? Created { get; }
    }