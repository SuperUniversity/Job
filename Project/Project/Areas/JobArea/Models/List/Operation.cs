using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Project.Areas.JobArea.Models.List
{

    public static class Operation
    {
        [WebMethod(EnableSession = true)]
        public static Models.List.JobList GetCurrentList()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["JobList"] == null)
                {
                    var order = new Models.List.JobList();
                    HttpContext.Current.Session["JobList"] = order;
                }
                return (Models.List.JobList)HttpContext.Current.Session["JobList"];
            }
            else
            {
                throw new InvalidOperationException("System.Web.HttpContext.Current為空，請檢查");
            }
        }

    }
}