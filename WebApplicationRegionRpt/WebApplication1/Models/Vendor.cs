using System.ComponentModel.DataAnnotations;

namespace FEDPAY.Models
{
    /// <summary>
    /// FEDPAY MISC.Vendor table.  
    /// </summary>
    public class Vendor
    {
        [Key]
        [Display(Name = "Vendor#")]
        [MaxLength(9)]
        public string VEN_VENDOR_NO { get; set; }

        [Display(Name = "Vendor Name")]
        [MaxLength(35)]
        public string VEN_NAME { get; set; }

        [Display(Name = "VEN ADDRESS1")]
        [MaxLength(35)]
        public string VEN_ADDRESS1 { get; set; }

        [Display(Name = "VEN ADDRESS2")]
        [MaxLength(35)]
        public string VEN_ADDRESS2 { get; set; }


        [Display(Name = "VEN ADDRESS3")]
        [MaxLength(35)]
        public string VEN_ADDRESS3 { get; set; }

        [Display(Name = "City")]
        [MaxLength(20)]
        public string VEN_CITY_NAME { get; set; }

        [Display(Name = "State")]
        [MaxLength(2)]
        public string VEN_STATE_ABBR { get; set; }

        [Display(Name = "Zip")]
        [MaxLength(5)]
        public string VEN_ZIP_CODE { get; set; }

        [Display(Name = "VEN ALT Key")]
        [MaxLength(30)]
        public string ven_vendor_alt_key { get; set; }


    }


}