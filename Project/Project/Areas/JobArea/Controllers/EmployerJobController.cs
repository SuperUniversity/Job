using Project.Areas.JobArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Areas.JobArea.Models;
using Microsoft.AspNet.Identity;
using Project.Areas.JobArea.Models.List;

namespace Project.Areas.JobArea.Controllers
{
    public class EmployerJobController : Controller
    {
        
        // GET: JobArea/EmployerJob
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmployerCompanyList postback)
        {
            if (this.ModelState.IsValid)
            {
                //取得目前工作
                var currentList = Models.List.Operation.GetCurrentList();

                //取得廠商的ID
                var EmployerID = HttpContext.User.Identity.GetUserId();
                using(superuniversityEntities db =new superuniversityEntities())
                {
                    var order = new Models.EmployerCompany()
                    {
                        CompanyUserID = EmployerID,
                        CompanyName = postback.CompanyName,
                        EmployerPhone =postback.EmployerPhone,
                        CompanyAdress=postback.CompanyAdress
                        

                    };
                    db.EmployerCompany.Add(order);
                    db.SaveChanges();

                    var orderdetails = currentList.ToJobList(order.CompanyID);

                    db.JobList.AddRange(orderdetails);
                    db.SaveChanges();
                }
                return Content("新增成功");
            }
            return View();
        }
    }
}