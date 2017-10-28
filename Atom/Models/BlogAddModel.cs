using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Atom.Models
{
    public class BlogAddModel
    {
        public int ID { get; set; }
        [Display(Name="Название")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [Required]
        public string Annotation { get; set; }
        [Display(Name = "Теги")]
        public string Tags { get; set; }
        [Display(Name = "Изображение")]
        public string Image { get; set; }
        [Display(Name = "Содержание")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }
        [Display(Name = "Время начала")]
        [DataType(DataType.Time)]
        public DateTime? TimeStart { get; set; }
        [Display(Name = "Время окончания")]
        [DataType("datetime-local")]
        public DateTime? DateEnd { get; set; }
        //not for model
        [ReadOnly(true)]
        public int Type{get;set;}
    }
}