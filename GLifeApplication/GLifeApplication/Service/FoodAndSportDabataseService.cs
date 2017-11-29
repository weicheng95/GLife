using GLifeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLifeApplication.Service
{
    public class FoodAndSportDabataseService
    {
        private GLifeEntities db = new GLifeEntities();

        public List<FoodDatabase> GetFoodDB()
        {
            var getFoodDB = db.FoodDatabase.Take(10).ToList();

            return getFoodDB;
        }

 
        public List<FoodDatabase> GetFoodDB(String search)
        {
            var getFoodDB = db.FoodDatabase.Where(p => p.FoodName.Contains(search)).OrderBy(p => p.FoodName);

            return getFoodDB.ToList();
        }

        public List<SportDatabase> GetSportDB()
        {
            var getSportDB = db.SportDatabase.ToList();

            return getSportDB;
        }

        public List<SportDatabase> GetSportDB(String search)
        {
            var getSportDB = db.SportDatabase.Where(p => p.SportType.Contains(search)).OrderBy(p => p.SportType);

            return getSportDB.ToList();
        }

        public FoodDatabase GetFoodDataById(int? Food_Id)
        {
            return db.FoodDatabase.Find(Food_Id);
        }

        public SportDatabase GetSportDataById(int? Sport_Id)
        {
            return db.SportDatabase.Find(Sport_Id);
        }
    }
}