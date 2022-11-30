using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.DTOModels;
using Domain.DTOModels.Item;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;


    public ItemsController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetItemDTO>>> GetItems()
    {
        var items = await _context.Items.ToListAsync();
        var itemsToReturn = _mapper.Map<List<GetItemDTO>>(items);

        return Ok(itemsToReturn);
    }

    //GET: api/items/42
    [HttpGet("{id}")]
    public async Task<ActionResult<GetItemDTO>> GetItem(int id)
    {
        var foundItem = await _context.Items.FirstOrDefaultAsync(item => item.Id == id);

        if (foundItem is null) {
            return NotFound();
        }

        var itemDTO = _mapper.Map<GetItemDTO>(foundItem);

        return itemDTO;
    }

    // POST api/items
    [HttpPost]
    public async Task<ActionResult<Item>> PostItem(CreateItemDTO itemDTO) 
    {
        var item = _mapper.Map<Item>(itemDTO);

        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetItem", new { id = item.Id }, item);
    }

    // PUT: api/items/42
    [HttpPut("{id}")]
    public async Task<IActionResult> PutItem(int id, UpdateItemDTO itemToUpdateDTO)
    {
        if (id != itemToUpdateDTO.Id)
        {
            return BadRequest("Id is invalid");
        }

        var item = await _context.Items.FindAsync(id);

        if (item == null) {
            return NotFound();
        }

        _mapper.Map(itemToUpdateDTO, item);

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

    // DELETE: api/items/42
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var itemToDelete = await _context.Items.FindAsync(id);

        if (itemToDelete is null) return NotFound();

        _context.Items.Remove(itemToDelete);
        await _context.SaveChangesAsync();

        // delete was successful, just return nothing. Might want to change this later 
        return NoContent();
    }
}
