using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FEDPAY.Models
{
    public class AdmDiffStmtVw
    {
        [Display(Name = "PO#")]
        public string ADD_PO_NO { get; set; }

        [Display(Name = "Invoice#")]
        public string ADD_INVOICE_NO { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime ADD_DATE_OF_DIFF { get; private set; }

        [Display(Name = "Admin Diff Amount")]
        [DataType("decimal(12,2)")]
        public decimal ADD_AMT { get; private set; }

        [Display(Name = "Reason Code")]
        public string ADIFF_REASON { get; private set; }

        [Display(Name = "Vendor")]
        public string VEN_NAME { get; set; }

        [Display(Name = "1ST Line Address")]
        public string VEN_ADDRESS1 { get; private set; }

        [Display(Name = "City")]
        public string VEN_CITY_NAME { get; private set; }

        [Display(Name = "State")]
        public string VEN_STATE_ABBR { get; private set; }

    }
}
