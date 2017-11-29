using GLifeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GLifeApplication.Service
{
    public class AccountService
    {
        private GLifeEntities db = new GLifeEntities();

        #region 註冊
        public void Register(Account NewAccount)
        {
            NewAccount.Password = HashPassword(NewAccount.Password);
            NewAccount.CaloriesRequired = Convert.ToInt32(GetCaloriesRequired(NewAccount));
            db.Account.Add(NewAccount);
            db.SaveChanges();
        }
        #endregion

        #region 登入確認
        public string LoginCheck(string Username, string Password)
        {
            Account LoginAccount = db.Account.Find(Username);
            
            if (LoginAccount != null)
            {
                if (PasswordCheck(LoginAccount, Password))
                {
                    return "";
                }
                else
                {
                    return "Wrong Password";
                }
            }
            else
            {
                return "無此會員帳號，請去註冊";
            }
        }
        #endregion

        #region 密碼確認
        public bool PasswordCheck(Account CheckAccount, string Password)
        {
            bool result = CheckAccount.Password.Equals(HashPassword(Password));
            return result;
        }
        #endregion

        #region 帳號註冊重複確認
        public bool AccountCheck(string Username)
        {
            Account search = db.Account.Find(Username);
            bool result = (search == null);
            return result;
        }
        #endregion

        #region Hash密碼
        public string HashPassword(string Password)
        {

            string saltkey = "sE7T8Efdaib561J76Feq9Hd7E";
            string saltAndPassword = String.Concat(Password, saltkey);
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            byte[] HashDate = sha1Hasher.ComputeHash(PasswordData);
            string Hashresult = "";
            for (int i = 0; i < HashDate.Length; i++)
            {
                Hashresult += HashDate[i].ToString("x2");
            }
            return Hashresult;
        }
        #endregion

        /*
        #region 取得角色
        public string GetRole(string Username)
        {
            string Role = "User";
            Account LoginAccount = db.Account.Find(Username);
            if (LoginAccount.IsAdmin)
            {
                Role += ",Admin";

            }
            return Role;
        }
        #endregion
    */

        #region 抓出使用者目標
        public double ReturnCaloriesRequired(string Username)
        {
            Account SearchMemberData = db.Account.Find(Username);
            return SearchMemberData.CaloriesRequired;
        }
        #endregion

        #region 計算每日卡路里需求
        public double GetCaloriesRequired(Account newAccount)
        {
            double REE;
            if (newAccount.Gender == "男")
            {
                REE = (66 + (13.7 * newAccount.Weight) + (5 * newAccount.Height) - (6.8 * newAccount.Age)) * newAccount.Activity;
            }
            else
            {
                REE = (655 + (9.6 * newAccount.Weight) + (1.8 * newAccount.Height) - (4.7 * newAccount.Age)) * newAccount.Activity;
            }


            //double CWTLPD = newAccount.WeightToLossPerWeek * 7700 / 7;

            double CaloriesRequired = REE;

            return CaloriesRequired;
        }
        #endregion

        #region 顯示使用者資料
        public Account GetMemberList(String Username)
        {
            //use to accept all search data
            Account SearchMemberData = db.Account.Find(Username);

            return SearchMemberData;
        }
        #endregion

        public void Save()
        {
            db.SaveChanges();
        }

        public Boolean CheckUser(String username)
        {
            Account Data = db.Account.Find(username);
            return (Data != null);
        }
    }
}