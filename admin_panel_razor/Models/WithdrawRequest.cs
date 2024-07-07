using System.ComponentModel.DataAnnotations;

namespace admin_panel_razor.Models
{
    public class WithdrawRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        [StringLength(100)]
        public string Account { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}

