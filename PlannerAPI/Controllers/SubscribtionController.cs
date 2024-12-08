using Microsoft.AspNetCore.Mvc;
using PlannerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace PlannerAPI.Controllers;

[ApiController]
[Route("users/{userId}/windows/{windowId}/subscribtions")]
public class SubscribtionController : ControllerBase
{
    private readonly PlannerDbContext _context;

    public SubscribtionController(PlannerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Subscribtion>>> GetSubscribtions()
    {
        return Ok(await _context.Subscribtions.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Subscribtion>> GetSubscribtion(Guid id)
    {
        var subscribtion = await _context.Subscribtions.FindAsync(id);
        if (subscribtion == null)
        {
            return NotFound();
        }
        return Ok(subscribtion);
    }

    [HttpPost]
    public async Task<ActionResult<Subscribtion>> CreateSubscribtion([FromBody] Subscribtion subscribtion)
    {
        subscribtion.Id = Guid.NewGuid();
        _context.Subscribtions.Add(subscribtion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSubscribtion), new { id = subscribtion.Id }, subscribtion);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSubscribtion(Guid id, [FromBody] Subscribtion updatedSubscribtion)
    {
        var subscribtion = await _context.Subscribtions.FindAsync(id);
        if (subscribtion == null)
        {
            return NotFound();
        }

        subscribtion.Title = updatedSubscribtion.Title;
        subscribtion.Description = updatedSubscribtion.Description;
        subscribtion.StartDate = updatedSubscribtion.StartDate;
        subscribtion.EndDate = updatedSubscribtion.EndDate;
        subscribtion.Provider = updatedSubscribtion.Provider;
        subscribtion.PaymentAmount = updatedSubscribtion.PaymentAmount;
        subscribtion.Currency = updatedSubscribtion.Currency;
        subscribtion.paymentFrequency = updatedSubscribtion.paymentFrequency;
        subscribtion.RemindMe = updatedSubscribtion.RemindMe;
        subscribtion.UserId = updatedSubscribtion.UserId;

        _context.Subscribtions.Update(subscribtion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSubscribtion(Guid id)
    {
        var subscribtion = await _context.Subscribtions.FindAsync(id);
        if (subscribtion == null)
        {
            return NotFound();
        }

        _context.Subscribtions.Remove(subscribtion);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

