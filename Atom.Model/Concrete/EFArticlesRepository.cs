using Atom.Model.Abstract;
using Atom.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atom.Model.Concrete
{
    public class EFArticlesRepository:IArticlesRepository
    {
        private Atom db = new Atom();

        public IEnumerable<Article> Articles
        {
            get { return db.Artictes; }
        }

       public void Save(Article article)
        {
            if (article.ID == 0)
            {
                article.Published = DateTime.Now;
                db.Artictes.Add(article);
            }
            else
            {
                Article dbEntry = db.Artictes.Find(article.ID);
                if (dbEntry != null)
                {
                    dbEntry.Image = article.Image;
                    dbEntry.Name = article.Name;
                    dbEntry.Publish = article.Publish;
                    dbEntry.Published = DateTime.Now;
                    dbEntry.Type = article.Type;
                    dbEntry.UserID = article.UserID;
                    dbEntry.Annotation = article.Annotation;
                    dbEntry.Content = article.Content;
                    dbEntry.DateEnd = article.DateEnd;
                    dbEntry.DateStart = article.DateStart;
                    dbEntry.Tags = article.Tags;
                }
            }
            db.SaveChanges();
        }
       public void Publish(int id)
       {
           Article dbEntry = db.Artictes.Find(id);
           if(dbEntry!=null)
           {
               dbEntry.Publish = !dbEntry.Publish;
               if (dbEntry.Publish) dbEntry.Published = DateTime.Now;
           }
           db.SaveChanges();
       }
       public Article Delete(int id)
       {
           Article dbEntry = db.Artictes.Find(id);
           if(dbEntry!=null)
           {
               db.Artictes.Remove(dbEntry);
           }
           db.SaveChanges();
           return dbEntry;
       }
    }  
}
