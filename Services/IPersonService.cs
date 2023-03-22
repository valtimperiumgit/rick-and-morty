using RickAndMorty.Api.Models.Entities;

namespace RickAndMorty.Api.Services;

public interface IPersonService
{
    Task<bool> CheckPersonInEpisodeExist(string personName, string episodName);

    Task<Person> GetPersonByName(string name);
}