using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GLifeApplication.Models
{
    [MetadataType(typeof(SportDatabaseMetadata))]
    public partial class SportDatabase
    {
        private class SportDatabaseMetadata
        {
            
            public string SportName { get; set; }

            public int Calories { get; set; }

            public int Sport_Id { get; set; }

        }
    }
}