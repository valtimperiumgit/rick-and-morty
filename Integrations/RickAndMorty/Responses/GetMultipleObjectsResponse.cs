using RickAndMorty.Api.Integrations.RickAndMorty.Models;
using RickAndMorty.Api.Models.Entities;

namespace RickAndMorty.Api.Integrations.RickAndMorty.Responses;

public class GetMultipleObjectsResponse<T>
{
    public Info Info { get; set; }
    public List<T> Results { get; set; }
}