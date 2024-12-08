using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Model
{
    public class Step
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public required string Title { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;

        public Guid TodoId { get; set; }
    }
}
