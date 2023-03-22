namespace RickAndMorty.Api.Integrations.RickAndMorty.Models;

public class Info
{
    public Info(int count, int page, string next, string prev)
    {
        Count = count;
        Page = page;
        Next = next;
        Prev = prev;
    }

    public int Count { get; set; }
    
    public int Page { get; set; }
    
    public string Next { get; set; }
    
    public string Prev { get; set; }
}