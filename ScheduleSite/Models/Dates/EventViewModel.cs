using System.ComponentModel.DataAnnotations;

namespace ScheduleSite.Models.Dates
{
    public class EventViewModel
    {
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Result { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public string GetResult()
        {
            if (Result == 0)
                return "Waiting";

            return "Passed";
        }
    }
}
