using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEDPAY.Models
{
    /// <summary>
    /// FEDPAY MISC.Non_Mechandise_Code table.  
    /// </summary>
    public class Admin_Diff
    {
 
        [Display(Name = "Seq#")]
        [MaxLength(6)]
        public int ADD_SEQ_NO { get; set; }

        [Display(Name = "Vendor#")]
        [MaxLength(9)]
        public string ADD_VENDOR_NO { get; set; }


        [Display(Name = "Reason Code 1")]
        [MaxLength(2)]
        public string ADD_NON_MERCH_CODE { get; set; }

        [Display(Name = "Admin Diff Amount")]
        [DataType("decimal(12,2)")]
        public decimal ADD_AMT { get; set; }


        [Display(Name = "Invoiced Quantity")]
        public int? ADD_BILLED_QTY { get; set; }


        [Display(Name = "Invoiced UCP")]
        [DataType("decimal(13,5)")]
        public decimal? ADD_BILLED_UCP { get; set; }


        [Display(Name = "Claim#")]
        [MaxLength(8)]
        public string ADD_CLAIM_CONTROL_NO { get; set; }



        [Display(Name = "PO Open Quantity")]
        public int? ADD_PO_QTY { get; set; }

        [Display(Name = "PO UCP")]
        [DataType("decimal(13,5)")]
        public decimal? ADD_PO_UCP { get; set; }

        [Display(Name = "Stock#")]
        [MaxLength(15)]
        public string ADD_STOCK_NO { get; set; }


        [Display(Name = "FAS PO#")]
        [MaxLength(11)]
        public string ADD_FSS_PO_NO { get; set; }


        [Display(Name = "Reason Code 2")]
        [MaxLength(6)]
        public string ADD_ERROR_CD { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime ADD_DATE_OF_DIFF { get; set; }

        [Display(Name = "Created By")]
        [MaxLength(3)]
        public string ADD_INITIALS { get; set; }

        //The order in which you specify principal key properties must match the order in which they are specified for the foreign key.
        // build out foreign key  FKey =  PO  & Inv#  -Relationship (one invoice to many Adiffs defined in FEDPAY.cs)
        [ForeignKey("ADD_PO_NO, ADD_INVOICE_NO")]
        public Invoice_Summary Invoice_Summary { get; set; }
        [Display(Name = "PO#")]
        public string ADD_PO_NO { get; set; }
        [Display(Name = "Invoice#")]
        public string ADD_INVOICE_NO { get; set; }


    }


}