using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netRestApi.Models
{
    [Table("entRestApiTesting")]
    public class BlogDataModel
    {
        [Key] 
        // [Column("Blog_Id")] if column name in db and model name are not same
        public int Blog_Id {get; set;}
        public string? Blog_Title {get; set;}
        public string? Blog_Author{get; set;}
        public string? Blog_Content{get; set;}
    }
} 