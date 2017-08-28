using Atom.HtmlHelpers;
using Atom.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atom.Models
{
    public static class ToModelExtensionMetods
    {
        //from Article
        public static Article ToModel(this BlogAddModel viewmodel,int? num=0)
        {
            Article model = new Article() { Name = viewmodel.Name, Image = viewmodel.Image, Content = InterpredArticleHelpers.UpdateImgNumber(viewmodel.Content,num) };
            return model;
        }
        public static Article ToModel(this BlogAddModel viewmodel, DateTime data, int? num = 0)
        {
            Article model = new Article() { Name = viewmodel.Name, Image = viewmodel.Image, Content = InterpredArticleHelpers.UpdateImgNumber(viewmodel.Content, num), Published=data };
            return model;
        }
        public static Article ToModel(this BlogAddModel viewmodel, DateTime data, int userid, int? num = 0)
        {
            Article model = new Article() { Name = viewmodel.Name, Image = viewmodel.Image, Content = InterpredArticleHelpers.UpdateImgNumber(viewmodel.Content, num), Published=data, UserID=userid};
            return model;
        }
        public static Article ToModel(this BlogAddModel viewmodel, DateTime data, int userid, int type, int? num = 0)
        {
            Article model = new Article() { Name = viewmodel.Name, Image = viewmodel.Image, Content = InterpredArticleHelpers.UpdateImgNumber(viewmodel.Content, num), Published = data, UserID = userid, Type=type.ToString() };
            return model;
        }
        public static Article ToModel(this BlogAddModel viewmodel, DateTime data, int userid, string type, int? num = 0)
        {
            Article model = new Article() { Name = viewmodel.Name, Image = viewmodel.Image, Content = InterpredArticleHelpers.UpdateImgNumber(viewmodel.Content, num), Published = data, UserID = userid, Type = type };
            return model;
        }
        //
    }
}