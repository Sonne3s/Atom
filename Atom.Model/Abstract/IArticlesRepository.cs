using Atom.Model.Models;
using System.Collections.Generic;
namespace Atom.Model.Abstract
{
    public interface IArticlesRepository
    {
       IEnumerable<Article> Articles { get; }

        void Save(Article article);
        void Publish(int id);
        Article Delete(int id);
    }
}
