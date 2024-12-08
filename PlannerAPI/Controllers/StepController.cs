using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerAPI.Model;

namespace PlannerAPI.Controllers;

[ApiController]
[Route("users/{userId}/todos/{todoId}/steps")]
public class StepController : ControllerBase
{
    private readonly PlannerDbContext _context;

    public StepController(PlannerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Step>>> GetSteps()
    {
        return Ok(await _context.Steps.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Step>> GetStep(Guid id)
    {
        var step = await _context.Steps.FindAsync(id);
        if (step == null)
        {
            return NotFound();
        }
        return Ok(step);
    }

    [HttpPost]
    public async Task<ActionResult<Step>> CreateStep([FromBody] Step step)
    {
        step.Id = Guid.NewGuid();
        _context.Steps.Add(step);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetStep), new { id = step.Id }, step);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStep(Guid id, [FromBody] Step updatedStep)
    {
        var step = await _context.Steps.FindAsync(id);
        if (step == null)
        {
            return NotFound();
        }
        step.Title = updatedStep.Title;
        step.Description = updatedStep.Description;
        step.IsComplete = updatedStep.IsComplete;
        step.TodoId = updatedStep.TodoId;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStep(Guid id)
    {
        var step = await _context.Steps.FindAsync(id);
        if (step == null)
        {
            return NotFound();
        }
        _context.Steps.Remove(step);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
