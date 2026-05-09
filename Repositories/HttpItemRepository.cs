using System;
using System.Net.Http.Json;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;


namespace Siemens.Internship2026.GradeBook.Repositories;


public class HttpItemRepository : IItemReader
{
    private readonly HttpClient _httpClient;
    private const string Endpoint = "https://gist.githubusercontent.com/ArdeleanTudor/8ea407832cd9794960e0e6bbd1319f6e/raw/145b121103dd1cee3737a681c487f7295ac82e6b/gistfile1.txt";
    public HttpItemRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Item?> GetByIdAsync(int id)
    {
        var items = await FetchAllAsync();
        return items.FirstOrDefault(i => i.Id == id && i.IsActive);
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        var items = await FetchAllAsync();
        return items.Where(i => i.IsActive);
    }

    private async Task<IEnumerable<Item>> FetchAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ItemsResponse>(Endpoint);
        return response?.Items ?? Enumerable.Empty<Item>();
    

}