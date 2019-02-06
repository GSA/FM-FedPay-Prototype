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



        // GET: Admin Diff
        public async Task<IActionResult> Index(AdmDiffStmtVw po)
        {
            //    List<Admin_Diff> addDiff = await _context.Admin_Diff.Where(adiff => adiff.ADD_PO_NO == "2JDV01B8N").ToListAsync();
            //  List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == "2JDV01B8N").ToListAsync();
            //   var addDiff = _context.Query<AdmDiffStmtVw>().ToList();


            //    Console.Write(po.ADD_PO_NO);

            //  TempData["Key"] = po.ADD_PO_NO;

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


        // all admin diffs
        // all employees
        //public ActionResult Index()
        //{
        //    FEDPAYContext fpContext = new FEDPAYContext();

        //    List<Admin_Diff> adList = fpContext.Admin_Diff.ToList();

        //    return View(adList);
    }



}

