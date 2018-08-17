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
    public class IndexModel : PageModel
    {
        private readonly FEDPAYmgr.Models.FEDPAYContext _context;

        public IndexModel(FEDPAYmgr.Models.FEDPAYContext context)
        {
            _context = context;
        }

        public IList<Region> Region { get;set; }

        public async Task OnGetAsync()
        {
            Region = await _context.Region.ToListAsync();
        }
    }
}
