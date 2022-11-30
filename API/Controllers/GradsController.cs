using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.DTOModels;
using AutoMapper;
using Domain.DTOModels.Grad;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradsController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GradsController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/grads
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetGradDTO>>> GetGrads()
    {  
        var grads = await _context.Grads.Include(grad => grad.Items).ToListAsync();
        var gradsToReturn = _mapper.Map<List<GetGradDTO>>(grads);

        return Ok(gradsToReturn);
    }

    //GET: api/grads/42
    [HttpGet("{id}")]
    public async Task<ActionResult<GetGradDTO>> GetGrad(int id)
    {

        var foundGrad = await _context.Grads
                        .Include(grad => grad.Items)
                        .FirstOrDefaultAsync(grad => grad.Id == id);

        if (foundGrad == null) {
            return NotFound();
        }

        var gradDTO = _mapper.Map<GetGradDTO>(foundGrad);

        return gradDTO;
    }

    // POST api/grads
    [HttpPost]
    public async Task<ActionResult<Grad>> PostGrad(CreateGradDTO gradDTO) 
    {
        var grad = _mapper.Map<Grad>(gradDTO);

        _context.Grads.Add(grad);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGrad", new { id = grad.Id }, grad);
    }


    // PUT: api/grads/42
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGrad(int id, UpdateGradDTO gradToUpdateDTO)
    {
        if (id != gradToUpdateDTO.Id)
        {
            return BadRequest("Id is invalid");
        }

        var grad = await _context.Grads.FindAsync(id);

        if (grad == null) {
            return NotFound();
        }

        _mapper.Map(gradToUpdateDTO, grad);

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
