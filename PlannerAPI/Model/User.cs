using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public List<Window> Windows { get; set; } = [];
    }
}
