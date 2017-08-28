using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atom.Model.Models
{
    public enum Degree
    {
        Папа,
        Мама,
        Брат,
        Сестра,
        Бабушка,
        Дедушка,
        Родственник,
        NO
    }
    public enum Rank
    {
        Нет,
        ВторойЮношеский,
        ПервыйЮношеский,
        ТретийВзрослый,
        ВторойВзрослый,
        ПервыйВзрослый,
        КМС,
        МС,
        ЗМС        
    }
    public class Student
    {
        [Key, ForeignKey("Person")]
        public int PersonID { get; set; }

        public Rank JudoRank { get; set; }
        public Rank SamboRank { get; set; }
        public Rank ARBRank { get; set; }

        public int RelativeID1 { get; set; }//ИД родственника
        public Degree Degree1 { get; set; }//степень родства
        public int RelativeID2 { get; set; }
        public Degree Degree2 { get; set; }
        public int RelativeID3 { get; set; }
        public Degree Degree3 { get; set; }

        public virtual Person Person { get; set; }
    }
}
