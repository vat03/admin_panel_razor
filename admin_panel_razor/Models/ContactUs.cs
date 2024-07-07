using System.ComponentModel.DataAnnotations;

namespace admin_panel_razor.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PrimaryTollFreeNumber { get; set; }

        [Required]
        [EmailAddress]
        public string PrimaryEmail { get; set; }

        public string SecondaryTollFreeNumber { get; set; }

        [EmailAddress]
        public string SecondaryEmail { get; set; }

        [Required]
        public string Address { get; set; }
    }
}

