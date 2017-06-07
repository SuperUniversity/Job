using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Areas.JobArea.Models.List
{
    [Serializable]
    public class JobItems
    {
        public int JobID { get; set; }
        public string JobName { get; set; }
        public Nullable<decimal> PayPerHour { get; set; }
        public string Workplace { get; set; }
    }
}