using System.ComponentModel.DataAnnotations;

namespace admin_panel_razor.Models
{
    public class GameConfig
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Admin Commission")]
        public int AdminCommission { get; set; }

        [Required]
        [Display(Name = "Signup Bonus")]
        public int SignupBonus { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Support Mail")]
        public string SupportMail { get; set; }

        [Required]
        [Display(Name = "WhatsApp Link")]
        public string WhatsappLink { get; set; }

        [Required]
        [Url]
        [Display(Name = "YouTube Link")]
        public string YoutubeLink { get; set; }

        [Required]
        [Display(Name = "API Key")]
        public string ApiKey { get; set; }

        [Required]
        [Display(Name = "Secret Key")]
        public string SecretKey { get; set; }
    }
}

