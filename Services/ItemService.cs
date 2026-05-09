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
}