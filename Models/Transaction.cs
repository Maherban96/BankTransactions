using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransactions.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Column(TypeName ="nvarchar(12)")]
        
        [Required(ErrorMessage ="Account Number is required.")]
        [MaxLength(12, ErrorMessage = "Account number should contains maximum 12 number.")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Beneficiary name is required.")]
        [MaxLength(100, ErrorMessage = "Beneficiary name should contains maximum 100 number.")]
        public string BeneficiaryName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Bank name is required.")]
        public string BankName { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        [Required(ErrorMessage = "SWIFTCode is required.")]
        [MaxLength(12, ErrorMessage = "SWIFTCode should contains maximum 11 number.")]
        public string SWIFTCode { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
