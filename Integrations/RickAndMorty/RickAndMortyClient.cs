using System.Collections.Specialized;
using Newtonsoft.Json;
using RickAndMorty.Api.Exceptions;
using RickAndMorty.Api.Helpers;
using RickAndMorty.Api.Integrations.RickAndMorty.Responses;
using RickAndMorty.Api.Models.Entities;

namespace RickAndMorty.Api.Integrations.RickAndMorty;

public class RickAndMortyClient : IRickAndMortyClient
{
    private readonly HttpClient _httpClient;

    public RickAndMortyClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Person>> GetFilterPersons(string parameter, string value)
    {
        var queryParameters = new NameValueCollection
        {
            { $"{parameter}", $"{value}" }
        };

        var builder = new UriBuilder($"{_httpClient.BaseAddress}api/character/")
        {
            Query = HttpHelper.ToQueryString(queryParameters)
        };
        
        var response = await _httpClient.GetAsync(builder.Uri);

        if (!response.IsSuccessStatusCode)
        {
            throw CustomExceptions.Person.PersonNotFound;
        }
        
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<GetMultipleObjectsResponse<Person>>(responseString);

        return result.Results;
    }

    public async Task<Episode> GetFilterEpisode(string parameter, string value)
    {
        var queryParameters = new NameValueCollection
        {
            { $"{parameter}", $"{value}" }
        };

        var builder = new UriBuilder($"{_httpClient.BaseAddress}api/episode/")
        {
            Query = HttpHelper.ToQueryString(queryParameters)
        };
        
        var response = await _httpClient.GetAsync(builder.Uri);

        if (!response.IsSuccessStatusCode)
        {
            throw CustomExceptions.Episode.EpisodeNotFound;
        }
        
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<GetMultipleObjectsResponse<Episode>>(responseString);

        return result.Results.FirstOrDefault();
    }
}