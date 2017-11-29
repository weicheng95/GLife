using GLifeApplication.Models;
using GLifeApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLifeApplication.Service;
using GLifeApplication.Services;

namespace GLifeApplication.Controllers
{
    public class HomeController : Controller
    {
        private FoodRecordService foodRecordService = new FoodRecordService();
        private SportRecordService sportRecordService = new SportRecordService();
        private ArticleService articleService = new ArticleService();
        private AccountService accountService = new AccountService();
        private FoodAndSportDabataseService FoodAndSportDBService = new FoodAndSportDabataseService();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
      
        [Authorize]
        //public ActionResult CreateFood()
        //{
        //    return PartialView();
        //}

        [Authorize]
        public ActionResult CreateFood()
        {         
            DateTime currentDate = (DateTime)Session["currentDate"];
            ViewBag.date = currentDate.ToShortDateString();
            return PartialView();
        }

        [Authorize]
        public ActionResult CreateSport()
        {
            DateTime currentDate = (DateTime)Session["currentDate"];
            ViewBag.date = currentDate.ToShortDateString();
            return PartialView();
        }


        public PartialViewResult FoodDB(String search)
        {
            FoodDatabaseView foodDatabaseView = new FoodDatabaseView();
            if (String.IsNullOrEmpty(search))
            {
                foodDatabaseView.FoodDatabaseList = FoodAndSportDBService.GetFoodDB();
            }
            else
            {
                foodDatabaseView.FoodDatabaseList = FoodAndSportDBService.GetFoodDB(search);
            }

            return PartialView(foodDatabaseView);
        }

        [HttpGet]
        public PartialViewResult FoodDBDetail(int? id)
        {
            if (id.HasValue)
            {
                FoodDatabase foodDBDetail = FoodAndSportDBService.GetFoodDataById(id);
                FoodRecord foodRecord = new FoodRecord();
                foodRecord.FoodName = foodDBDetail.FoodName;
                foodRecord.Calories = foodDBDetail.Calories;
                foodRecord.Food_Id = foodDBDetail.Food_Id;
                DateTime date = (DateTime)Session["currentDate"];
                foodRecord.CreateDate = date;
                System.Diagnostics.Debug.WriteLine(foodRecord.CreateDate);

                return PartialView(foodRecord);
            }
            else
            {
                return PartialView();
            }

        }

        public PartialViewResult SportDB(String search)
        {
            SportDatabaseView sportDatabaseView = new SportDatabaseView();
            if (String.IsNullOrEmpty(search))
            {
                sportDatabaseView.SportDatabaseList = FoodAndSportDBService.GetSportDB();
            }
            else
            {
                sportDatabaseView.SportDatabaseList = FoodAndSportDBService.GetSportDB(search);
            }

            return PartialView(sportDatabaseView);
        }

        [HttpGet]
        public PartialViewResult SportDBDetail(int? id)
        {
            if (id.HasValue)
            {
                SportDatabase sportDBDetail = FoodAndSportDBService.GetSportDataById(id);
                SportRecord sportRecord = new SportRecord();
                sportRecord.SportName = sportDBDetail.SportName;
                sportRecord.BurnCalories = sportDBDetail.Calories;
                DateTime date = (DateTime)Session["currentDate"];
                sportRecord.CreateDate = date;
                sportRecord.Sport_Id = sportDBDetail.Sport_Id;
                return PartialView(sportRecord);
            }
            else
            {
                return PartialView();
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult AddFood([Bind(Include = "FoodAmount, Food_Id, FoodType, CreateDate")]FoodRecord foodRecord, FormCollection form)
        {
            foodRecord.Username = User.Identity.Name;;
            foodRecordService.Insert(foodRecord);

            // return JavaScript("location.reload(true)");
            return RedirectToAction("Record");
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddSport([Bind(Include = "SportTime, Sport_Id, CreateDate")]SportRecord sportRecord, FormCollection form)
        {

            sportRecord.Username = User.Identity.Name;
            sportRecordService.Insert(sportRecord);

            // return JavaScript("location.reload(true)");
            return RedirectToAction("Record");
        }

        [Authorize]
        public ActionResult Record(String Date)
        {
            RecordView Data = new RecordView();
            // Data.Search = Search;
            // Data.Paging = new ForPaging(Page);

            if (!String.IsNullOrEmpty(Date))
            {
                DateTime convertDatetime = Convert.ToDateTime(Date);
                Data.Date = new ForDateTime(convertDatetime);
                Session["currentDate"] = Data.Date.CurrentDate;
            }
            else
            {
                Data.Date = new ForDateTime();
                Session["currentDate"] = Data.Date.CurrentDate;
            }

            Data.FoodRecordList = foodRecordService.GetFoodRecordList(Data.Date, User.Identity.Name);
            Data.SportRecordList = sportRecordService.GetSportRecordList(Data.Date, User.Identity.Name);
            Data.TotalCaloriesList = foodRecordService.GetTotalCaloriesList(Data.Date, User.Identity.Name);
            ViewBag.CaloriesRequired = accountService.ReturnCaloriesRequired(User.Identity.Name);

            return View(Data);
        }

        public PartialViewResult CaloriesGraph()
        {
            RecordView Data = new RecordView();
            Data.TotalCaloriesList = foodRecordService.GetTotalCaloriesList(User.Identity.Name);
            ViewBag.Calories = Data.TotalCaloriesList.Select(p => p.CaloriesResult).ToArray();
            ViewBag.BreakfastCalories = Data.TotalCaloriesList.Select(p => p.BreakfastCalories).ToArray();
            ViewBag.LunchCalories = Data.TotalCaloriesList.Select(p => p.LunchCalories).ToArray();
            ViewBag.DinnerCalories = Data.TotalCaloriesList.Select(p => p.DinnerCalories).ToArray();
            ViewBag.SportCalories = Data.TotalCaloriesList.Select(p => p.SportCalories).ToArray();
            ViewBag.Date = Data.TotalCaloriesList.Select(p => p.CreateDate.ToString("MM/dd")).ToArray();
            return PartialView();
        }

        [Authorize]
        public ActionResult DeleteFood(int Id)
        {
           foodRecordService.DeleteDataById(Id);

           return RedirectToAction("Record");
        }

        [Authorize]
        public ActionResult DeleteSport(int Id)
        {
            sportRecordService.DeleteDataById(Id);
            return RedirectToAction("Record");
        }

        //autocomplete for foodname
        [HttpPost]
        public JsonResult AutoCompleteForFood(string prefix)
        {
            GLifeEntities entities = new GLifeEntities();
            var query = (from FoodName in entities.FoodDatabase
                         where FoodName.FoodName.StartsWith(prefix)
                         select new
                         {
                             label = FoodName.FoodName,
                             val = FoodName.Food_Id
                         }).ToList();

            return Json(query);
        }

        //autocomplete for sportname
        [HttpPost]
        public JsonResult AutoCompleteForSport(string prefix)
        {
            GLifeEntities entities = new GLifeEntities();
            var query = (from SportName in entities.SportDatabase
                         where SportName.SportName.StartsWith(prefix)
                         select new
                         {
                             label = SportName.SportName,
                             val = SportName.Sport_Id
                         }).ToList();

            return Json(query);
        }


        [Authorize]
        public ActionResult Analysis(String Date, String days)
        {
            AnalysisView analysis = new AnalysisView();
            RecordView Data = new RecordView();

            if (days == null)
            {
                days = "7";
            }
            
            if (!String.IsNullOrEmpty(Date))
            {
                DateTime convertDatetime = Convert.ToDateTime(Date);
                Data.Date = new ForDateTime(convertDatetime);
                
            }
            else
            {
                Data.Date = new ForDateTime();
                
            }

            analysis.FoodView = foodRecordService.GetDistinctFoodRecordList(Data.Date, Convert.ToInt32(days), User.Identity.Name);
            analysis.FoodResultView = foodRecordService.GetTotalCaloriesList(Data.Date, Convert.ToInt32(days), User.Identity.Name);
            analysis.day = days;
            ViewBag.CaloriesRequired = accountService.ReturnCaloriesRequired(User.Identity.Name);

            return View(analysis);

            //Data.SportRecordList = sportRecordService.GetSportRecordList(Data.Date, User.Identity.Name);
            //Data.TotalCaloriesList = foodRecordService.GetTotalCaloriesList(Data.Date, days, User.Identity.Name);
            //ViewBag.CaloriesRequired = accountService.ReturnCaloriesRequired(User.Identity.Name);
            //return View(Data);
        }
        //public ActionResult AddFood([Bind(Include = "FoodAmount, CreateDate, FoodType, Food_Id")]FoodRecord foodRecord, FormCollection form)
        //{

        //    foodRecord.Username = User.Identity.Name;
        //    foodRecord.FoodType = form["foodtype"];
        //    foodRecordService.Insert(foodRecord);

        //    // return JavaScript("location.reload(true)");
        //    return RedirectToAction("Record");
        //}

        //[Authorize]
        //[HttpPost]
        //public ActionResult AddSport([Bind(Include = "Sport_Id, CreateDate, SportTime")]SportRecord sportRecord, FormCollection form)
        //{

        //    sportRecord.Username = User.Identity.Name;
        //    sportRecordService.Insert(sportRecord);

        //    // return JavaScript("location.reload(true)");
        //    return RedirectToAction("Record");
        //}


    }
}