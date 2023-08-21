namespace ScheduleSite.Models.Dates
{
    public class DayViewModel
    {
        public string? Id { get; set; }
        public DateTime? Date { get; set; }
        public bool IsToday { get; set; } = false;
        public bool IsThisMonth { get; set; } = false;

        public List<EventViewModel>? Happenings { get; set; } = new List<EventViewModel>();
    }
}
