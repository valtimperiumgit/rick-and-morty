using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RickAndMorty.Api.Integrations;
using RickAndMorty.Api.Integrations.RickAndMorty;
using RickAndMorty.Api.Models.Dto;
using RickAndMorty.Api.Services;

namespace RickAndMorty.Api.Controllers;

[Route("api/v1/")]
public class V1Controller : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly IMemoryCache _cache;

    public V1Controller(IPersonService personService, IMemoryCache cache)
    {
        _personService = personService;
        _cache = cache;
    }

    [HttpPost("check-person")]
    public async Task<IActionResult> CheckPerson([FromBody] CheckPersonDto dto)
    {
        var cacheKey = $"check-person/personName/{dto.PersonName}/episodeName/{dto.EpisodeName}";
        if (!_cache.TryGetValue(cacheKey, out string? data))
        {   
            data = JsonConvert.SerializeObject(await _personService
                .CheckPersonInEpisodeExist(dto.PersonName, dto.EpisodeName));
            SaveToCache(cacheKey, data);
        }
        
        return Ok(data);
    }
    
    [HttpGet("person")]
    public async Task<IActionResult> GetPerson([FromQuery] string name)
    {
        var cacheKey = $"person/name/{name}";
        if (!_cache.TryGetValue(cacheKey, out string? data))
        {   
            data = JsonConvert.SerializeObject(await _personService
                .GetPersonByName(name));
            SaveToCache(cacheKey, data);
        }
        
        return Ok(data);
    }

    private void SaveToCache(string key, string jsonData)
    {
        var cacheOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
        };
            
        _cache.Set(key, jsonData, cacheOptions);
    }
}