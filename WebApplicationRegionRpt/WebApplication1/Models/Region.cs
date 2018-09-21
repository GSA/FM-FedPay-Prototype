using System.ComponentModel.DataAnnotations;

namespace FEDPAY.Models
{
    /// <summary>
    /// FEDPAY MISC.REGION table.  
    /// </summary>
    public class Region
    {
        [Key]
        [Display(Name = "PO Suffix")]
        public string REG_PO_SUFFIX { get; set; }

        [Display (Name = "FAS Region")]
        public string REG_FSS_REGION_CODE { get; set; }

        [Display(Name = "FAIM FEDBIL Region")]
        public string REG_FAIM_FB_REGION_CODE { get; set; }

        [Display(Name = "FEDPAY Region")]
        public string REG_FEDPAY_REGION_CODE { get; set; }

        [Display(Name = "Routing ID")]
        public string REG_ROUTING_ID { get; set; }

        [Display(Name = "NEAR Region")]
        public string REG_INFONET_REGION_CODE { get; set; }
        

    }
}