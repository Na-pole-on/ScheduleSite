using System.ComponentModel.DataAnnotations;

namespace ScheduleSite.Models.Parties
{
    public class CreatePartyViewModel
    {
        [Required]

        [MaxLength(40, ErrorMessage = "The name is too long")]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
