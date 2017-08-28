using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atom.Model.Concrete;
using Atom.Model.Abstract;
using Atom.Model.Models;
using Atom.Models;

namespace Atom.Controllers
{
    /*public enum BlogType
    {
        News=1,
        Previews=2,
        Infos=3
    }*/ 
    public class BlogController : Controller
    {
        private IArticlesRepository repository;
        private IPicturesRepository prepository;
        public BlogController(IArticlesRepository articlesRepository, IPicturesRepository picturesRepository)
        {
            this.repository = articlesRepository;
            this.prepository = picturesRepository;

        }
        // GET: Blog
        public ActionResult Index(int typeInfo = 0)
        {
            BlogsListModel model = new BlogsListModel() { TypeInfo = typeInfo };
            switch (typeInfo)
            {
                case 1: model.Articles = repository.Articles.Where(x => x.Type == "1"); break;
                case 2: model.Articles = repository.Articles.Where(x => x.Type == "2"); break;
                case 3: model.Articles = repository.Articles.Where(x => x.Type == "3"); break;
                default: model.Articles = repository.Articles; break;
            }
            return View(model);
        }
        public ActionResult ViewPage(int id)
        {
            return View(repository.Articles.FirstOrDefault(x=>x.ID==id));
        }
        public ActionResult Create(int typeInfo=0)
        {
            return View(new BlogAddModel() { Type=typeInfo});
        }
        [HttpPost]
        public ActionResult Create(BlogAddModel article,string typeInfo,int? imgStartIndex=null)
        {
            repository.Save(article.ToModel(DateTime.Now,0,typeInfo,imgStartIndex));
            return RedirectToAction("Index");
        }
        public ActionResult CreatePictures()
        {
            return PartialView(prepository.Pictures);
        }
        [HttpPost]
        public JsonResult CreateJsonPicturesPost()
        {
            var upload = Request.Files[0];
            string theme = Request.Form["theme"];
            int lastIndex= prepository.Pictures.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Content/img/" + (++lastIndex).ToString() + ".jpg"));
                prepository.Save(lastIndex,theme);
            }
            return Json(lastIndex);
        }
        public JsonResult CreateJsonPictures()
        {
            return Json(prepository.Pictures, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Article deletedArticle = repository.Delete(id);
            IEnumerable<Picture> picturesForDelete = prepository.Pictures.Where(x => x.Theme == deletedArticle.Name);
            prepository.Delete(picturesForDelete);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Publish(int id)
        {
            repository.Publish(id);
            return RedirectToAction("Index");
        }

    }
}