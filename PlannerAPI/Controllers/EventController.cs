using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerAPI.Model;

namespace PlannerAPI.Controllers;

[ApiController]
[Route("users/{userId}/windows/{windowId}/events")]
public class EventController : ControllerBase
{
    private readonly PlannerDbContext _context;

    public EventController(PlannerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Event>>> GetEvents()
    {
        return Ok(await _context.Events.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(Guid id)
    {
        var ev = await _context.Events.FindAsync(id);
        if (ev == null)
        {
            return NotFound();
        }
        return Ok(ev);
    }

    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent(Event newEvent)
    {
        newEvent.Id = Guid.NewGuid();
        _context.Events.Add(newEvent);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEvent), new { id = newEvent.Id }, newEvent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(Guid id, Event updatedEvent)
    {
        var ev = await _context.Events.FindAsync(id);
        if (ev == null)
        {
            return NotFound();
        }

        ev.Title = updatedEvent.Title;
        ev.Description = updatedEvent.Description;
        ev.StartDate = updatedEvent.StartDate;
        ev.EndDate = updatedEvent.EndDate;
        ev.Location = updatedEvent.Location;
        ev.UserId = updatedEvent.UserId;

        _context.Entry(ev).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(Guid id)
    {
        var ev = await _context.Events.FindAsync(id);
        if (ev == null)
        {
            return NotFound();
        }

        _context.Events.Remove(ev);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
