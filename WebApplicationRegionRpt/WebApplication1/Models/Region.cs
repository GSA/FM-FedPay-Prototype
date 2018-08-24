using System.ComponentModel.DataAnnotations;

namespace FEDPAY.Models
{
    /// <summary>
    /// FEDPAY MISC.REGION table.  
    /// </summary>
    public class Region
    {
        [Key]
        public string REG_PO_SUFFIX { get; set; }
        public string REG_FSS_REGION_CODE { get; set; }
        public string REG_FAIM_FB_REGION_CODE { get; set; }
        public string REG_FEDPAY_REGION_CODE { get; set; }
        public string REG_ROUTING_ID { get; set; }
        public string REG_INFONET_REGION_CODE { get; set; }
        

    }
}