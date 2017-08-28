using System.Collections.Generic;
using System.Linq;
using Atom.Model.Models;

namespace Atom.Models
{
    public class BlogsListModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public int TypeInfo{get;set;}
    }
}