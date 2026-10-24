using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditForm.Model
{
    public class Fraud
    {

        public int Id { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public string FraudType { get; set; }

        //this one is for the previous fraud number and amount
        public int PreviousNumber { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PreviousAmount { get; set; }

        //this is the currrent one
        public int CurrentNumber { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentAmount { get; set; }

        //this is solved one
        public int RecoveredNumber { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RecoveredAmount { get; set; }

        //the remaining unsolved
        public  int OutstandingNumber { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OutstandingAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal WrittenOffAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProvisionAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }



    }

    }

