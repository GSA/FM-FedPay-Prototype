using System.ComponentModel.DataAnnotations;

namespace FEDPAY.Models
{
    public class Invoice_Return_Notice
    {
        [Key]
        public int IRN_ID { get; set; }

        [Display(Name = "Invoice#")]
        public string IRN_INVOICE_NO { get; set; }

        [Display(Name = "PO#")]
        public string IRN_PO_NO { get; set; }


        [Display(Name = "Vendor#")]
        public string IRN_VENDOR_NO { get; set; }

        [Display(Name = "Vendor Alt Key")]
        public string IRN_VENDOR_ALT_KEY { get; set; }

        [Display(Name = "REASON Code 1")]
        public string IRN_INVOICE_RETURN_CODE1 { get; set; }

        [Display(Name = "REASON Code 2")]
        public string IRN_INVOICE_RETURN_CODE2 { get; set; }

        [Display(Name = "REASON Code 3")]
        public string IRN_INVOICE_RETURN_CODE3 { get; set; }

        [Display(Name = "REASON Code 4")]
        public string IRN_INVOICE_RETURN_CODE4 { get; set; }

        [Display(Name = "REASON Code 5")]
        public string IRN_INVOICE_RETURN_CODE5 { get; set; }

        [Display(Name = "IRN Amount")]
        [DataType("decimal(12,2)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal IRN_RETURN_AMT { get; set; }

        [Display(Name = "Date of Return")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime IRN_DATE_OF_RETURN { get; set; }

        [Display(Name = "Date of Received")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime IRN_DATE_RECEIVED { get; set; }


        [Display(Name = "FAS PO#")]
        public string IRN_FSS_PO_NO { get; set; }




    }
}
