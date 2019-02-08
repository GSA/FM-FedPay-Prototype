using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FEDPAY.Models
{
    public class AdmDiffStmtVw
    {
        [Display(Name = "Vendor#")]
        public string ADD_VENDOR_NO { get; set; }

        [Display(Name = "FAS PO#")]
        public string ADD_FSS_PO_NO { get; private set; }

        [Display(Name = "PO#")]
        public string ADD_PO_NO { get; set; }

        [Display(Name = "Invoice#")]
        public string ADD_INVOICE_NO { get; set; }

        [Display(Name = "AD SEQ")]
        public int ADD_SEQ_NO { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime ADD_DATE_OF_DIFF { get; private set; }

        [Display(Name = "Admin Diff Amount")]
        [DataType("decimal(12,2)")]
        public decimal ADD_AMT { get; private set; }

        [Display(Name = "Inv Qty")]
        public int ADD_BILLED_QTY { get; private set; }

        [Display(Name = "Inv UCP")]
        [DataType("decimal(14,5)")]
        public decimal ADD_BILLED_UCP { get; private set; }

        [Display(Name = "Claim#")]
        public string ADD_CLAIM_CONTROL_NO { get; private set; }

        [Display(Name = "INPUT INITIALS")]
        public string ADD_INITIALS { get; private set; }

        [Display(Name = "PO Qty")]
        public int ADD_PO_QTY { get; private set; }

        [Display(Name = "PO UCP")]
        [DataType("decimal(14,5)")]
        public decimal ADD_PO_UCP { get; private set; }

        [Display(Name = "Stock#")]
        public string ADD_STOCK_NO { get; private set; }

        [Display(Name = "Reason Code")]
        public string ADIFF_REASON { get; private set; }

        [Display(Name = "Vendor")]
        public string VEN_NAME { get; set; }

        [Display(Name = "1ST Line Address")]
        public string VEN_ADDRESS1 { get; private set; }

        [Display(Name = "2ND Line Address")]
        public string VEN_ADDRESS2 { get; private set; }

        [Display(Name = "3RD Line Address")]
        public string VEN_ADDRESS3 { get; private set; }

        [Display(Name = "City")]
        public string VEN_CITY_NAME { get; private set; }

        [Display(Name = "State")]
        public string VEN_STATE_ABBR { get; private set; }

        [Display(Name = "ZIP")]
        public string VEN_ZIP_CODE { get; private set; }

        [Display(Name = "REASON")]
        public string FEM_FORM_MESSAGE { get; private set; }

        [Display(Name = "No of Diff")]
        public int AD_CNT { get; private set; }

        [Display(Name = "Total Diff Amt")]
        [DataType("decimal(12,2)")]
        public decimal TOT_AD_AMT { get; private set; }


    }
}
