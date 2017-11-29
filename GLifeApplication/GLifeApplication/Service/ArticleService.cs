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
    public class ArticleService
    {
        GLifeEntities db = new GLifeEntities();


        public void Save()
        {
            db.SaveChanges();
        }

        #region check a FoodRecord with id
        public Article GetDataById(int Id)
        {
            return db.Article.Find(Id);
        }
        #endregion

        public void Insert(Article newArticleRecord)
        {

            newArticleRecord.CreateDate = DateTime.Now;
            db.Article.Add(newArticleRecord);
            Save();

        }

        #region delete by Id
        public void Delete(int Id)
        {
            Article DeleteArticleRecord = db.Article.Find(Id);

            //delete all data from database
            db.Article.Remove(DeleteArticleRecord);
            Save();
        }
        #endregion

        #region get ArticleRecord into list by date
        //check and get article with paging and array
        public List<Article> GetArticleRecordList(ForDateTime Date)
        {
            //use to accept all search data
            IQueryable<Article> SearchData;
            SearchData = GetAllArticleRecordList();
            DateTime currentDate = Date.CurrentDate;

            var query = from s in SearchData
                        where DbFunctions.TruncateTime(s.CreateDate) == currentDate
                        orderby s.CreateDate descending
                        select s;


            return query.ToList();
        }
        #endregion

        //Search data without search value 
        public IQueryable<Article> GetAllArticleRecordList()
        {
            IQueryable<Article> Data = db.Article;

            return Data;
        }

        #region check FoodRecord if available
        public bool CheckUpdate(int Article_Id)
        {
            Article Data = db.Article.Find(Article_Id);
            return (Data != null);
        }
        #endregion



        /*
                //Search data without search value 
                public List<FoodRecord> GetAllDataList()
                {
                    IQueryable<FoodRecord> Data = db.FoodRecord;
                    return Data.OrderByDescending(p => p.id).ToList();
                }
                */

        /*
                //Search data that contain search value
                public IQueryable<FoodRecord> GetAllFood FoodRecordList(ForPaging Paging, string Search)
                {
                    IQueryable<FoodRecord> Data = db.FoodRecord.Where(
                        p => p.FoodName.Contains(Search));
                    //calculate total page
                    Paging.MaxPage = Convert.ToInt32(Math.Ceiling(
                        Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                    Paging.SetRightPage();
                    return Data;
                }
                */
    }
}