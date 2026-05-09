using System;
using Siemens.Internship2026.GradeBook.Models;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Services;

public class ItemService : IItemService
{
    private readonly IItemReader _reader;

    public ItemService (IItemReader reader)
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

    public async Task<IEnumerable<Item>> GetTopPassingGradesAsync(int count)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be a positive integer.");

        var items = await _reader.GetAllAsync();

        return items
            .Where(i => i.Value >= 5)
            .Take(count);
    }

}