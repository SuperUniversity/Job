using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Areas.JobArea.Models.List
{
    public class EmployerCompanyList
    {
        [DisplayName("公司名稱")]
        [Required(ErrorMessage = "公司名稱不可為白")]
        public string CompanyName { get; set; }
        [DisplayName("聯絡電話")]
        [Required(ErrorMessage = "聯絡電話不可為白")]
        public string EmployerPhone { get; set; }
        [DisplayName("公司地址")]
        [Required(ErrorMessage = "公司地址不可為白")]
        public string CompanyAdress { get; set; }
    }
}