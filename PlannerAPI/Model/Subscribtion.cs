using PlannerAPI.Enums;

namespace PlannerAPI.Model
{
    public class Subscribtion
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public string? Provider { get; set; }
        public int PaymentAmount { get; set; }
        public string? Currency { get; set; }
        public Frequency paymentFrequency { get; set; }
        public bool RemindMe { get; set; } = true;

        public Guid UserId { get; set; }
    }
}
