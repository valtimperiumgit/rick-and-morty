using RickAndMorty.Api.Exceptions;
using RickAndMorty.Api.Integrations.RickAndMorty;
using RickAndMorty.Api.Models.Entities;

namespace RickAndMorty.Api.Services;

public class PersonService : IPersonService
{
    private readonly IRickAndMortyClient _rickAndMortyClient;

    public PersonService(IRickAndMortyClient rickAndMortyClient)
    {
        _rickAndMortyClient = rickAndMortyClient;
    }

    public async Task<bool> CheckPersonInEpisodeExist(string personName, string episodName)
    {
        var persons = await _rickAndMortyClient.GetFilterPersons("name", personName);

        if (!persons.Select(person => person.Name).Contains(personName))
        {
            throw CustomExceptions.Person.PersonNotFound;
        }
        
        var episode = await _rickAndMortyClient.GetFilterEpisode("name", episodName);

        if (episode.Name != episodName)
        {
            throw CustomExceptions.Episode.EpisodeNotFound;
        }
        
        var personsEpisodes = persons.Select(person => person.Episode)
            .SelectMany(episodes => episodes)
            .ToList();

        return personsEpisodes.Contains(episode.Url);
    }

    public async Task<Person> GetPersonByName(string name)
    {
        var persons = await _rickAndMortyClient.GetFilterPersons("name", name);
        
        if (!persons.Select(person => person.Name).Contains(name))
        {
            throw CustomExceptions.Person.PersonNotFound;
        }

        return persons.FirstOrDefault();
    }
}