using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace admin_panel_razor.Models
{
    public class Transaction
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        
        [Required]  
        public int PlayerId { get; set; }
        
        [Required]
        public string TxnId { get; set; }
        
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; }
        
        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}