using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GradController : ControllerBase
{
    private readonly DataContext _context;

    public GradController(DataContext context)
    {
        _context = context;
    }

    // GET: 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Grad>>> GetGrads()
    {  
        var grads = await _context.Grads
                .Include(obj => obj.Items)
                .ToListAsync();
                
        return Ok(grads);
    }

    //GET: /id
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Grad>>> GetGrad(int id)
    {

        var foundGrad = await _context.Grads
                .Where(obj => obj.Id == id)
                .Include(obj => obj.Items)
                .ToListAsync();


        return foundGrad;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult<Grad>> PostGrad(Grad grad) {
        _context.Grads.Add(grad);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGrad", new { id = grad.Id }, grad);
    }
}
