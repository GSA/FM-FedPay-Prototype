using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FEDPAY.Models;
using FEDPAYmgr.Models;

namespace FEDPAY.Views.Home.FEDPAY
{
    public class EditModel : PageModel
    {
        private readonly FEDPAYmgr.Models.FEDPAYContext _context;

        public EditModel(FEDPAYmgr.Models.FEDPAYContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(Region.REG_PO_SUFFIX))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RegionExists(string id)
        {
            return _context.Region.Any(e => e.REG_PO_SUFFIX == id);
        }
    }
}
