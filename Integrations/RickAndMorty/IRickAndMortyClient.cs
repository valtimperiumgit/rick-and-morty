

using RickAndMorty.Api.Models.Entities;

namespace RickAndMorty.Api.Integrations.RickAndMorty;

public interface IRickAndMortyClient
{
    public Task<List<Person>> GetFilterPersons(string parameter, string value);

    public Task<Episode> GetFilterEpisode(string parameter, string value);
}