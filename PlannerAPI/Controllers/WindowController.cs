using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerAPI.Model;

namespace PlannerAPI.Controllers;

[ApiController]
[Route("users/{userId}/windows")]
public class WindowController : ControllerBase
{
    private readonly PlannerDbContext _context;

    public WindowController(PlannerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Window>>> GetWindows()
    {
        var windows = await _context.Windows.ToListAsync();
        return Ok(windows);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Window>> GetWindow(Guid id)
    {
        var window = await _context.Windows.FirstOrDefaultAsync(w => w.Id == id);
        if (window == null)
        {
            return NotFound();
        }
        return Ok(window);
    }

    [HttpPost]
    public async Task<ActionResult<Window>> CreateWindow(Window window)
    {
        window.Id = Guid.NewGuid();
        _context.Windows.Add(window);
        await _context.SaveChangesAsync();
        return Ok(CreatedAtAction(nameof(GetWindow), new { id = window.Id }, window));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateWindow(Guid id, Window updatedWindow)
    {
        var window = await _context.Windows.FirstOrDefaultAsync(w => w.Id == id);
        if (window == null)
        {
            return NotFound();
        }

        window.Title = updatedWindow.Title;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteWindow(Guid id)
    {
        var window = await _context.Windows.FirstOrDefaultAsync(w => w.Id == id);
        if (window == null)
        {
            return NotFound();
        }

        _context.Windows.Remove(window);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
