using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Atom.Models
{
    public class BlogAddModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        //not for model
        [ReadOnly(true)]
        public int Type{get;set;}
    }
}