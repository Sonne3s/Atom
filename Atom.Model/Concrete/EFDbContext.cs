using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atom.Model.Models;

namespace Atom.Model.Concrete
{
    class Atom:DbContext
    {
        public DbSet<Article> Artictes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
