using GLifeApplication.Models;
using GLifeApplication.Service;
using GLifeApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GLifeApplication.Controllers
{
    public class MemberController : Controller
    {
        private AccountService accountService = new AccountService();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        //login
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLoginView LoginAccount)
        {
            string ValidateStr = accountService.LoginCheck(LoginAccount.Username, LoginAccount.Password);
            if (String.IsNullOrEmpty(ValidateStr))
            {

                //add a new ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    LoginAccount.Username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    FormsAuthentication.FormsCookiePath);

                string enTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", ValidateStr);
                return View(LoginAccount);
            }
        }

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterView RegisterAccount)
        {
            if (ModelState.IsValid)
            {
                RegisterAccount.NewAccount.Password = RegisterAccount.Password;

                //call service for register new member
                accountService.Register(RegisterAccount.NewAccount);

                TempData["RegisterState"] = "註冊成功";
                return RedirectToAction("RegisterResult");
            }
            RegisterAccount.Password = null;
            RegisterAccount.PasswordCheck = null;
            return View(RegisterAccount);
        }

        public ActionResult RegisterResult()
        {
            return View();
        }

        public JsonResult AccountCheck(AccountRegisterView RegisterAccount)
        {
            return Json(accountService.AccountCheck(RegisterAccount.NewAccount.Username)
                , JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult Setting()
        {
            if (User.Identity.IsAuthenticated)
            {
                Account member = accountService.GetMemberList(User.Identity.Name);
                return View(member);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Setting(string Username, FormCollection FormValues)
        {
            Account Data = accountService.GetMemberList(User.Identity.Name);
            UpdateModel(Data);
            accountService.Save();

            //update calories require
            Account DataUpdated = accountService.GetMemberList(User.Identity.Name);
            DataUpdated.CaloriesRequired = Convert.ToInt32(accountService.GetCaloriesRequired(DataUpdated));
            accountService.Save();

            return RedirectToAction("Setting");
        }
    }
}