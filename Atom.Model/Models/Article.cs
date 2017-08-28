using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Atom.Model.Models
{
    public class Article
    {
        [ReadOnly(true)]
        public int ID { get; set; }
        [ReadOnly(true)]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [ReadOnly(true)]
        public bool Publish { get; set; }//Отображение статьи
        [ReadOnly(true)]
        public DateTime Published { get; set; }// Дата+Время публикации/изменения
        [ReadOnly(true)]
        public int UserID { get; set; }//Последний пользователь
    }
}
