using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GLifeApplication.Models
{
    [MetadataType(typeof(FoodRecordMetadata))]
    public partial class FoodRecord
    {
        private class FoodRecordMetadata
        {
            [DisplayName("食物名稱")]
            [Required(ErrorMessage = "請輸入食物名稱")]
            public string FoodName { get; set; }

            [DisplayName("數量")]
            [Required(ErrorMessage = "請輸入數量")]
            public string FoodAmount { get; set; }

            [DisplayName("使用者")]
            public string Username { get; set; }

            [DisplayName("日期")]
            [Required(ErrorMessage = "請選擇日期")]
            public string CreateDate { get; set; }

            [DisplayName("分類")]
            [Required(ErrorMessage = "請輸入分類")]
            public string FoodType { get; set; }

            public int FoodRecord_Id { get; set; }

        }
    }
   
}