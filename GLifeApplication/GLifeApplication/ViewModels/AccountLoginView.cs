﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class AccountLoginView
    {
        [DisplayName("會員帳號")]
        [Required(ErrorMessage = "請輸入會員帳號")]
        public string Username { get; set; }

        [DisplayName("會員密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
    }
}