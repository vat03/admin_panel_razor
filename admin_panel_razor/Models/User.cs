using System.ComponentModel.DataAnnotations;

namespace admin_panel_razor.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public decimal WalletAmount { get; set; }

        public decimal WinAmount { get; set; }
    }
}
