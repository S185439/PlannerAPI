using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlannerAPI.Model;

namespace PlannerAPI;

public class PlannerDbContext : DbContext
{
    public PlannerDbContext(DbContextOptions<PlannerDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Subscribtion> Subscribtions { get; set; }
    public DbSet<Window> Windows { get; set; }


}

