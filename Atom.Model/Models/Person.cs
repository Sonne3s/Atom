using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atom.Model.Models
{
    public enum Position
    {
        Ученик,
        Тренер,
        Сотрудник,
        Родственник,
        Прочее
    }
    public class Person
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public string Phone { get; set; }
        public Position Position { get; set; }

        public string Photo { get; set; }
    }
}
