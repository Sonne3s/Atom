using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Atom.HtmlHelpers
{
    public static class InterpredArticleHelpers
    {
        public static string UpdateImgNumber(string input, int? startNum)
        {
            if (startNum != null)
            {
                List<string> lines = ParseContent(input);
                string output = "";
                foreach (string line in lines)
                {
                    if (line.Contains("[img]"))
                    {
                        string inputNum = Regex.Replace(line, @"(\[\w*\])|(\[\/\w*\])", string.Empty);
                        int currentNum = Convert.ToInt32(inputNum) + Convert.ToInt32(startNum);
                        output += "[img]" + currentNum + "[/img]\n";
                    }
                    //output += ("[img]" + (Convert.ToInt32(Regex.Replace(line, @"(\[\w*\])|(\[\\\w*\])", string.Empty)) + startNum) + "[/img]\n");
                    else output += (line.Contains("\r") ? "" : line+"\n");
                }
                return output;
            }
            else return input;
        }
        public static List<string> ParseContent(string input)
        {
            List<string> output = new List<string>();
            string pattern = @"(\[img\]\w*\[\/\w*\])|(.\w*)";
            foreach (Match parse in Regex.Matches(input, pattern))
            {
               output.Add(parse.Value);
            }
            return output;
        }
        public static MvcHtmlString InterpredArticle(this HtmlHelper html, string input)
        {
            string output="";
            int carouselsCounter = 0;
            List<string> content = ParseContent(input);
            content.Add("");//в случае если последним было изображение -> завершает создание карусели
            List<string> images = new List<string>();
            foreach (string parse in content)
            {
                if (parse.Contains("[img]"))
                {
                    images.Add(Regex.Replace(parse, @"(\[\w*\])|(\[\/\w*\])", String.Empty));
                }
                else
                {
                    if(images.Count>0)
                    {
                        output += BootstrapHelpers.BootstrapCarousel(images, ("Carousel" + carouselsCounter++));
                        images.Clear();
                    }
                    output += parse + "\n";
                }
            }
            return new MvcHtmlString(output);
        }
    }
}