using Atom.Model.Models;
using System.Collections.Generic;

namespace Atom.Model.Abstract
{
    public interface IPicturesRepository
    {
        IEnumerable<Picture> Pictures { get; }
        void Save(Picture picture);
        void Save(int id, string theme);
        void Delete(int id);
        void Delete(IEnumerable<Picture> pictures);
    }
}
