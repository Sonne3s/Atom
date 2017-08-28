using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Atom.HtmlHelpers
{
    public static class ImgDetermHelpers
    {
        private static string reflectGetAttr(Object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string output = "";
            foreach (PropertyInfo p in properties)
            {
                output += p.Name + "='" + p.GetValue(obj).ToString() + "' ";
            }
            return output;
        }
        public static string ImgDeterm(string img, Object attributes=null, string location= "/Content/img/", string type="jpg")
        {
            return("<img src='"+location+img+"."+type+"' " + ((attributes!=null)?reflectGetAttr(attributes):"")+ "/>");
        }
        public static MvcHtmlString TapeDeterm(this HtmlHelper html, string imgIn)
        {
            return MvcHtmlString.Create(ImgDeterm(imgIn, new {@class="media-object", width="200" }));
        }
    }
}