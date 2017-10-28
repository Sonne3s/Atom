using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Atom.HtmlHelpers
{
    public static class BootstrapHelpers
    {
        public static string BootstrapCarousel(List<string> images,string id)
        {
            string output="<div id='"+id+"' class='carousel clide' data-interval='3000' data-ride='carousel'>";
            {//индикаторы для карусели
                int i = 0;//индексатор для data-slide-to
                output += "<ol class='carousel-indicators'>";
                foreach (string img in images)
                {
                    output += "<li data-target='#"+id+"' data-slide-to='" + i++ + "'" + ((i == 0) ? " class='active'" : "")+"></li>";// перейти к слайду i карусели, если слайд первый то он активирован
                }
                output += "</ol>";
            }
            {//слайды карусели
                int i = 0;//индексатор слайдов
                output += "<div class='carousel-inner'>";
                foreach(string img in images)
                {
                    output += "<div class='item" + ((i++ == 0) ? " active" : "") + "'>";
                    output += ImgDetermHelpers.ImgDeterm(Regex.Replace(img, @"\[title\].*\[\/title\]", String.Empty),new {height="400",@class= "center-block img-responsive" });
                    output += "<a href='' class='carousel-fullscreen'><span class='glyphicon glyphicon-fullscreen left bottom'></span></a>";
                    output += "<div class='carousel-caption'>";
                    output += "<h3>"+Regex.Replace(Regex.Match(img, @"(\[title\].*\[\/title\])").Value, @"(\[title\])|(\[\/title\])","") +"</h3>";
                    output += "</div></div>";
                }
                output += "</div>";
            }
            {// Навигация для карусели
                output += "<a class='carousel-control left' href='#" + id + "' data-slide='prev'>";
                output += "<span class='glyphicon glyphicon-chevron-left'></span>";
                output += "</a>";
                output += "<a class='carousel-control right' href='#" + id + "' data-slide='next'>";
                output += "<span class='glyphicon glyphicon-chevron-right'></span>";
                output += "</a>";
            }
            output += "</div>";
            return output;
        }
    }
}