using System;
using Siemens.Internship2026.Gradebook.Models;
using Siemens.Internship2026.Gradebook.Interfaces;

public class ItemService : IItemService
{
    private readonly IItemReader _reader;

    public ItemService (IItemService reader)
    {
        _reader = reader;
    }

    public Task<IEnumerable<Item>> GetAllAsync()
    {
        return _reader.GetAllAsync();
    }

    public Task<Item?> GetByIdAsync(int id)
    {
        return _reader.GetByIdAsync(id);
    }
}