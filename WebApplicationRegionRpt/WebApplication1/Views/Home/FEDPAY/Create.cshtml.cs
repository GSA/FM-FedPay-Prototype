using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FEDPAY.Models;
using FEDPAYmgr.Models;

namespace FEDPAY.Views.Home.FEDPAY
{
    public class CreateModel : PageModel
    {
        private readonly FEDPAYmgr.Models.FEDPAYContext _context;

        public CreateModel(FEDPAYmgr.Models.FEDPAYContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Region Region { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Region.Add(Region);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}