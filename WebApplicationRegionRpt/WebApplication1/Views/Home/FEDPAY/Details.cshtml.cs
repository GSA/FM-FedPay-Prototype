using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FEDPAY.Models;
using FEDPAYmgr.Models;

namespace FEDPAY.Views.Home.FEDPAY
{
    public class DetailsModel : PageModel
    {
        private readonly FEDPAYmgr.Models.FEDPAYContext _context;

        public DetailsModel(FEDPAYmgr.Models.FEDPAYContext context)
        {
            _context = context;
        }

        public Region Region { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Region = await _context.Region.FirstOrDefaultAsync(m => m.REG_PO_SUFFIX == id);

            if (Region == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
