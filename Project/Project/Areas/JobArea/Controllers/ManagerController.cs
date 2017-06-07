using Microsoft.AspNet.Identity;
using Project.Areas.JobArea.Models;
using Project.Areas.JobArea.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.JobArea.Controllers
{
    public class ManagerController : Controller
    {
        IRepository<EmployerCompany> db = new Repository<EmployerCompany>();
        // GET: JobArea/Manager
        public  ActionResult Index(int id)
        {
                  
            return View(db.GetById(id));
        }
        [HttpGet]
        public ActionResult ChangePassword(int id)
        {
            EmployerCompany emp = db.GetById(id);            
            return View(emp);
        }

        [HttpPost]
        public ActionResult ChangePassword(EmployerCompany emp,int id)
        {
            emp.CompanyID = id;
            db.Update(emp);
            return RedirectToAction("Index",new { id= Request.Cookies["nameID"].Value });
        }

        public ActionResult JobManage()
        {
            return View();
        }

    }
}