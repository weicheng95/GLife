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
    public class SportRecordService
    {
        GLifeEntities db = new GLifeEntities();


        public void Save()
        {
            db.SaveChanges();
        }

        #region check a SportRecord with id
        public SportRecord GetDataById(int Id)
        {
            return db.SportRecord.Find(Id);
        }
        #endregion

        public void Insert(SportRecord newSportRecord)
        {
            var query = from p in db.SportDatabase
                         where ((p.Sport_Id) == newSportRecord.Sport_Id)
                         select p;

            //choice from SportDB
            SportDatabase SportDatabase = query.Single();
            newSportRecord.BurnCalories = SportDatabase.Calories * newSportRecord.SportTime;
            newSportRecord.SportName = SportDatabase.SportType;
            db.SportRecord.Add(newSportRecord);

            Save();
            //use stored procedure to calculate calories spent by date
            db.TotalCaloriesCal(newSportRecord.CreateDate, newSportRecord.Username);
            //db.SaveChanges();
        }

        #region 
        //delete by Id
        public void DeleteDataById(int Id)
        {
            SportRecord DeleteSportRecord = db.SportRecord.Find(Id);
            String username = DeleteSportRecord.Username;
            DateTime date = DeleteSportRecord.CreateDate;
            //delete all data from database
            db.SportRecord.Remove(DeleteSportRecord);
            Save();
            db.TotalCaloriesCal(date, username);
            Save();
        }
        #endregion

        #region
        // get SportRecord into list by date
        //check and get article with paging and array
        public List<SportRecord> GetSportRecordList(ForDateTime Date, String Username)
        {
            //use to accept all search data
            IQueryable<SportRecord> SearchData;
            SearchData = GetAllSportRecordList();
            DateTime currentDate = Date.CurrentDate;

            var query = from s in SearchData
                        where DbFunctions.TruncateTime(s.CreateDate) == currentDate
                        where s.Username == Username
                        select s;

            return query.ToList();
        }
        #endregion

        //Search data without search value 
        public IQueryable<SportRecord> GetAllSportRecordList()
        {
            IQueryable<SportRecord> Data = db.SportRecord;

            return Data;
        }

        #region
        //check and get article with paging and array
        // get SportRecord into list by date
        public List<TotalCaloriesResult> GetTotalCaloriesList(ForDateTime Date, String Username)
        {
            //use to accept all search data
            IQueryable<TotalCaloriesResult> SearchData;
            SearchData = db.TotalCaloriesResult;
            DateTime currentDate = Date.CurrentDate;

            var query = from s in SearchData
                        where DbFunctions.TruncateTime(s.CreateDate) == currentDate
                        where s.Username == Username
                        select s;


            return query.ToList();
        }
        #endregion

        #region check SportRecord if available
        public bool CheckUpdate(int SportRecord_Id)
        {
            SportRecord Data = db.SportRecord.Find(SportRecord_Id);
            return (Data != null);
        }
        #endregion



        /*
                //Search data without search value 
                public List<SportRecord> GetAllDataList()
                {
                    IQueryable<SportRecord> Data = db.SportRecord;
                    return Data.OrderByDescending(p => p.id).ToList();
                }
                */

        /*
                //Search data that contain search value
                public IQueryable<SportRecord> GetAllSport SportRecordList(ForPaging Paging, string Search)
                {
                    IQueryable<SportRecord> Data = db.SportRecord.Where(
                        p => p.SportName.Contains(Search));
                    //calculate total page
                    Paging.MaxPage = Convert.ToInt32(Math.Ceiling(
                        Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                    Paging.SetRightPage();
                    return Data;
                }
                */
    }
}