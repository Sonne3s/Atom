using Atom.Model.Abstract;
using Atom.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atom.Model.Concrete
{
    public class EFPicturesRepository:IPicturesRepository
    {
        private Atom db=new Atom();
        public IEnumerable<Picture> Pictures
        {
            get { return db.Pictures; }
        }
        public void Save(Picture picture)
        {           
            db.Pictures.Add(picture);            
            db.SaveChanges();
        }
        public void Save(int id, string theme)
        {
            db.Pictures.Add(new Picture { Id = id, Theme = theme });
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Picture dbEntry = db.Pictures.Find(id);
            db.Pictures.Remove(dbEntry);
            db.SaveChanges();
        }
        public void Delete(IEnumerable<Picture> pictures)
        {
            db.Pictures.RemoveRange(pictures);
            db.SaveChanges();
        }
    }
}
