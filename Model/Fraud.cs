using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditForm.Model
{
    public class Fraud
    {
        public int Id { get; set; }

        // ---- The occurrence ----
        [Required]
        public DateTime OccurredOn { get; set; } = DateTime.Today;

        [Required]
        public string Category { get; set; } = "";

        [Required]
        public string FraudType { get; set; } = "";

        [Range(1, int.MaxValue)]
        public int Count { get; set; } = 1;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public string? Description { get; set; }
        public string? ReportedBy { get; set; }

        public string Status { get; set; } = "Open"; // Open | Under review | Recovered | Closed

        // ---- Follow-up ----
        public int RecoveredCount { get; set; } // <--- THIS FIXES YOUR ERROR

        [Column(TypeName = "decimal(18,2)")]
        public decimal RecoveredAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal WrittenOffAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProvisionAmount { get; set; }

        // ---- Computed on save ----
        public int OutstandingNumber { get; set; } // <--- THIS FIXES YOUR ERROR

        [Column(TypeName = "decimal(18,2)")]
        public decimal OutstandingAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}