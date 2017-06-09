using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Areas.JobArea.Models;
using PagedList;

namespace Project.Areas.JobArea.Controllers
{
    public class HomeController : Controller
    {
        superuniversityEntities db = new superuniversityEntities();
        IRepository<Job> job = new Repository<Job>();
        IRepository<EmployerCompany> _Emp = new Repository<EmployerCompany>();
        // GET: JobArea/Home
        public ActionResult Index(int page=1,int perpage=15,string sortby="",string Jobnamesreach="",string Workplacesreach="",string Allsreach="")
        {
            //前台的工作管理

            //公司名稱
            //var result = (from s in db.EmployerCompany
            //              where s.CompanyID == job.
            //              select s.CompanyName);
            //ViewBag.name = result;

            //收尋的block            
            var jobfront = new List<Job>();
            var list = db.Job.ToList();
            string allstr = string.IsNullOrEmpty(Allsreach) ? "" : Allsreach;
            string jobstr = string.IsNullOrEmpty(Jobnamesreach) ? "" : Jobnamesreach;
            string workstr = string.IsNullOrEmpty(Workplacesreach) ? "" : Workplacesreach;

            if (allstr == "" && jobstr == "" && workstr == "")
            {
                jobfront = list;
            }
            else if (allstr !="")
            {
                jobfront = list.Select(p => p).Where(p => p.JobName.Contains(allstr) || p.Workplace.Contains(allstr)).ToList();
            }
            else
            {
                jobfront = list.Select(p => p).Where(p => p.JobName.Contains(jobstr)).ToList()
                  .Union(list.Select(p => p).Where(p => p.Workplace.Contains(workstr))).ToList();
            }

            ViewBag.SreachbyName = jobstr;
            ViewBag.SreachbyPlace = workstr;
            ViewBag.SreachbyAll = allstr;
            //排列的block
            ViewBag.SortbyID = string.IsNullOrEmpty(sortby) ? "JobID desc" : "";
            ViewBag.SortbyName = (sortby == "JobName") ? "JobName desc" : "JobName";
            ViewBag.SortbyPlace = (sortby == "Workplace") ? "Workplace desc" : "Workplace";
            ViewBag.SortbyPay = (sortby == "PayPerHour") ? "PayPerHour desc" : "PayPerHour";

            switch (sortby)
            {
                case "JobID desc":
                    jobfront = jobfront.OrderByDescending(p => p.JobID).ToList();
                    break;
                case "JobName desc":
                    jobfront = jobfront.OrderByDescending(p => p.JobName).ToList();
                    break;
                case "JobName":
                    jobfront = jobfront.OrderBy(p => p.JobName).ToList();
                    break;
                case "Workplace desc":
                    jobfront = jobfront.OrderByDescending(p => p.Workplace).ToList();
                    break;
                case "Workplace":
                    jobfront = jobfront.OrderBy(p => p.Workplace).ToList();
                    break;
                case "PayPerHour desc":
                    jobfront = jobfront.OrderByDescending(p => p.PayPerHour).ToList();
                    break;
                case "PayPerHour":
                    jobfront = jobfront.OrderBy(p => p.PayPerHour).ToList();
                    break;
                default:
                    jobfront = jobfront.OrderBy(p => p.JobID).ToList();
                    break;   

            }


            return View(jobfront.ToList().ToPagedList(page,perpage));
        }

        public ActionResult Detail(Job j,int id)
        {
            ViewBag.map = db.Job.Find(id).Workplace.ToString();
            ViewBag.datas = db.Jobtime.ToList();
            return View(job.GetById(id));            
        }

        public ActionResult CompanyDetail(EmployerCompany emp,int id)
        {
            ViewBag.Gmap = db.EmployerCompany.Find(job.GetById(id).CompanyID).CompanyAdress.ToString(); 
            var list=  (from s in db.Job.AsEnumerable()
                        where (s.CompanyID == int.Parse(Request.Cookies["nameid"].Value))
                        select s.JobName);
            ViewBag.Jobname = list.ToList();
            return View(_Emp.GetById(job.GetById(id).CompanyID));
        }
        public ActionResult Hire(Job j)
        {

            return View();
        }
    }
}