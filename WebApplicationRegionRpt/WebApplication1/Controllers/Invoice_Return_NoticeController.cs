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
    public class Invoice_Return_NoticeController : Controller
    {
        private readonly FEDPAYContext _context;

        public Invoice_Return_NoticeController(FEDPAYContext context)
        {
            _context = context;
        }

        // GET: Invoice_Return_Notice
        public async Task<IActionResult> Index()
        {
            // this needs to be modified to be the IRN input form
            return View(await _context.Invoice_Return_Notice.ToListAsync());
        }

        // GET: Invoice_Return_Notice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_Return_Notice = await _context.Invoice_Return_Notice
                .FirstOrDefaultAsync(m => m.IRN_ID == id);
            if (invoice_Return_Notice == null)
            {
                return NotFound();
            }

            return View(invoice_Return_Notice);
        }

        // GET: Invoice_Return_Notice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoice_Return_Notice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IRN_ID,IRN_INVOICE_NO,IRN_PO_NO,IRN_VENDOR_NO,IRN_VENDOR_ALT_KEY,IRN_INVOICE_RETURN_CODE1,IRN_INVOICE_RETURN_CODE2,IRN_INVOICE_RETURN_CODE3,IRN_INVOICE_RETURN_CODE4,IRN_INVOICE_RETURN_CODE5,IRN_RETURN_AMT,IRN_DATE_OF_RETURN,IRN_DATE_RECEIVED,IRN_FSS_PO_NO")] Invoice_Return_Notice invoice_Return_Notice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice_Return_Notice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice_Return_Notice);
        }

        // GET: Invoice_Return_Notice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_Return_Notice = await _context.Invoice_Return_Notice.FindAsync(id);
            if (invoice_Return_Notice == null)
            {
                return NotFound();
            }
            return View(invoice_Return_Notice);
        }

        // POST: Invoice_Return_Notice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IRN_ID,IRN_INVOICE_NO,IRN_PO_NO,IRN_VENDOR_NO,IRN_VENDOR_ALT_KEY,IRN_INVOICE_RETURN_CODE1,IRN_INVOICE_RETURN_CODE2,IRN_INVOICE_RETURN_CODE3,IRN_INVOICE_RETURN_CODE4,IRN_INVOICE_RETURN_CODE5,IRN_RETURN_AMT,IRN_DATE_OF_RETURN,IRN_DATE_RECEIVED,IRN_FSS_PO_NO")] Invoice_Return_Notice invoice_Return_Notice)
        {
            if (id != invoice_Return_Notice.IRN_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice_Return_Notice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Invoice_Return_NoticeExists(invoice_Return_Notice.IRN_ID))
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
            return View(invoice_Return_Notice);
        }

        // GET: Invoice_Return_Notice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_Return_Notice = await _context.Invoice_Return_Notice
                .FirstOrDefaultAsync(m => m.IRN_ID == id);
            if (invoice_Return_Notice == null)
            {
                return NotFound();
            }

            return View(invoice_Return_Notice);
        }

        // POST: Invoice_Return_Notice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice_Return_Notice = await _context.Invoice_Return_Notice.FindAsync(id);
            _context.Invoice_Return_Notice.Remove(invoice_Return_Notice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Invoice_Return_NoticeExists(int id)
        {
            return _context.Invoice_Return_Notice.Any(e => e.IRN_ID == id);
        }
    }
}
