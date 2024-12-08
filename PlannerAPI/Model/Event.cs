using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Model
{
    public class Event
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }

        public Guid UserId { get; set; }
    }
}
