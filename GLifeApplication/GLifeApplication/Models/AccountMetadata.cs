using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GLifeApplication.Models
{
    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
        private class AccountMetadata
            {
            [DisplayName("帳號")]
            [Required(ErrorMessage = "請輸入帳號")]
            [StringLength(20, MinimumLength =6, ErrorMessage ="帳號長度須介於6-20字元")]
            [Remote("AccountCheck", "Account", ErrorMessage ="此帳號已被註冊過")]
            public string Username { get; set; }

            public string Password {get;set;}

            [DisplayName("Email")]
            [Required(ErrorMessage = "請輸入Email")]
            [StringLength(200, ErrorMessage = "帳號長度最長200字元")]
            [EmailAddress(ErrorMessage ="這不是Email格式")]
            public string Email { get; set; }

            [DisplayName("身高")]
            [Required(ErrorMessage = "請輸入身高")]
            public float Height { get; set; }

            [DisplayName("體重")]
            [Required(ErrorMessage = "請輸入體重")]
            public float Weight { get; set; }

            [DisplayName("性別")]
            [Required(ErrorMessage = "請輸入性別")]
            public string Gender { get; set; }

            [DisplayName("年齡")]
            [Required(ErrorMessage = "請輸入年齡")]
            public int Age { get; set; }

            [DisplayName("每星期欲減少的體重")]
            [Required(ErrorMessage = "請輸入目標體重")]
            public float WeightToLossPerWeek { get; set; }

            [DisplayName("活動量")]
            [Required(ErrorMessage = "請選擇你的活動量")]
            public float Activity { get; set; }

            [DisplayName("每日需攝取卡路里")]
            [Required(ErrorMessage = "每日需攝取卡路里")]
            public float CaloriesRequired { get; set; }
        }
    }
    
}