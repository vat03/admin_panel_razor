using System.ComponentModel.DataAnnotations;

namespace admin_panel_razor.Models
{
    public class AboutUs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
