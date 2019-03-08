using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEDPAY.Models
{
    /// <summary>
    /// FEDPAY Active.Invoice_Summary table.  
    /// </summary>
    public class Invoice_Summary
    {
        [Display(Name = "Vendor#")]
        [MaxLength(12)]
        public string INS_VENDOR_NO { get; set; }

        [Display(Name = "PO#")]
        [MaxLength(9)]
        public string INS_PO_NO { get; set; }

        [Display(Name = "Invoice#")]
        [MaxLength(12)]
        public string INS_INVOICE_NO { get; set; }

        [Display(Name = "Invoice Amt")]
        public decimal INS_INVOICE_AMT { get; set; }


        [Display(Name = "Admin Diff Amt")]
        public decimal INS_ADMIN_DIFF_AMT { get; set; }

        [Display(Name = "Amount Paid")]
        public decimal INS_AMT_PAID { get; set; }

        [ForeignKey("ADD_PO_NO, ADD_INVOICE_NO")]
        public ICollection<Admin_Diff> Admin_Diffs { get; set; }




    }


}