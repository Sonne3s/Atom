using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Atom.HtmlHelpers
{
    public static class OtherHelpers
    {
        public static MvcHtmlString DropDownMenuForCase(this HtmlHelper html,IEnumerable<string> strings,string def, Object attributes=null)
        {
            string output = "<select"+ ((attributes!=null)?" " + reflectGetAttr(attributes):"")+">";
            foreach (string s in strings)
            {
                output += "<option " + ((s == def) ? "selected " : "") + "value='" + s + "'>" + s + "</option>";
            }
            output += "</select>";
            return MvcHtmlString.Create(output);
        }

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
    }
}