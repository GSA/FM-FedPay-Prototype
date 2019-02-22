using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FEDPAY.Models;
using FEDPAYmgr.Models;


// all employees
//public ActionResult Index()
//{
//    EmployeeContext employeeContext = new EmployeeContext();

//    List<Employee> empList = employeeContext.Employees.ToList();

//    return View(empList);
//}



namespace FEDPAY.Controllers
{
    public class Admin_DiffController : Controller
    {
        private readonly FEDPAYContext _context;

        public Admin_DiffController(FEDPAYContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public ActionResult BIndex(string po)
        //{ return RedirectToAction(nameof(Index), po); }


        // Get input Parameter
        public IActionResult Param()
        {

          //  ProducesResponseTypeAttribute.
         // RouteData.PushState
         
            return View();
            
        }

        //GET Detailed Admin Diff Stmt
        public async Task<IActionResult> Details(string po,string inv, int seq, string stype )
        {
            var AdDet = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po).Where(adiff => adiff.ADD_INVOICE_NO == inv).
                Where(adiff => adiff.ADD_SEQ_NO == seq).FirstOrDefaultAsync();

            if (stype == "P")
            { ViewBag.IndxINV = null;
                ViewBag.IndxPO = AdDet.ADD_PO_NO;
            }
            else if (stype == "I")
            {
                ViewBag.IndxINV = AdDet.ADD_INVOICE_NO;
                ViewBag.IndxPO = null;
            }
            else
            {
                ViewBag.IndxINV = AdDet.ADD_INVOICE_NO;
                ViewBag.IndxPO = AdDet.ADD_PO_NO;
            }

            //    ViewBag.IndxVEN = VAR TO BE ESTABLISHED;



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
            { if (AdDet.ADD_BILLED_QTY > AdDet.ADD_PO_QTY)
                { ViewBag.Diff_qty = AdDet.ADD_BILLED_QTY - AdDet.ADD_PO_QTY;
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
                ViewBag.Diff_amt4ucp =  ViewBag.Diff_ucp * AdDet.ADD_PO_QTY;
            }

            ViewBag.queryRT = DateTime.Now;

            return View(AdDet);
        }

        // GET: Admin Diff Summary Info
        public async Task<IActionResult> Index(AdmDiffStmtVw po) {
      //      ViewBag.IndxINV = po.ADD_INVOICE_NO;
      //      Console.Write(po);

            if (po.ADD_INVOICE_NO is null && po.ADD_PO_NO != null)
            {
                List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po.ADD_PO_NO).ToListAsync();
                if (addDiff.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested PO";
                }
                else
                {
                    ViewBag.SearchRes = " ";
                    ViewBag.IndxSType = "P";


                }
                ViewBag.SearchCriteria = "PO#  "+ po.ADD_PO_NO;
                return View(addDiff);
            }
            else if (po.ADD_INVOICE_NO != null && po.ADD_PO_NO != null)
            {
            List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po.ADD_PO_NO).Where(adiff => adiff.ADD_INVOICE_NO == po.ADD_INVOICE_NO).ToListAsync();

            if (addDiff.Count == 0)
            {
                ViewBag.SearchRes = "NO Results were Found for Requested PO# and Invoice#";
            }
            else
            {
                ViewBag.SearchRes = " ";
                ViewBag.IndxSType = "B";

                }
                ViewBag.SearchCriteria = "PO#  " + po.ADD_PO_NO + "   Invoice# " + po.ADD_INVOICE_NO;
            return View(addDiff);
            }
            else if (po.ADD_INVOICE_NO != null && po.ADD_PO_NO is null)
            {
                List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_INVOICE_NO == po.ADD_INVOICE_NO).ToListAsync();

                if (addDiff.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested Invoice#";
                }
                else
                {
                    ViewBag.SearchRes = " ";
                    ViewBag.IndxSType = "I";


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

            // check for both inv and po or just one or the other


        }



        // Get original Index items back
        public async Task<IActionResult> Index2(string po, string inv)
        {
            //    List<Admin_Diff> addDiff = await _context.Admin_Diff.Where(adiff => adiff.ADD_PO_NO == "2JDV01B8N").ToListAsync();
            //  List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == "2JDV01B8N").ToListAsync();
            //   var addDiff = _context.Query<AdmDiffStmtVw>().ToList();



            //  TempData["Key"] = po.ADD_PO_NO;


            if (inv is null && po != null)
            {
                List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po).ToListAsync();
                if (addDiff.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested PO#";
                }
                else
                {
                    ViewBag.SearchRes = " ";
                    ViewBag.IndxSType = "P";

                }
                ViewBag.SearchCriteria = "PO#  "+ po;
                return View(addDiff);
            }
            else if (inv != null && po != null)
            {
            List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po).Where(adiff => adiff.ADD_INVOICE_NO == inv).ToListAsync();

            if (addDiff.Count == 0)
            {
                ViewBag.SearchRes = "NO Results were Found for Requested PO# and Invoice#";
            }
            else
            {
                ViewBag.SearchRes = " ";
                ViewBag.IndxSType = "B";

                }
            ViewBag.SearchCriteria = "PO#  " + po + "   Invoice# " + inv;
            return View(addDiff);
            }
            else if (inv != null && po is null)
            {
                List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_INVOICE_NO == inv).ToListAsync();

                if (addDiff.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested Invoice#";
                }
                else
                {
                    ViewBag.SearchRes = " ";
                    ViewBag.IndxSType = "I";

                }
                ViewBag.SearchCriteria = "Invoice# " + inv;
                return View(addDiff);
            }
            else
            {
                    List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == po).ToListAsync();
                    ViewBag.SearchCriteria = "No Search Criteria was Entered";
                    ViewBag.SearchRes = "Please Click New Search and enter at least one search criteria";
                    return View(addDiff);
            }

            // check for both inv and po or just one or the other


        }


        // all admin diffs
        // all employees
        //public ActionResult Index()
        //{
        //    FEDPAYContext fpContext = new FEDPAYContext();

        //    List<Admin_Diff> adList = fpContext.Admin_Diff.ToList();

        //    return View(adList);
    }



}

