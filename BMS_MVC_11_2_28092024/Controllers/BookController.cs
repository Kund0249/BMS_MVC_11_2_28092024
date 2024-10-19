using BMS_MVC_11_2_28092024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using BMS_MVC.DataAccess.Repositories;
using BMS_MVC.DataAccess.Entity;

namespace BMS_MVC_11_2_28092024.Controllers
{
    public class BookController : Controller
    {
        // GET: Book

        private CategoryRepository categoryRepository;
        public BookController()
        {
            categoryRepository = new CategoryRepository();
        }
        public ActionResult Index()
        {
           return View();
        }


        public ActionResult Create()
        {
            List<CategoryEntity> catlist = categoryRepository.Get();
            BookModel model = new BookModel()
            {
                CategoryList = catlist.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookModel model)
        {
            if (model.CoverPhoto != null)
            {
                string ext = Path.GetExtension(model.CoverPhoto.FileName);
                string fileName = DateTime.Now.ToString("ddmmyyyy-") + Guid.NewGuid().ToString()+ext;
                string directory = "~/Resources/Image";
                string filePath  = Path.Combine(Server.MapPath(directory), fileName);
                model.CoverPhoto.SaveAs(filePath);
            }
            return View();
        }
    }
}