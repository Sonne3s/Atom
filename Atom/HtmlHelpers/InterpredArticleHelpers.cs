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
        private enum TypeForParse { Image, Tag, YouTube, Page };
        public static string UpdateImgNumber(string input, int? startNum)
        {
            if (startNum != null)
            {
                List<string> lines = ParseContent(input,TypeForParse.Image);
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
        private static List<string> ParseContent(string input, TypeForParse type)
        {
            List<string> output = new List<string>();
            string pattern = "";
            switch (type)
            {
                case TypeForParse.Image:pattern = @"(\[img\]\w*\[\/\w*\])|(.\S*)"; break;
                case TypeForParse.Tag:pattern = @"#[^#]*"; break;
                case TypeForParse.YouTube:pattern = @"(\[youtube\]\S*\[\/\w*\])|(.\w*)"; break;
                default: pattern = @"(\[img\].*\[\/img\])|(\[youtube\]\S*\[\/youtube\])|(.\w*)"; break;
            }
            foreach (Match parse in Regex.Matches(input, pattern))
            {
               output.Add(parse.Value);
            }
            return output;
        }
        public static MvcHtmlString InterpredTags(this HtmlHelper html, string input)
        {
            string output = "";
            if (input != null)
            {
                List<string> content = ParseContent(input, TypeForParse.Tag);
                output += "<div class='col-xs-12'>";
                content.ForEach(parse => output += "<div class='tag'>" + Regex.Replace(parse, @"#", String.Empty) + "</div>");
                output += "</div>";
            }
            return new MvcHtmlString(output);
        }
        public static string InterpredYouTubeLink(string link)
        {
            if (link.Contains("embed")) return link;
            else if (link.Contains("=")) return "https://www.youtube.com/embed/" + link.Split(new char[] { '=' })[1];
            else if (link.Contains("youtu.be")) return Regex.Replace(link, "https://youtu.be/", "https://www.youtube.com/embed/");
            else return "errorlink";
        }
        public static MvcHtmlString InterpredArticle(this HtmlHelper html, string input)
        {
            string output="";
            int carouselsCounter = 0;
            List<string> content = ParseContent(input,TypeForParse.Page);
            content.Add("");//в случае если последним было изображение -> завершает создание карусели
            List<string> images = new List<string>();
            foreach (string parse in content)
            {
                if (parse.Contains("[img]"))
                {
                    images.Add(Regex.Replace(parse, @"(\[img\])|(\[\/img\])", String.Empty));
                }
                else
                {
                    if(images.Count>0)
                    {
                        output += BootstrapHelpers.BootstrapCarousel(images, ("Carousel" + carouselsCounter++));
                        images.Clear();
                    }
                    if (parse.Contains("[youtube]"))
                    {
                        output += "<br/><div class='youtube'><iframe align='middle' width='100%' height='400' src='"
                            + InterpredYouTubeLink(Regex.Replace(parse, @"(\[\w*\])|(\[\/\w*\])", String.Empty))
                            + "' frameborder='0' allowfullscreen></iframe></div><br/>";
                    }
                    else output += "<p>"+parse + "</p>\n";
                }
            }
            return new MvcHtmlString(output);
        }
    }
}