using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GLifeApplication.Models
{
    [MetadataType(typeof(FoodDatabaseMetadata))]
    public partial class FoodDatabase
    {
        private class FoodDatabaseMetadata
        {
            
            public string FoodName { get; set; }

            public int Barcode { get; set; }

            public int Calories { get; set; }

            public int Food_Id { get; set; }

        }
    }
}