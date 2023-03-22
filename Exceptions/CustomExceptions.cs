namespace RickAndMorty.Api.Exceptions;

public class CustomExceptions
{
    public class Person
    {
        public static readonly CustomException PersonNotFound = new
            (StatusCodes.Status404NotFound, "Person not found.");
    }
    
    public class Episode
    {
        public static readonly CustomException EpisodeNotFound = new
            (StatusCodes.Status404NotFound, "Episode not found.");
    }
}