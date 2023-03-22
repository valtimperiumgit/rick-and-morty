using RickAndMorty.Api.Models.Enums;

namespace RickAndMorty.Api.Models.Entities;

  public class Person
    {
        public Person(
            int id, 
            string name,
            PersonStatus status, 
            string species, 
            string type, 
            PersonGender gender, 
            Location location,
            CharacterOrigin origin, 
            Uri image,
            IEnumerable<Uri> episode,
            Uri url, 
            DateTime? created)
        {
            Id = id;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            Location = location;
            Origin = origin;
            Image = image;
            Episode = episode;
            Url = url;
            Created = created;
        }

        public int Id { get; }

        public string Name { get; }
        
        public PersonStatus Status { get; }
        
        public string Species { get; }
        
        public string Type { get; }

        public PersonGender Gender { get; }
        
        public Location Location { get; }
        
        public CharacterOrigin Origin { get; }

        public Uri Image { get; }

        public IEnumerable<Uri> Episode { get; }

        public Uri Url { get; }
        
        public DateTime? Created { get; }
    }