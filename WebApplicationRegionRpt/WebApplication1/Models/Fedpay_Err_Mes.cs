using System.ComponentModel.DataAnnotations;

namespace FEDPAY.Models
{
    /// <summary>
    /// FEDPAY MISC.FEDPAY_ERR_MES table.  
    /// </summary>
    public class Fedpay_Err_Mes
    {
        [Key]
        [Display(Name = "Internal Error Code")]
        [MaxLength(6)]
        public string FEM_ERR_CODE { get; set; }

        [Display(Name = "Error Message")]
        [MaxLength(120)]
        public string FEM_FORM_MESSAGE { get; set; }

        [Display(Name = "NM Error Code")]
        [MaxLength(2)]
        public string FEM_NMC { get; set; }

        [Display(Name = "IRN Code")]
        [MaxLength(2)]
        public string FEM_IRN_CODE { get; set; }

        [Display(Name = "Error Code TYPE")]
        [MaxLength(2)]
        public string FEM_AD_IRN_CODE { get; set; }

        [Display(Name = "System Error Code")]
        [MaxLength(2)]
        public string FEM_SYS_CODE { get; set; }

    }


}