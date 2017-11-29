using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace GLifeApplication.Models
{
    [MetadataType(typeof(ArticleMetadata))]

    public partial class Article
    {
        public class ArticleMetadata
        {
            [DisplayName("文章編號")]
            public int Article_Id { get; set; }

            [DisplayName("內容")]
            [Required(ErrorMessage = "請輸入內容")]
            public string Content { get; set; }

            [DisplayName("Username")]
            public string Username { get; set; }

            [DisplayName("時間")]
            public string CreateDate { get; set; }

            [DisplayName("View Count")]
            public int Watch { get; set; }
        }
    }
}