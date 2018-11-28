using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FEDPAY.Models;
using FEDPAYmgr.Models;

namespace FEDPAY.Controllers
{
    public class NMCController : Controller
    {
        private readonly FEDPAYContext _context;

        public NMCController(FEDPAYContext context)
        {
            _context = context;
        }

        // GET: Non Merchandise Codes 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Non_Merchandise_Code.ToListAsync());
        }

        // GET: Non Merchandise Codes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmc = await _context.Non_Merchandise_Code
                .FirstOrDefaultAsync(m => m.NMC_CODE == id);
            if (nmc == null)
            {
                return NotFound();
            }

            return View(nmc);
        }

        // GET: NMC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NMC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NMC_CODE,NMC_MEANING,NMC_INVOICE_ACTION,NMC_ADMIN_DIFF_IND,NMC_PO_TD_CODE,NMC_BILLING_LIT,NMC_TRANSACTION_ID,NMC_ADJUSTMENT_IND,NMC_SYS_CODE")] Non_Merchandise_Code non_Merchandise_Code)
        {
            if (ModelState.IsValid)
            {
                _context.Add(non_Merchandise_Code);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(non_Merchandise_Code);
        }

        // GET: NMC/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmc = await _context.Non_Merchandise_Code.FindAsync(id);
            if (nmc == null)
            {
                return NotFound();
            }
            return View(nmc);
        }

        // POST: NMC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NMC_CODE,NMC_MEANING,NMC_INVOICE_ACTION,NMC_ADMIN_DIFF_IND,NMC_PO_TD_CODE,NMC_BILLING_LIT,NMC_TRANSACTION_ID,NMC_ADJUSTMENT_IND,NMC_SYS_CODE")] Non_Merchandise_Code non_Merchandise_Code)
        {
            if (id != non_Merchandise_Code.NMC_CODE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(non_Merchandise_Code);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Non_MerchandiseCodeExists(non_Merchandise_Code.NMC_CODE))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(non_Merchandise_Code);
        }

        // GET: NMC/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmc = await _context.Non_Merchandise_Code
                .FirstOrDefaultAsync(m => m.NMC_CODE == id);
            if (nmc == null)
            {
                return NotFound();
            }

            return View(nmc);
        }

        // POST: NMC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nmc = await _context.Non_Merchandise_Code.FindAsync(id);
            _context.Non_Merchandise_Code.Remove(nmc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Non_MerchandiseCodeExists(string id)
        {
            return _context.Non_Merchandise_Code.Any(e => e.NMC_CODE == id);
        }
    }
}
