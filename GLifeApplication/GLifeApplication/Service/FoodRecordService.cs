using GLifeApplication.Models;
using GLifeApplication.ViewModels;
using GLifeApplication.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace GLifeApplication.Service
{
    public class FoodRecordService
    {
        GLifeEntities db = new GLifeEntities();


        public void Save()
        {
            db.SaveChanges();
        }

        #region check a FoodRecord with id
        public FoodRecord GetDataById(int Id)
        {
            return db.FoodRecord.Find(Id);
        }
        #endregion

        public void DeleteDataById(int Id)
        {
            FoodRecord data = db.FoodRecord.Find(Id);
            String username = data.Username;
            DateTime date = data.CreateDate;

            db.FoodRecord.Remove(data);
            Save();

            db.TotalCaloriesCal(date, username);
            Save();
        }

        public void Insert(FoodRecord newFoodRecord)
        {

            /*
            var query = from p in db.FoodDatabase
                        where ((p.FoodName) == newFoodRecord.FoodName)
                        select p;
                        */

            var query = from p in db.FoodDatabase
                         where ((p.Food_Id) == newFoodRecord.Food_Id)
                         select p;

            //choice from foodDB
            FoodDatabase foodDatabase = query.Single();
            newFoodRecord.Calories = foodDatabase.Calories;
            newFoodRecord.FoodName = foodDatabase.FoodName;
            db.FoodRecord.Add(newFoodRecord);

            Save();

            //use stored procedure to calculate calories spent by date
            db.TotalCaloriesCal(newFoodRecord.CreateDate, newFoodRecord.Username);

        }

        #region delete by Id
        public void Delete(int Id)
        {
            FoodRecord DeleteFoodRecord = db.FoodRecord.Find(Id);

            //delete all data from database
            db.FoodRecord.Remove(DeleteFoodRecord);
            Save();
        }
        #endregion

        #region get FoodRecord into list by date
        //check and get article with paging and array
        public List<FoodRecord> GetFoodRecordList(ForDateTime Date, String Username)
        {
            //use to accept all search data
            IQueryable<FoodRecord> SearchData;
            SearchData = GetAllFoodRecordList();
            DateTime currentDate = Date.CurrentDate;

            var query = from s in SearchData
                        where DbFunctions.TruncateTime(s.CreateDate) == currentDate
                        where s.Username == Username
                        select s;


            return query.ToList();
        }
        #endregion

        #region get FoodRecord into list by date
        //check and get article with paging and array
        public IQueryable<FoodView> GetDistinctFoodRecordList(ForDateTime Date, int? days, String Username)
        {
            //use to accept all search data
            IQueryable<FoodRecord> SearchData;
            SearchData = GetAllFoodRecordList();
            DateTime currentDate = Date.CurrentDate.AddDays(Convert.ToDouble(-days));

            var query = (from s in SearchData
                        where DbFunctions.TruncateTime(s.CreateDate) > currentDate
                        where s.Username == Username
                        group s.FoodName by new
                        {
                            fooname = s.FoodName,
                            calories = s.Calories,
                        }
                        into g
                        select new FoodView
                        {
                           FoodName = g.Key.fooname,
                           Calories = g.Sum(a=>g.Key.calories),
                           Count = g.Count()
                        });


            return query;
        }
        #endregion

        #region get FoodRecord into list by date
        //check and get article with paging and array
        public IQueryable<TotalCaloriesResultViewCustom>GetTotalCaloriesList(ForDateTime Date, int? days, String Username)
        {
            //use to accept all search data
            IQueryable<TotalCaloriesResult> SearchData;
            SearchData = db.TotalCaloriesResult;
            DateTime currentDate = Date.CurrentDate.AddDays(Convert.ToDouble(-days));

            var query = (from s in SearchData
                         where DbFunctions.TruncateTime(s.CreateDate) > currentDate
                         where s.Username == Username
                         select new TotalCaloriesResultViewCustom
                         {
                             breakfastCalories = s.BreakfastCalories,
                             lunchCalories = s.LunchCalories,
                             dinnerCalories = s.DinnerCalories,
                             date = s.CreateDate
                        });

            return query;
        }
        #endregion

        //Search data without search value 
        public IQueryable<FoodRecord> GetAllFoodRecordList()
        {
            IQueryable<FoodRecord> Data = db.FoodRecord;

            return Data;
        }

        #region get FoodRecord into list by date
        //check and get article with paging and array
        public List<TotalCaloriesResult> GetTotalCaloriesList(ForDateTime Date, String Username)
        {
            //use to accept all search data
            IQueryable<TotalCaloriesResult> SearchData;
            SearchData = db.TotalCaloriesResult;
            DateTime currentDate = Date.CurrentDate;

            var query = from s in SearchData
                        where DbFunctions.TruncateTime(s.CreateDate)  == currentDate
                        where s.Username == Username
                        select s;


            return query.ToList();
        }
        #endregion

        #region get FoodRecord into list by date
        //check and get article with paging and array
        public List<TotalCaloriesResult> GetTotalCaloriesList(String Username)
        {
            //use to accept all search data
            IQueryable<TotalCaloriesResult> SearchData;
            SearchData = db.TotalCaloriesResult;
            DateTime currentDate = DateTime.Now.AddDays(-7);

            var query = from s in SearchData
                        where DbFunctions.TruncateTime(s.CreateDate) > currentDate
                        where s.Username == Username
                        orderby s.CreateDate
                        select s;

            return query.ToList();
        }
        #endregion

        #region check FoodRecord if available
        public bool CheckUpdate(int FoodRecord_Id)
        {
            FoodRecord Data = db.FoodRecord.Find(FoodRecord_Id);
            return (Data != null);
        }
        #endregion
    }
}