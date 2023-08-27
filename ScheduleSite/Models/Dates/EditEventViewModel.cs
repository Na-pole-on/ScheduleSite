using System.ComponentModel.DataAnnotations;

namespace ScheduleSite.Models.Dates
{
    public class EditEventViewModel
    {
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
