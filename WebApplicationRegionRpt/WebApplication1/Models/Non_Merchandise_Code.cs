using System.ComponentModel.DataAnnotations;

namespace FEDPAY.Models
{
    /// <summary>
    /// FEDPAY MISC.Non_Mechandise_Code table.  
    /// </summary>
    public class Non_Merchandise_Code
    {
        [Key]
        [Display(Name = "Non Merch Code")]
        [MaxLength(2)]
        public string NMC_CODE { get; set; }

        [Display(Name = "Meaning")]
        [MaxLength(40)]
        public string NMC_MEANING { get; set; }

        [Display(Name = "Invoice Action Indicator")]
        [MaxLength(1)]
        public string NMC_INVOICE_ACTION { get; set; }

        [Display(Name = "Admin Diff Indicator")]
        [MaxLength(1)]
        public string NMC_ADMIN_DIFF_IND { get; set; }

        [Display(Name = "TD Code")]
        [MaxLength(2)]
        public string NMC_PO_TD_CODE { get; set; }

        [Display(Name = "Billing Literal")]
        [MaxLength(15)]
        public string NMC_BILLING_LIT { get; set; }

        [Display(Name = "Billing Transaction ID")]
        [MaxLength(4)]
        public string NMC_TRANSACTION_ID { get; set; }

        [Display(Name = "Invoice Adjustment Type")]
        [MaxLength(1)]
        public string NMC_ADJUSTMENT_IND { get; set; }

        [Display(Name = "Associated Module")]
        [MaxLength(1)]
        public string NMC_SYS_CODE { get; set; }


    }
}