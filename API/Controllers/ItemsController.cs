using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly DataContext _context;

    public ItemsController(DataContext context)
    {
        _context = context;
    }

    // GET: api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        var items = await _context.Items.ToListAsync();
        return Ok(items);
    }

    //GET: api/items/42
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var foundItem = await _context.Items.FindAsync(id);

        if (foundItem is null) {
            return NotFound();
        }
        return foundItem;
    }

    // POST api/items
    [HttpPost]
    public async Task<ActionResult<Item>> PostItem(Item item) {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetItem", new { id = item.Id }, item);
    }

    // PUT: api/items/42
    [HttpPut("{id}")]
    public async Task<IActionResult> PutItem(int id, Item itemToUpdate)
    {
        if (id != itemToUpdate.Id)
        {
            return BadRequest("Id is invalid");
        }

        // updates an item that a grad has
        _context.Entry(itemToUpdate).State = EntityState.Modified;

        bool itemExists = _context.Items.Any(x => x.Id == id);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {   
            if (!itemExists) {
                return NotFound();
            } else {
                throw; 
            }
        }
        
        // put was successful, just return nothing. Might want to change this later 
        return NoContent();
    }
}
