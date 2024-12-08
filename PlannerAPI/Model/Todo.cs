using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Model
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public bool RemindMe { get; set; } = false;


        public List<Step> Steps { get; set; } = [];
    }
}
