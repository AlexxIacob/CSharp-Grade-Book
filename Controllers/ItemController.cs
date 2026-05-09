using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _service;
    private readonly ILogger<ItemController> _logger;

    public ItemController(IItemService service, ILogger<ItemController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("GET api/item called at {time}", DateTime.UtcNow);

        var items = await _service.GetAllAsync();
        var itemList = items.ToList();

        _logger.LogInformation("Return {count} items", itemList.Count);
        
        return Ok(itemList);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("GET api/item/{id} called", id);

        if (id <= 0)
        {
            return BadRequest("Id must be a positive integer.");
        }

        var item = await _service.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound($"Item with Id {id} was not found.");
        }

        return Ok(item);
    }
}
    