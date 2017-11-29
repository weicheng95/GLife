using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GLifeApplication.Models
{
    [MetadataType(typeof(SportRecordMetadata))]
    public partial class SportRecord
    {
        private class SportRecordMetadata
        {
            [DisplayName("運動類型")]
            [Required(ErrorMessage = "請輸入運動類型")]
            public string SportName { get; set; }

            [DisplayName("運動時間(分鐘)")]
            [Required(ErrorMessage = "請輸入運動時間")]
            public int SportTime { get; set; }

            [DisplayName("熱量消耗")]
            public int BurnCalories { get; set; }

            public int Sport_Id { get; set; }

        }
    }

}