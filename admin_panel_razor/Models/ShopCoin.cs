using System.ComponentModel.DataAnnotations;

namespace admin_panel_razor.Models
{
    public class ShopCoin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; } 
    }
}
