using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Areas.JobArea.ViewModel
{
    public class EmployerLogin
    {
        [DisplayName("電子郵件")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "格式不正確")]
        [Required(ErrorMessage = "請輸入電子郵件")]
        public string EmployerMail { get; set; }
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]        
        [DataType(DataType.Password)]        
        public string Password { get; set; }
        [DisplayName("記住我")]
        public bool RememberMe { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "目前密碼")]
        public string OldPassword { get; set; }

        [Required]        
        [DataType(DataType.Password)]
        [Display(Name = "新密碼")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認新密碼")]
        [Compare("NewPassword", ErrorMessage = "新密碼與確認密碼不相符。")]
        public string ConfirmPassword { get; set; }
    }
}