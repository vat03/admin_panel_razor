using System.ComponentModel.DataAnnotations;

namespace admin_panel_razor.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Url]
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [Required]
        [Url]
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }

        [Required]
        [Url]
        [Display(Name = "LinkedIn")]
        public string LinkedIn { get; set; }

        [Required]
        [Url]
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }

        [Required]
        [Url]
        [Display(Name = "YouTube")]
        public string YouTube { get; set; }

        [Required]
        [Url]
        [Display(Name = "WhatsApp")]
        public string WhatsApp { get; set; }

        [Required]
        [Url]
        [Display(Name = "Pinterest")]
        public string Pinterest { get; set; }

        [Required]
        [Url]
        [Display(Name = "GitHub")]
        public string GitHub { get; set; }
    }
}

