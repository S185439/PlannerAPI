using Microsoft.AspNetCore.Mvc;
using PlannerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace PlannerAPI.Controllers;

[ApiController]
[Route("users/{userId}/windows/{windowId}/todos")]
public class TodoController : ControllerBase
{
    private readonly PlannerDbContext _context;

    public TodoController(PlannerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<ToDo>> GetTodos()
    {
        return Ok(_context.ToDos.ToListAsync());
    }

    [HttpGet("{id}")]
    public ActionResult<ToDo> GetTodo(Guid id)
    {
        var todo = _context.ToDos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    [HttpPost]
    public ActionResult<ToDo> CreateTodo([FromBody] ToDo todo)
    {
        todo.Id = Guid.NewGuid();
        _context.ToDos.Add(todo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateTodo(Guid id, [FromBody] ToDo updatedTodo)
    {
        var todo = _context.ToDos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }

        todo.Title = updatedTodo.Title;
        todo.Description = updatedTodo.Description;
        todo.IsComplete = updatedTodo.IsComplete;
        todo.RemindMe = updatedTodo.RemindMe;
        todo.Steps = updatedTodo.Steps;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteTodo(Guid id)
    {
        var todo = _context.ToDos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }

        _context.ToDos.Remove(todo);
        _context.SaveChanges();
        return NoContent();
    }
}
