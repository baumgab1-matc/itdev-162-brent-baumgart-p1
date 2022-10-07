using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// TODO - refactor controllers to use DTOs for project 2, avoiding to do now as project is still in development
[ApiController]
[Route("api/[controller]")]
public class GradsController : ControllerBase
{
    private readonly DataContext _context;

    public GradsController(DataContext context)
    {
        _context = context;
    }

    // GET: api/grads
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Grad>>> GetGrads()
    {  
        var grads = await _context.Grads
                .Include(obj => obj.Items)
                .ToListAsync();
                
        return Ok(grads);
    }

    //GET: api/grads/42
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Grad>>> GetGrad(int id)
    {

        var foundGrad = await _context.Grads
                .Where(obj => obj.Id == id)
                .Include(obj => obj.Items)
                .ToListAsync();


        return foundGrad;
    }

    // POST api/grads
    [HttpPost]
    public async Task<ActionResult<Grad>> PostGrad(Grad grad) {

        _context.Grads.Add(grad);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGrad", new { id = grad.Id }, grad);
    }


    // PUT: api/grads/42
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGrad(int id, Grad gradToUpdate)
    {
        if (id != gradToUpdate.Id)
        {
            return BadRequest("Id is invalid");
        }

        // This just updates the grads username for now
        // if you want to update a grads item, you have to use the items controlller for now
        _context.Entry(gradToUpdate).State = EntityState.Modified;

        // docs mentioned a scenario where one user deletes while another updates, this try-catch is handling that
        bool gradExists = _context.Grads.Any(x => x.Id == id);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {   
            if (!gradExists) {
                return NotFound();
            } else {
                throw; 
            }
        }
        
        // put was successful, just return nothing. Might want to change this later 
        return NoContent();
    }

    // DELETE: api/grads/42
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGrad(int id)
    {
        var gradToDelete = await _context.Grads.FindAsync(id);

        if (gradToDelete is null) return NotFound();

        _context.Grads.Remove(gradToDelete);
        await _context.SaveChangesAsync();

        // delete was successful, just return nothing. Might want to change this later 
        return NoContent();
    }

}
