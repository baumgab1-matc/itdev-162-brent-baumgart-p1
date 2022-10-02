using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly DataContext _context;

    public ItemController(DataContext context)
    {
        _context = context;
    }

    // GET: 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        var items = await _context.Items.ToListAsync();
        return Ok(items);
    }

    //GET: /id
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var foundItem = await _context.Items.FindAsync(id);

        if (foundItem is null) {
            return NotFound();
        }
        return foundItem;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult<Item>> PostItem(Item item) {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetItem", new { id = item.Id }, item);
    }
}
