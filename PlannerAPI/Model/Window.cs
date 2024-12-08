using PlannerAPI.Enums;

namespace PlannerAPI.Model
{
    public class Window
    {
        public Guid Id { get; set; }
        public required string PageName { get; set; }
        public required string Title { get; set; }

        public List<ToDo>? todos { get; set; }
        public List<Subscribtion>? subscribtions { get; set; }
        public List<Event>? Events { get; set; }
    }
}
