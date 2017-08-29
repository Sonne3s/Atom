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
        private static string reflectGetAttr(Object obj)//осуществляет поддержку передачи аттрибутов тега в параметре изпользуя анонимный тип
        {
            //принимает анонимный тип
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string output = "";
            foreach (PropertyInfo p in properties)
            {
                output += p.Name + "='" + p.GetValue(obj).ToString() + "' ";
            }
            return output;//выводит строку с перечнем аттрибутов и значений
        }
        public static string ImgDeterm(string img, Object attributes=null, string location= "/Content/img/", string type="jpg")
        {
            //выводит строку с тегом img
            return("<img src='"+location+img+"."+type+"' " + ((attributes!=null)?reflectGetAttr(attributes):"")+ "/>");
        }
        public static MvcHtmlString TapeDeterm(this HtmlHelper html, string imgIn)
        {
            //выводит тег img для blog/index
            return MvcHtmlString.Create(ImgDeterm(imgIn, new {@class="media-object", width="200" }));
        }
    }
}