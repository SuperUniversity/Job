using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Areas.JobArea.Models.List
{
    [Serializable]
    public class JobList : IEnumerable<JobItems>
    {
        //建構值
        public JobList()
        {
            this.jobitems = new List<JobItems>();
        }
        //儲存所有商品
        private List<JobItems> jobitems;
        // 取得廠商內工作機會的總數量
        public int Count
        {
            get
            {
                return this.jobitems.Count;
            }
        }
        //新增一筆Job，使用JobId
        public bool AddJob(int Jobid)
        {
            var findItem = this.jobitems.
                Where(s => s.JobID == Jobid).
                Select(s => s).
                FirstOrDefault();

            if (findItem == default(JobItems))
            {
                using(superuniversityEntities db =new superuniversityEntities())
                {
                    var job = (from s in db.Job
                               where s.JobID == Jobid
                               select s).FirstOrDefault();
                    if (job != default(Job))
                    {
                        this.AddJob(job);
                    }
                }
            }
            else
            {
                //如何改成工作(想一下)
                //存在購物車內，則將商品數量累加
                //findItem.Quantity += 1;
            }
            return true;
        }
        //新增一筆Job，使用Job物件
        private bool AddJob(Job job)
        {
            var jobitem = new JobItems()
            {
                JobID = job.JobID,
                JobName = job.JobName,
                PayPerHour = job.PayPerHour,
                Workplace = job.Workplace
            };
            this.jobitems.Add(jobitem);
            return true;
        }
        //移除一筆Job，使用JobId
        public bool RemoveJob(int JobId)
        {
            var findItem = this.jobitems
                         .Where(s => s.JobID == JobId)
                         .Select(s => s)
                         .FirstOrDefault();
            if (findItem == default(JobItems))
            {

            }
            else
            {
                this.jobitems.Remove(findItem);
            }
            return true;
        }
        //清空工作清單
        public bool ClearJob()
        {
            this.jobitems.Clear();
            return true;
        }
        //將工作清單的工作轉成OrderDetail的List
        public List<Models.JobList> ToJobList(int listId)
        {
            var result = new List<Models.JobList>();
            foreach(var jobitem in jobitems)
            {
                result.Add(new Models.JobList() {
                    JobName=jobitem.JobName,
                    PayPerHour=Convert.ToDecimal(jobitem.PayPerHour),
                    WorkPlace=jobitem.Workplace,
                    CompanyID=jobitem.JobID


                });
            }
            return result;
        }

        #region IEnumertor
        public IEnumerator<JobItems> GetEnumerator()
        {
            return ((IEnumerable<JobItems>)jobitems).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<JobItems>)jobitems).GetEnumerator();
        }
        #endregion
    }
}