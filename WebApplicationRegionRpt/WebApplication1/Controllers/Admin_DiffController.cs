using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FEDPAY.Models;
using FEDPAYmgr.Models;
using Microsoft.AspNetCore.Http;



namespace FEDPAY.Controllers
{
    public class Admin_DiffController : Controller
    {
        private readonly FEDPAYContext _context;
        public const string SessionKeyInv = "_Inv";
        public const string SessionKeyPO = "_PO";

        public Admin_DiffController(FEDPAYContext context)
        {
            _context = context;
        }

        // Get input Parameter
        public IActionResult Param()
        {

            HttpContext.Session.SetString(SessionKeyPO, "");
            HttpContext.Session.SetString(SessionKeyInv, "");

            return View();

        }

        //GET Detailed Admin Diff Stmt
        public async Task<IActionResult> Details(string po, string inv, int seq, string stype)
        {
            var AdDet = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po).Where(adiff => adiff.ADD_INVOICE_NO == inv).
                Where(adiff => adiff.ADD_SEQ_NO == seq).FirstOrDefaultAsync();


            //if (stype == "PDF")
            //{/**ENTER CODE TO CALL TEMPLATE FOR PDF  PASS AdDet **/
            //    public IActionResult CreateAdmDiffPDF(AdmDiffStmtVw AdDet); }

            ViewBag.IndxPO = HttpContext.Session.GetString(SessionKeyPO);
            ViewBag.IndxINV = HttpContext.Session.GetString(SessionKeyInv);
            ViewBag.IndxSEQ = seq;
            ViewBag.IndxSTYPE = "";


            if (AdDet == null)
            {
                return NotFound();
            }
            ViewBag.Vname = AdDet.VEN_NAME;
            ViewBag.Vaddr1 = AdDet.VEN_ADDRESS1;
            ViewBag.Vaddr2 = AdDet.VEN_ADDRESS2;
            ViewBag.Vaddr3 = AdDet.VEN_ADDRESS3;
            ViewBag.Diff_ucp = 0;
            ViewBag.Diff_qty = 0;
            ViewBag.Diff_amt4qty = 0.00;
            ViewBag.Diff_amt4ucp = 0.00;


            if (AdDet.ADIFF_REASON == "0S")
            {
                if (AdDet.ADD_BILLED_QTY > AdDet.ADD_PO_QTY)
                {
                    ViewBag.Diff_qty = AdDet.ADD_BILLED_QTY - AdDet.ADD_PO_QTY;
                }
                ViewBag.Diff_amt4qty = ViewBag.Diff_qty * AdDet.ADD_BILLED_UCP;
            }

            if (AdDet.ADIFF_REASON == "0T")
            {
                if (AdDet.ADD_BILLED_UCP > AdDet.ADD_PO_UCP)
                {
                    ViewBag.Diff_ucp = AdDet.ADD_BILLED_UCP - AdDet.ADD_PO_UCP;
                }
                ViewBag.Diff_amt4ucp = ViewBag.Diff_ucp * AdDet.ADD_BILLED_QTY;
            }

            if (AdDet.ADIFF_REASON == "0U")
            {
                if (AdDet.ADD_BILLED_QTY > AdDet.ADD_PO_QTY)
                {
                    ViewBag.Diff_qty = AdDet.ADD_BILLED_QTY - AdDet.ADD_PO_QTY;
                }
                ViewBag.Diff_amt4qty = ViewBag.Diff_qty * AdDet.ADD_BILLED_UCP;
                if (AdDet.ADD_BILLED_UCP > AdDet.ADD_PO_UCP)
                {
                    ViewBag.Diff_ucp = AdDet.ADD_BILLED_UCP - AdDet.ADD_PO_UCP;
                }
                ViewBag.Diff_amt4ucp = ViewBag.Diff_ucp * AdDet.ADD_PO_QTY;
            }

            ViewBag.queryRT = DateTime.Now;

            return View(AdDet);
        }

        // GET: Admin Diff Summary Info
        public async Task<IActionResult> Index(AdmDiffStmtVw po, string pos, string invs)
        {

            if (!String.IsNullOrEmpty(pos) || !String.IsNullOrEmpty(invs))
            {
                po.ADD_PO_NO = pos;
                po.ADD_INVOICE_NO = invs;
            }

            //if (po.ADD_PO_NO.Substring(0, 1) != "3")
            //{
            //    List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == null).ToListAsync();
            //    ViewBag.SearchCriteria = po.ADD_PO_NO;
            //    ViewBag.SearchRes = "PO used in Search Criteria must begin with a 3. Please Click New Search and change PO# to a valid PO#";
            //    return View(addDiff);
            //}
            if (po.ADD_INVOICE_NO is null && po.ADD_PO_NO != null)
            {
                HttpContext.Session.SetString(SessionKeyPO, po.ADD_PO_NO);
                List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po.ADD_PO_NO).
                    OrderByDescending(adiff => adiff.ADD_DATE_OF_DIFF).OrderBy(adiff => adiff.ADD_AMT).ToListAsync();
                if (addDiff.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested PO";
                }
                else
                {
                    ViewBag.SearchRes = " ";
                }

                ViewBag.SearchCriteria = "PO#  " + po.ADD_PO_NO;
                return View(addDiff);
            }
            else if (po.ADD_INVOICE_NO != null && po.ADD_PO_NO != null)
            {
                HttpContext.Session.SetString(SessionKeyPO, po.ADD_PO_NO);
                HttpContext.Session.SetString(SessionKeyInv, po.ADD_INVOICE_NO);
                List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po.ADD_PO_NO).Where(adiff => adiff.ADD_INVOICE_NO == po.ADD_INVOICE_NO).
                    OrderBy(adiff => adiff.ADD_AMT).ToListAsync();

                if (addDiff.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested PO# and Invoice#";
                }
                else
                {
                    ViewBag.SearchRes = " ";

                }
                ViewBag.SearchCriteria = "PO#  " + po.ADD_PO_NO + "   Invoice# " + po.ADD_INVOICE_NO;
                return View(addDiff);
            }
            else if (po.ADD_INVOICE_NO != null && po.ADD_PO_NO is null)
            {
                HttpContext.Session.SetString(SessionKeyInv, po.ADD_INVOICE_NO);
                List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_INVOICE_NO == po.ADD_INVOICE_NO).
                    OrderByDescending(adiff => adiff.ADD_DATE_OF_DIFF).OrderBy(adiff => adiff.ADD_FSS_PO_NO).OrderBy(adiff => adiff.ADD_AMT).ToListAsync();

                if (addDiff.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested Invoice#";
                }
                else
                {
                    ViewBag.SearchRes = " ";

                }
                ViewBag.SearchCriteria = "Invoice# " + po.ADD_INVOICE_NO;
                return View(addDiff);
            }
            else
            {
                List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po.ADD_PO_NO).ToListAsync();
                ViewBag.SearchCriteria = "No Search Criteria was Entered";
                ViewBag.SearchRes = "Please Click New Search and enter at least one search criteria";
                return View(addDiff);
            }


        }


    }

}

