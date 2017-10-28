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
            Article model = Convertion(viewmodel, null, null, null, num);
            return model;
        }
        public static Article ToModel(this BlogAddModel viewmodel, DateTime data, int? num = 0)
        {
            Article model = Convertion(viewmodel, data, null, null, num);
            return model;
        }
        public static Article ToModel(this BlogAddModel viewmodel, DateTime data, int userid, int? num = 0)
        {
            Article model = Convertion(viewmodel, data, userid, null, num);
            return model;
        }
        public static Article ToModel(this BlogAddModel viewmodel, DateTime data, int userid, int type, int? num = 0)
        {
            Article model = Convertion(viewmodel, data, userid, type.ToString(), num);
            return model;
        }
        public static Article ToModel(this BlogAddModel viewmodel, DateTime data, int userid, string type, int? num = 0)
        {
            Article model = Convertion(viewmodel, data, userid, type, num);
            return model;
        }
        private static Article Convertion(BlogAddModel viewmodel, DateTime? data, int? userid, string type, int? num = 0)
        {
            //совмещение даты и времени
            bool dateexists = false;
            DateTime dateandtime=new DateTime();
            if (viewmodel.DateStart != null)
            {
                dateexists = true;
                dateandtime = viewmodel.DateStart ?? new DateTime();
                if (viewmodel.TimeStart != null)
                {
                    TimeSpan time= (viewmodel.TimeStart ?? new DateTime()).TimeOfDay;
                    dateandtime=dateandtime.Add(time);
                }
            }

            Article model = new Article() { Name = viewmodel.Name, Image = (viewmodel.Image!=null)? (Convert.ToInt32(viewmodel.Image) + num).ToString():"logo", Annotation = viewmodel.Annotation,
                Tags = viewmodel.Tags, DateStart = (dateexists)?dateandtime:viewmodel.DateStart, DateEnd = viewmodel.DateEnd,
                Content = InterpredArticleHelpers.UpdateImgNumber(viewmodel.Content, num), Published = data??DateTime.Now,
                UserID = userid??0, Type = type.ToString()??"1" };
            return model;
        }
        //
    }
}